namespace PkgBuilder
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tb = new System.Windows.Forms.ToolStrip();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSync = new System.Windows.Forms.ToolStripButton();
            this.tbDel = new System.Windows.Forms.ToolStripButton();
            this.btnReplace = new System.Windows.Forms.ToolStripButton();
            this.tbMulSel = new System.Windows.Forms.ToolStripButton();
            this.tbType = new System.Windows.Forms.ToolStripComboBox();
            this.tbCompile = new System.Windows.Forms.ToolStripButton();
            this.tbFont = new System.Windows.Forms.ToolStripButton();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.tbAbout = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.staStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.staFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ctxMenuBar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCtxBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderCtxBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileCtxBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.syncCtxBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.delCtlBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tb.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ctxMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 25;
            this.treeView1.Location = new System.Drawing.Point(0, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(731, 468);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.ico");
            this.imageList1.Images.SetKeyName(1, "folderopen.ico");
            this.imageList1.Images.SetKeyName(2, "document.ico");
            // 
            // tb
            // 
            this.tb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpen,
            this.tbSave,
            this.tbAdd,
            this.tbSync,
            this.tbDel,
            this.btnReplace,
            this.tbMulSel,
            this.tbType,
            this.tbCompile,
            this.tbFont,
            this.tbExit,
            this.tbAbout});
            this.tb.Location = new System.Drawing.Point(0, 0);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(731, 25);
            this.tb.TabIndex = 1;
            this.tb.Text = "toolStrip1";
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbOpen.Image")));
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(23, 22);
            this.tbOpen.Text = "Open";
            this.tbOpen.Click += new System.EventHandler(this.tbOpen_Click);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(23, 22);
            this.tbSave.Text = "Save";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNewFolder,
            this.tbNewFile});
            this.tbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbAdd.Image")));
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(29, 22);
            this.tbAdd.Text = "Add...";
            // 
            // tbNewFolder
            // 
            this.tbNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("tbNewFolder.Image")));
            this.tbNewFolder.Name = "tbNewFolder";
            this.tbNewFolder.Size = new System.Drawing.Size(132, 22);
            this.tbNewFolder.Text = "Add Folder";
            this.tbNewFolder.Click += new System.EventHandler(this.tbNewFolder_Click);
            // 
            // tbNewFile
            // 
            this.tbNewFile.Image = ((System.Drawing.Image)(resources.GetObject("tbNewFile.Image")));
            this.tbNewFile.Name = "tbNewFile";
            this.tbNewFile.Size = new System.Drawing.Size(132, 22);
            this.tbNewFile.Text = "Add files";
            this.tbNewFile.Click += new System.EventHandler(this.tbNewFile_Click);
            // 
            // tbSync
            // 
            this.tbSync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSync.Image = ((System.Drawing.Image)(resources.GetObject("tbSync.Image")));
            this.tbSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSync.Name = "tbSync";
            this.tbSync.Size = new System.Drawing.Size(23, 22);
            this.tbSync.Text = "Sync with folder";
            this.tbSync.Click += new System.EventHandler(this.tbSync_Click);
            // 
            // tbDel
            // 
            this.tbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDel.Image = ((System.Drawing.Image)(resources.GetObject("tbDel.Image")));
            this.tbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDel.Name = "tbDel";
            this.tbDel.Size = new System.Drawing.Size(23, 22);
            this.tbDel.Text = "Delete node";
            this.tbDel.Click += new System.EventHandler(this.tbDel_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplace.Image = ((System.Drawing.Image)(resources.GetObject("btnReplace.Image")));
            this.btnReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(23, 22);
            this.btnReplace.Text = "replace";
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // tbMulSel
            // 
            this.tbMulSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbMulSel.Image = ((System.Drawing.Image)(resources.GetObject("tbMulSel.Image")));
            this.tbMulSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbMulSel.Name = "tbMulSel";
            this.tbMulSel.Size = new System.Drawing.Size(23, 22);
            this.tbMulSel.Text = "Multi Select Mode";
            this.tbMulSel.Click += new System.EventHandler(this.tbMulSel_Click);
            // 
            // tbType
            // 
            this.tbType.Items.AddRange(new object[] {
            "RAR",
            "ZIP"});
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(121, 25);
            // 
            // tbCompile
            // 
            this.tbCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCompile.Image = ((System.Drawing.Image)(resources.GetObject("tbCompile.Image")));
            this.tbCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCompile.Name = "tbCompile";
            this.tbCompile.Size = new System.Drawing.Size(23, 22);
            this.tbCompile.Text = "Compile";
            this.tbCompile.Click += new System.EventHandler(this.tbCompile_Click);
            // 
            // tbFont
            // 
            this.tbFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFont.Image = ((System.Drawing.Image)(resources.GetObject("tbFont.Image")));
            this.tbFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFont.Name = "tbFont";
            this.tbFont.Size = new System.Drawing.Size(23, 22);
            this.tbFont.Text = "Font Setting";
            this.tbFont.Click += new System.EventHandler(this.tbFont_Click);
            // 
            // tbExit
            // 
            this.tbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExit.Image = ((System.Drawing.Image)(resources.GetObject("tbExit.Image")));
            this.tbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExit.Name = "tbExit";
            this.tbExit.Size = new System.Drawing.Size(23, 22);
            this.tbExit.Text = "Exit";
            this.tbExit.Click += new System.EventHandler(this.tbExit_Click);
            // 
            // tbAbout
            // 
            this.tbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tbAbout.Image")));
            this.tbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.Size = new System.Drawing.Size(23, 22);
            this.tbAbout.Text = "About";
            this.tbAbout.Click += new System.EventHandler(this.tbAbout_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staStatus,
            this.staFileName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(731, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // staStatus
            // 
            this.staStatus.ForeColor = System.Drawing.Color.Red;
            this.staStatus.Name = "staStatus";
            this.staStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // staFileName
            // 
            this.staFileName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.staFileName.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.staFileName.Name = "staFileName";
            this.staFileName.Size = new System.Drawing.Size(4, 17);
            // 
            // ctxMenuBar
            // 
            this.ctxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCtxBtn,
            this.syncCtxBtn,
            this.delCtlBtn});
            this.ctxMenuBar.Name = "ctxMenuBar";
            this.ctxMenuBar.Size = new System.Drawing.Size(100, 70);
            // 
            // addCtxBtn
            // 
            this.addCtxBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderCtxBtn,
            this.addFileCtxBtn});
            this.addCtxBtn.Name = "addCtxBtn";
            this.addCtxBtn.Size = new System.Drawing.Size(99, 22);
            this.addCtxBtn.Text = "Add";
            // 
            // addFolderCtxBtn
            // 
            this.addFolderCtxBtn.Name = "addFolderCtxBtn";
            this.addFolderCtxBtn.Size = new System.Drawing.Size(107, 22);
            this.addFolderCtxBtn.Text = "Folder";
            // 
            // addFileCtxBtn
            // 
            this.addFileCtxBtn.Name = "addFileCtxBtn";
            this.addFileCtxBtn.Size = new System.Drawing.Size(107, 22);
            this.addFileCtxBtn.Text = "File";
            // 
            // syncCtxBtn
            // 
            this.syncCtxBtn.Name = "syncCtxBtn";
            this.syncCtxBtn.Size = new System.Drawing.Size(99, 22);
            this.syncCtxBtn.Text = "Sync";
            // 
            // delCtlBtn
            // 
            this.delCtlBtn.Name = "delCtlBtn";
            this.delCtlBtn.Size = new System.Drawing.Size(99, 22);
            this.delCtlBtn.Text = "Del";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 522);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "MZC Package Builder 20210105";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tb.ResumeLayout(false);
            this.tb.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxMenuBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip tb;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripButton tbCompile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripDropDownButton tbAdd;
        private System.Windows.Forms.ToolStripMenuItem tbNewFolder;
        private System.Windows.Forms.ToolStripMenuItem tbNewFile;
        private System.Windows.Forms.ToolStripComboBox tbType;
        private System.Windows.Forms.ToolStripButton tbDel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel staFileName;
        private System.Windows.Forms.ToolStripButton tbExit;
        private System.Windows.Forms.ToolStripButton tbSync;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripButton tbAbout;
        private System.Windows.Forms.ToolStripStatusLabel staStatus;
        private System.Windows.Forms.ContextMenuStrip ctxMenuBar;
        private System.Windows.Forms.ToolStripMenuItem addCtxBtn;
        private System.Windows.Forms.ToolStripMenuItem addFolderCtxBtn;
        private System.Windows.Forms.ToolStripMenuItem addFileCtxBtn;
        private System.Windows.Forms.ToolStripMenuItem syncCtxBtn;
        private System.Windows.Forms.ToolStripMenuItem delCtlBtn;
        private System.Windows.Forms.ToolStripButton tbMulSel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton tbFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripButton btnReplace;
    }
}

