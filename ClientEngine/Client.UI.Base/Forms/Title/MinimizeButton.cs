using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Client.UI.Base.Forms.Title
{
    public class MinimizeButton : TitleButton
    {
        public MinimizeButton(Form form) :
            base(form)
        {
            this.TitleBoxOffset = new Point(70, 0);
        }

        public override void ButtonPressed(Point mousePoint)
        {
            if (this.m_HostForm.ShowInTaskbar)
                this.m_HostForm.WindowState = FormWindowState.Minimized;
            else
                this.m_HostForm.Hide();

        }

        protected override GraphicsPath CreateFlagPath(Rectangle rect)
        {
            PointF tf = new PointF(rect.X + (((float)rect.Width) / 2f), rect.Y + (((float)rect.Height) / 2f));
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(tf.X - 6f, tf.Y + 1f, 12f, 3f));
            return path;
        }
    }
}
