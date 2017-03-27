using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace test
{
    public partial class ShadoForm : LayeredForm
    {
        public ShadoForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.BackgroundRender = new ShadowBackgroundRender();
            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            //LayeredSkin.ImageEffects.DrawLightString("label1", e.Graphics, new Font("宋体", 60), Color.Red, Color.Black, new Rectangle(0, 0, 400, 150), StringFormat.GenericDefault, 5);
        }
    }
}
