using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;

namespace PkgBuilder
{
    public partial class frmMain : Form
    {
        private TreeNode nodeOver = null;
        private int count = 0;
        private static int MAX_FILE_NUMBER = 1000;
        private int cntCompressed = 0;
        
        private string chrExcluded = "/\\*?<>|";
        public frmMain(string[] args)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.treeView1.AllowDrop = true;
            this.treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            this.treeView1.DragOver += new DragEventHandler(treeView1_DragOver);
            this.treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
           
            this.treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            this.treeView1.ItemDrag+=new ItemDragEventHandler(treeView1_ItemDrag);
           
            this.treeView1.AfterLabelEdit += new NodeLabelEditEventHandler(treeView1_AfterLabelEdit);
            this.treeView1.KeyDown += new KeyEventHandler(treeView1_KeyDown);
            this.addCtxBtn.Image = this.tbAdd.Image;
            this.addFileCtxBtn.Image = this.tbNewFile.Image;
            this.addFileCtxBtn.Click += new EventHandler(tbNewFile_Click);
            this.addFolderCtxBtn.Image = this.tbNewFolder.Image;
            this.addFolderCtxBtn.Click +=new EventHandler(tbNewFolder_Click);
            this.syncCtxBtn.Image = this.tbSync.Image;
            this.syncCtxBtn.Click += new EventHandler(tbSync_Click);
            this.delCtlBtn.Image = this.tbDel.Image;
            this.delCtlBtn.Click += new EventHandler(tbDel_Click);
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
            this.treeView1.AfterCheck += new TreeViewEventHandler(treeView1_AfterCheck);
            this.treeView1.BeforeCheck += new TreeViewCancelEventHandler(treeView1_BeforeCheck);
            this.treeView1.NodeMouseHover += new TreeNodeMouseHoverEventHandler(treeView1_NodeMouseHover);
            //tc = this.treeView1.SelectedNode.BackColor;
            if (args.Length > 0)
            {
                loadTreefromPkgFile(args[0],false );
            }
        }

        void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (e.Node != null)
            {
                TreeNode tn = e.Node;
                if(!IsFolder(tn))
                {
                    if(File.Exists(tn.Text))
                    {
                        tn.ToolTipText = "Last modified time:" + File.GetLastWriteTime(tn.Text).ToString() + "(" + tn.Text +")";
                        
                    }
                }
            }
        }

        void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //this.nodeCheck = e.Node;
        }

        void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkChildNodes(e.Node);   
        }

        private void checkChildNodes(TreeNode tn)
        {
            foreach (TreeNode tn2 in tn.Nodes)
            {
                tn2.Checked = tn.Checked;
                checkChildNodes(tn2);
            }
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == this.treeView1.SelectedNode && e.Button == MouseButtons.Left)
            {
                if ( e.Node.Parent != null)
                {
                    treeView1.LabelEdit = true;
                    this.staStatus.Text = "Begin edit...";
                }
                else
                {
                    treeView1.LabelEdit = false;
                    this.staStatus.Text = "ROOT or file can't be edited!";
                }
            }
            
            if (e.Button == MouseButtons.Right && e.Node != null)
            {
                treeView1.SelectedNode = e.Node;
                this.ctxMenuBar.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
            if(e.Button == MouseButtons.Left)
            {
                //checkChildNodes(e.Node);
            }
        }

        void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (this.treeView1.SelectedNode != null)
                {
                    tbDel_Click(sender, null);
                }
            }                                                                   
        }

        void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(this.chrExcluded.ToCharArray()) == -1)
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: " + this.chrExcluded,
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }
            this.treeView1.LabelEdit = false;

        }

 

        void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move|DragDropEffects.Copy);
        }

        void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                if ((e.KeyState & (8+1)) == (8+1))
                    e.Effect = DragDropEffects.Copy | DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
           
            //throw new NotImplementedException();
        }

        bool loadTreefromPkgFile(string fle, bool warning)
        {
            if (File.Exists(fle))
            {
                if (fle.ToLower().EndsWith(".pkg"))
                {
                    DialogResult dr;
                    if (warning == true)
                        dr= MessageBox.Show(this, "Load tree structure from " + fle, "Loading",MessageBoxButtons.YesNoCancel);
                    else
                        dr = DialogResult.Yes ;

                    if (dr == DialogResult.Yes)
                    {
                        this.treeView1.Nodes.Clear();
                        TreeCls.LoadTree(this.treeView1, fle);
                        browseAllNodes(this.treeView1.Nodes[0]);
                        this.treeView1.Nodes[0].Expand();
                        this.staFileName.Text = fle;
                        this.staStatus.Text = "Loaded";
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false ))
            {
                string[] fles = (string[])e.Data.GetData(DataFormats.FileDrop,false );
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                if (DestinationNode == null)
                {
                    string fle = fles[0];
                    loadTreefromPkgFile(fle,true );
                }
                else
                {
                    foreach (string fle in fles)
                    {
                        if (Directory.Exists(fle))
                        {
                            TreeNode tn= AddNode(DestinationNode, getLastPath(fle));
                            SyncFolder(fle, tn);
                        }
                        if(File.Exists(fle))
                        {
                            AddNode(DestinationNode, fle);
                        }
                    }
                }
            }
            else if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                TreeNode NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (IsFolder(NewNode))
                {
                    if (AddNode(DestinationNode, NewNode))
                    {
                        if ((e.KeyState & 8) != 8)
                            NewNode.Remove();
                    }
                }
                else
                { 
                    if (AddNode(DestinationNode, NewNode.Text) != null)
                    {
                        if ((e.KeyState & 8) != 8)
                            NewNode.Remove();
                    }
                }   

            }

            
        }

        void treeView1_DragOver(object sender, DragEventArgs e)
        {

            Point p = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            nodeOver = ((TreeView)sender).GetNodeAt(p.X, p.Y);
            ((TreeView)sender).SelectedNode = nodeOver;


        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Open tree structure file...";
            this.openFileDialog1.Filter = "Packge Info(*.pkg)|*.pkg";
            this.openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileOpen = this.openFileDialog1.FileName;
                loadTreefromPkgFile(fileOpen, true);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            TreeNode ParentNode1;
            if (treeView1.Nodes.Count == 0)
            {
                ParentNode1 = treeView1.Nodes.Add("ROOT");
                setNodeImage(ParentNode1);
                AddNode(ParentNode1, "CLIENT");
                AddNode(ParentNode1, "SERVER");
                AddNode(ParentNode1, "SQL");
                AddNode(ParentNode1, "VBR");
                ParentNode1.Expand();
            }
            this.tbType.Text = "RAR";
        }

        private void browseAllNodes(TreeNode tn)
        {
            
            foreach (TreeNode t in tn.Nodes)
            {
                if (IsFolder(t))
                {
                    browseAllNodes(t);
                }
                else
                {
                    t.ImageIndex = 2;
                    t.SelectedImageIndex = 2;
                    if (!File.Exists(t.Text))
                    {
                        t.ForeColor = Color.Red;
                    }
                    else
                    {
                        t.ForeColor = Color.Black;
                    }
                }

            }
        }

        private void CompressAllNodes(TreeNode tn, string flder, string file2Compress, string fType)
        {
            string flder2;
            
            List<string> files2 = new List<string>();
            foreach (TreeNode t in tn.Nodes)
            {
                if (!IsFolder(t))
                {
                    if (File.Exists(t.Text))
                    {
                        t.ForeColor = Color.Black ;
                        if (this.treeView1.CheckBoxes == true)
                        {
                            if (t.Checked == true)
                                files2.Add(t.Text);
                        }
                        else
                            files2.Add(t.Text);
                    }
                    else
                    {
                        t.ForeColor = Color.Red;
                    }
                }
                
           
            }
            if (files2.Count > 0)
            {
                cntCompressed = cntCompressed + files2.Count;
                string[] files = files2.ToArray();
                clsRAR rar = new clsRAR();
                rar.setFolder(flder);
                rar.setInputFile(files);
                rar.setOutputFile(file2Compress);
                rar.setType(fType);
                rar.setCurPath(Application.StartupPath + "\\");
                rar.DoCompress();
            }
            foreach (TreeNode t in tn.Nodes)
            {
                if (IsFolder(t))
                {
                    if (flder == "")
                        flder2 = t.Text;
                    else
                        flder2 = flder + "\\" + t.Text;
                    CompressAllNodes(t, flder2, file2Compress, fType);
                }
                //else
                //{
                //    clsRAR rar = new clsRAR();
                //    rar.setFolder(flder);
                //    rar.setInputFile(t.Text);
                //    rar.setOutputFile(file2Compress);
                //    rar.setType(fType);
                //    rar.setCurPath(Application.StartupPath + "\\");
                //    rar.DoCompress();
                //}

            }
        }

        private bool IsFolder(TreeNode tn)
        {
            if (tn.Text.IndexOf("\\") >= 0)
            {
                return false;
            }
            else
                return true;
        }

        private void tbNewFolder_Click(object sender, EventArgs e)
        {
            if (IsFolder(this.treeView1.SelectedNode))
            {
                string s = Interaction.InputBox("Please input folder name!", "", "" , this.Left ,this.Top  );
                if (s.Trim() == "")
                    return;
                if (s.ToLower() == "root")
                {
                    MessageBox.Show(this, "ROOT is not allowed for new folders", "Alert");
                    return;
                }

                foreach (char c in chrExcluded)
                {
                    if (s.IndexOf(c) >= 0)
                    {
                        MessageBox.Show(this, "A folder name can't contain any character in /\\*?<>|", "Alert");
                        return;
                    }
                }
                foreach (TreeNode tn in this.treeView1.SelectedNode.Nodes)
                {
                    if (tn.Text.ToLower() == s.ToLower())
                    {
                        MessageBox.Show(this, "Duplicate folder is not allowed", "Alert!");
                        return;
                    }
                }

                TreeNode tn2 = this.treeView1.SelectedNode.Nodes.Add(s);
                tn2.ImageIndex = 0;
                tn2.SelectedImageIndex = 0;
            }
        }

        private void tbNewFile_Click(object sender, EventArgs e)
        {
            if (IsFolder(this.treeView1.SelectedNode))
            {
                this.openFileDialog1.Multiselect = true;
                this.openFileDialog1.Title = "Choose files to add...";
                this.openFileDialog1.Filter = "All files(*.*)|*.*";
                DialogResult dr = openFileDialog1.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    string[] fls = this.openFileDialog1.FileNames;
                    foreach (string fl in fls)
                    {
                        AddNode(this.treeView1.SelectedNode, fl);
                    }
                }
            }
        }

        private void tbCompile_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.FileName = "";
            this.saveFileDialog1.Title = "Compile to ...";
            if (tbType.Text == "RAR")
                this.saveFileDialog1.Filter = "RAR Files (*.rar)|*.rar";
            else if (tbType.Text == "ZIP")
            {
                if (SetWinRarPath() == false)
                {
                    MessageBox.Show("Can't locate winrar.exe");
                    return;
                }
                this.saveFileDialog1.Filter = "ZIP Files (*.zip)|*.zip";
            }
            else if (tbType.Text == "EXE")
                this.saveFileDialog1.Filter = "EXE Files (*.exe)|*.exe";
            else
                return;

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cntCompressed = 0;
                string outputfile = this.saveFileDialog1.FileName;
                TreeNode tn = this.treeView1.Nodes[0];
                CompressAllNodes(tn, "", outputfile, this.tbType.Text);
                this.staStatus.Text = cntCompressed +" files compiled!";
            }
        }



        private bool SetWinRarPath()
        {
            string curPath = Application.StartupPath + "\\";
            string flpath =
            INI.GetIniFileString(curPath + clsRAR.CONFIG_FILE, clsRAR.CATEGORY_PATH, clsRAR.KEY_WINRAR, "");
            if (flpath.ToLower().EndsWith("winrar.exe"))
            {
                if (System.IO.File.Exists(flpath))
                    return true;
            }
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Locate winrar.exe";
            this.openFileDialog1.Filter = "WinRar.exe|*.exe";
     
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                flpath = this.openFileDialog1.FileName;
                if (flpath.ToLower().EndsWith("winrar.exe"))
                {
                    INI.SetIniFileString(curPath + clsRAR.CONFIG_FILE, clsRAR.CATEGORY_PATH, clsRAR.KEY_WINRAR, flpath);
                    return true;
                }
                
            }
            return false;
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Sort all nodes before saving?", "Alert!", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                treeView1.TreeViewNodeSorter = new NodeSorter();
                this.treeView1.Sort();
            }
            string saveFile = this.staFileName.Text;
            if (saveFile == "")
            { 
                this.saveFileDialog1.FileName ="";
                this.saveFileDialog1.Title = "Save tree structure to ...";
                this.saveFileDialog1.Filter ="Packge Info(*.pkg)|*.pkg";
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    saveFile = this.saveFileDialog1.FileName;
                else
                {
                    return;
                }
            
            }
            TreeCls.SaveTree(this.treeView1,saveFile);
            this.staStatus.Text = "Saved!";
            this.staFileName.Text = saveFile;
        }

        private void delCheckedNodes(TreeNode tn)
        {
            for (int i = tn.Nodes.Count; i > 0; i--)
            {

                delCheckedNodes(tn.Nodes[i-1]);
            }
            if (tn.Checked == true && tn!= this.treeView1.TopNode)
                tn.Remove();
            
        }
        private void tbDel_Click(object sender, EventArgs e)
        {
            if (this.treeView1.CheckBoxes == true)
            {
                DialogResult dr = MessageBox.Show(this, "Delete all ticked nodes?" + "?", "Alert!", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    delCheckedNodes(this.treeView1.TopNode);
                }
            }
            else
            {
                if (this.treeView1.SelectedNode.Text == null)
                    return;

                if (this.treeView1.SelectedNode.Parent == null)
                {
                    MessageBox.Show(this, "ROOT can't be deleted.", "Alert!");
                }
                else
                {
                    DialogResult dr = MessageBox.Show(this, "Delete " + this.treeView1.SelectedNode.Text + "?", "Alert!", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
                        this.staStatus.Text = "Deleted!";
                    }

                }
            }
        }

        private bool AddNode(TreeNode tn, TreeNode tn2)
        {
            foreach (TreeNode t in tn.Nodes)
            {
                if (t.Text.ToLower() == tn2.Text.ToLower())
                {
                    return false;
                }
            }
            if (IsFolder(tn))
            {
                tn.Nodes.Add((TreeNode)tn2.Clone());
                return true;
            }
            else
                return false;
        }

        private TreeNode AddNode(TreeNode tn, string newNode)
        {
            foreach (TreeNode t in tn.Nodes)
            {
                if (t.Text.ToLower() == newNode.ToLower())
                {
                    return null;
                }
            }
            if (IsFolder(tn))
            {
                TreeNode t2 = tn.Nodes.Add(newNode);
                setNodeImage(t2);
                return t2;
            }
            else
                return null ;
        }

        private void setNodeImage(TreeNode tn)
        { 
            if (IsFolder(tn))
            {
                tn.ImageIndex=0;
                tn.SelectedImageIndex=0;
            }
            else
            {
                tn.ImageIndex=2;
                tn.SelectedImageIndex = 2;
            }
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tbSync_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string fd = this.folderBrowserDialog1.SelectedPath;
                TreeNode Node2Sync = treeView1.SelectedNode;
                for (int i = 0;  Node2Sync.Nodes.Count > 0; i++)
                {
                    Node2Sync.Nodes.Remove(Node2Sync.Nodes[0]);
                }
                Cursor.Current = Cursors.WaitCursor;
                SyncFolder(fd, treeView1.SelectedNode);
                Cursor.Current = Cursors.Default;
                if (count > MAX_FILE_NUMBER)
                    MessageBox.Show(this, "Max "+ MAX_FILE_NUMBER +" files and sub folders allowed.", "Alert!");
                this.staStatus.Text = count + " items added!";
                count = 0;
            }
        }


        private void SyncFolder(string path, TreeNode tn)
        {
            string[] SubDirs = Directory.GetDirectories(path);
            string[] fls = Directory.GetFiles(path);
            
            foreach (string subdir in SubDirs)
            {
                TreeNode tn2 = AddNode(tn,getLastPath(subdir));
                count = count + 1;
                if (count >= MAX_FILE_NUMBER) return;
                SyncFolder(subdir, tn2);
            }

            foreach( string fl in fls)
            {
                AddNode(tn, fl);
                count = count + 1;
                if (count >= MAX_FILE_NUMBER) return;
            }

            
            //foreach (TreeNode tn2 in tn.Nodes)
            //{
            //    if ((IsFolder(tn2)))
            //    {
            //        SyncFolder(path + "\\" + tn2.Text  , tn2 );
            //    }
            //}
            
        }


        private string getLastPath(string path)
        {
            string[] ps = path.Split("\\".ToCharArray());
            return ps[ps.GetUpperBound(0)];
        }

        private void tbAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog(this);
        }

        private void tbMulSel_Click(object sender, EventArgs e)
        {
            this.treeView1.CheckBoxes = !this.treeView1.CheckBoxes;
            this.treeView1.ExpandAll();
        }

        private void tbFont_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.treeView1.Font;
            DialogResult dr = this.fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.treeView1.Font = this.fontDialog1.Font;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            frmFind ff = new frmFind();
            ff.ShowDialog();
            if (ff.BlnReplace == true)
            {
                if (this.treeView1.CheckBoxes)
                { 
                    ReplaceNode(this.treeView1.TopNode,ff.Find ,ff.Replace );
                    browseAllNodes(this.treeView1.Nodes[0]);
                }
            }
        }

        private void ReplaceNode(TreeNode tn,string Find,string Replace)
        {
            for (int i = tn.Nodes.Count; i > 0; i--)
            {

                ReplaceNode(tn.Nodes[i - 1],Find,Replace);
            }
            if (tn.Checked == true && tn != this.treeView1.TopNode)
                tn.Text = tn.Text.Replace(Find, Replace);

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //checkChildNodes(e.Node);
        }
    }

    class NodeSorter :System.Collections.IComparer 
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = (TreeNode)x;
            TreeNode ty = (TreeNode)y;
            if ((tx.Text.Contains("\\") & ty.Text.Contains("\\")) | (!tx.Text.Contains("\\") & !ty.Text.Contains("\\")) )
            {
                int i= String.Compare(tx.Text,ty.Text);
                return i;
            }
            if (!tx.Text.Contains("\\") & ty.Text.Contains("\\"))
                return -1;
            if (tx.Text.Contains("\\") & !ty.Text.Contains("\\"))
                return 1;
            return 0;
        }
    }
}
