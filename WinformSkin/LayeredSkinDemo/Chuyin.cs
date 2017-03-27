using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;

namespace test
{
    public partial class Chuyin : LayeredForm
    {
        public Chuyin()
        {
            InitializeComponent();
        }

        private void Chuyin_Load(object sender, EventArgs e)
        {
            Image[] images = new Image[129];
            for (int i = 0; i < 129; i++)
            {
                images[i] = Image.FromFile("Images\\chuyin\\" + (i + 1).ToString() + ".png");
            }
            ((DuiPictureBox)layeredBaseControl1.InnerDuiControl.FindControl("chuyin")[0]).Images = images;
        }

        private void layeredBaseControl1_MouseDown(object sender, MouseEventArgs e)
        {
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
        }
    }
}
