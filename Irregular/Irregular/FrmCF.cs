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
    public partial class FrmCF : SkinMain
    {
        public FrmCF()
        {
            InitializeComponent();
        }

        private void btnNewTree_Click(object sender, EventArgs e)
        {
            FrmIphone frm = new FrmIphone();
            frm.Show();
        }

        private void FrmCF_Load(object sender, EventArgs e)
        {

        }
    }
}
