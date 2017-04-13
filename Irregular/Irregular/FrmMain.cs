using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace Irregular
{
    public partial class FrmMain : SkinMain
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnNewTwo_Click(object sender, EventArgs e)
        {
            FrmCF frm = new FrmCF();
            frm.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Win32.AnimateWindow(this.Handle, 1000, Win32.AW_CENTER | Win32.AW_ACTIVATE);
        }
    }
}
