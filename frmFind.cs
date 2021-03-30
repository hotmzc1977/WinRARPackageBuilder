using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PkgBuilder
{
    public partial class frmFind : Form
    {
        private string mFind;

        public string Find
        {
            get { return mFind; }
            set { mFind = value; }
        }
        private string mReplace;

        public string Replace
        {
            get { return mReplace; }
            set { mReplace = value; }
        }
        private Boolean mBlnReplace;

        public Boolean BlnReplace
        {
            get { return mBlnReplace; }
            set { mBlnReplace = value; }
        }

        public frmFind()
        {
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            mBlnReplace = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            mFind = this.txtFind.Text;
            mReplace = this.txtReplace.Text;
            mBlnReplace = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mBlnReplace = false ;
            this.Hide();
        }
    }
}
