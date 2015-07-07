using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhiteWinFormApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start here");
            this.lblStatus.Text = "Phase 1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Second Attempt");
            this.lblStatus.Text = "Phase 2";
        }

        private void btnLaunchMDI_Click(object sender, EventArgs e)
        {
            frmMDIParent frm = new frmMDIParent();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
