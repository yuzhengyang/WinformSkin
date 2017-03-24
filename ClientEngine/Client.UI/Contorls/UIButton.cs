using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Client.UI.Base.Enums;
using System.Windows.Forms;
using Client.UI.DefaultResource;

namespace Client.UI.Contorls
{
    [ToolboxBitmap(typeof(Button))]
    public class UIButton : System.Windows.Forms.Control
    {
        public UIButton()
        {
            this.Size = new Size(30, 30);
            this.BackColor = Color.Yellow;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawRectangle(Pens.Red, new Rectangle(1, 1, 18, 18));
            graphics.DrawImage(GetDefaultResource.GetImage("Common.none.png"), new Rectangle(2, 2, 17, 17));
            base.OnPaint(e);
        }

        protected override void OnCreateControl()
        {
            Client.UI.Base.Utils.GraphicUtils.CreateRegion(this, new Rectangle(System.Drawing.Point.Empty, this.Size), 6, RoundStyle.All);
            base.OnCreateControl();
        }
    }
}
