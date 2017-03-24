using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Client.UI.Base.Enums;

namespace Client.UI.Base.Forms.Title
{
    public class MaximizeButton : TitleButton
    {

        public Image MaxNormalImage
        {
            set
            {
                if (value != null)
                    this.m_MoveActionImageContainer[true][ButtonStatus.Normal] = value;
            }
        }
        public Image MaxHoverImage
        {
            set
            {
                if (value != null)
                    this.m_MoveActionImageContainer[true][ButtonStatus.Hover] = value;
            }
        }
        public Image MaxPressedImage
        {
            set
            {
                if (value != null)
                    this.m_MoveActionImageContainer[true][ButtonStatus.Pressed] = value;
            }
        }

        public MaximizeButton(Form form) :
            base(form)
        {
            this.TitleBoxOffset = new Point(38, 0);
        }

        public override void ButtonPressed(Point mousePoint)
        {
            if (this.m_HostForm.WindowState == FormWindowState.Maximized)
                this.m_HostForm.WindowState = FormWindowState.Normal;
            else
                this.m_HostForm.WindowState = FormWindowState.Maximized;
            this.m_HostForm.Invalidate();
        }

        public override Image DrawHasMaxStatuBoxImage(Color drawColor)
        {
            Rectangle rect = new Rectangle(0, 0, this.TitleBoxRect.Width, this.TitleBoxRect.Height);
            Bitmap image = new Bitmap(this.TitleBoxRect.Width, this.TitleBoxRect.Height);
            Graphics g = Graphics.FromImage(image);
            RoundStyle style = RoundStyle.None;
            Base.Utils.GraphicUtils.RenderBackgroundInternal(g, rect, drawColor, drawColor, Color.FromArgb(0x80, 250, 250, 250), style, 6, 0.38f, true, false, LinearGradientMode.Vertical);
            using (Pen pen = new Pen(Color.FromArgb(100, 0, 0, 0)))
            {
                g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
            }
            using (GraphicsPath path = this.CreateFlagPath(rect, true))
            {
                g.FillPath(Brushes.White, path);
                using (Pen pen2 = new Pen(drawColor))
                {
                    g.DrawPath(pen2, path);
                }
            }
            g.Dispose();
            return image;
        }

        protected override bool GetButtonIsInMaxStatu()
        {
            return this.m_HostForm.WindowState == FormWindowState.Maximized ? true : false;
        }

        protected override GraphicsPath CreateFlagPath(Rectangle rect)
        {
            return CreateFlagPath(rect, false);
        }

        protected GraphicsPath CreateFlagPath(Rectangle rect, bool Maximized)
        {
            PointF tf = new PointF(rect.X + (((float)rect.Width) / 2f), rect.Y + (((float)rect.Height) / 2f));
            GraphicsPath path = new GraphicsPath();
            if (Maximized)
            {
                path.AddLine((float)(tf.X - 3f), (float)(tf.Y - 3f), (float)(tf.X - 6f), (float)(tf.Y - 3f));
                path.AddLine((float)(tf.X - 6f), (float)(tf.Y - 3f), (float)(tf.X - 6f), (float)(tf.Y + 5f));
                path.AddLine((float)(tf.X - 6f), (float)(tf.Y + 5f), (float)(tf.X + 3f), (float)(tf.Y + 5f));
                path.AddLine((float)(tf.X + 3f), (float)(tf.Y + 5f), (float)(tf.X + 3f), (float)(tf.Y + 1f));
                path.AddLine((float)(tf.X + 3f), (float)(tf.Y + 1f), (float)(tf.X + 6f), (float)(tf.Y + 1f));
                path.AddLine((float)(tf.X + 6f), (float)(tf.Y + 1f), (float)(tf.X + 6f), (float)(tf.Y - 6f));
                path.AddLine((float)(tf.X + 6f), (float)(tf.Y - 6f), (float)(tf.X - 3f), (float)(tf.Y - 6f));
                path.CloseFigure();
                path.AddRectangle(new RectangleF(tf.X - 4f, tf.Y, 5f, 3f));
                path.AddLine((float)(tf.X - 1f), (float)(tf.Y - 4f), (float)(tf.X + 4f), (float)(tf.Y - 4f));
                path.AddLine((float)(tf.X + 4f), (float)(tf.Y - 4f), (float)(tf.X + 4f), (float)(tf.Y - 1f));
                path.AddLine((float)(tf.X + 4f), (float)(tf.Y - 1f), (float)(tf.X + 3f), (float)(tf.Y - 1f));
                path.AddLine((float)(tf.X + 3f), (float)(tf.Y - 1f), (float)(tf.X + 3f), (float)(tf.Y - 3f));
                path.AddLine((float)(tf.X + 3f), (float)(tf.Y - 3f), (float)(tf.X - 1f), (float)(tf.Y - 3f));
                path.CloseFigure();
                return path;
            }
            path.AddRectangle(new RectangleF(tf.X - 6f, tf.Y - 4f, 12f, 8f));
            path.AddRectangle(new RectangleF(tf.X - 3f, tf.Y - 1f, 6f, 3f));
            return path;
        }
    }
}
