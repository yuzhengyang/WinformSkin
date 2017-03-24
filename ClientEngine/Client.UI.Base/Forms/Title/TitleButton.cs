using System;
using System.Collections.Generic;
using System.Text;
using Client.UI.Base.Enums;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Client.UI.Base.Forms.Title
{
    public abstract class TitleButton
    {


        private Size m_TitleBoxSize = new Size(32, 18);
        protected Dictionary<bool, Dictionary<ButtonStatus, Image>> m_MoveActionImageContainer = new Dictionary<bool, Dictionary<ButtonStatus, Image>>();

        public Image CurrentStatuImage
        {
            get { return m_MoveActionImageContainer[GetButtonIsInMaxStatu()][this.m_State]; }
        }



        public Size TitleBoxSize
        {
            get { return m_TitleBoxSize; }
            set { m_TitleBoxSize = value; }
        }

        protected Form m_HostForm = null;
        public ButtonStatus m_State;
        public ButtonStatus State
        {
            get { return m_State; }

            set
            {
                if (this.m_State != value)
                {
                    this.m_State = value;
                    this.m_HostForm.Invalidate(TitleBoxRect);
                }
            }
        }


        private Point m_TitleBoxOffset = new Point(6, 0);
        public Point TitleBoxOffset
        {
            get
            {
                return m_TitleBoxOffset;
            }
            set
            {
                m_TitleBoxOffset = value;
            }
        }


        public Rectangle TitleBoxRect
        {
            get
            {
                return new Rectangle((this.m_HostForm.Width - m_TitleBoxOffset.X) - m_TitleBoxSize.Width, m_TitleBoxOffset.Y, m_TitleBoxSize.Width, m_TitleBoxSize.Height);
            }
        }



        public Image NormalImage
        {
            set
            {
                if (value != null)
                    this.m_MoveActionImageContainer[false][ButtonStatus.Normal] = value;
            }
        }
        public Image HoverImage
        {
            set
            {
                if (value != null)
                    this.m_MoveActionImageContainer[false][ButtonStatus.Hover] = value;
            }
        }
        public Image PressedImage
        {
            set
            {
                if (value != null)
                    this.m_MoveActionImageContainer[false][ButtonStatus.Pressed] = value;
            }
        }
        //public string ToolTip { get; set; }

        public TitleButton(Form form)
        {
            this.m_HostForm = form;
            Dictionary<ButtonStatus, Image> noMaxStatuDict = new Dictionary<ButtonStatus, Image>();
            noMaxStatuDict.Add(ButtonStatus.Normal, DrawNoMaxStatuBoxImage(Color.FromArgb(0x33, 0x99, 0xcc)));
            noMaxStatuDict.Add(ButtonStatus.Hover, DrawNoMaxStatuBoxImage(Color.FromArgb(150, 0x27, 0xaf, 0xe7)));
            noMaxStatuDict.Add(ButtonStatus.Pressed, DrawNoMaxStatuBoxImage(Color.FromArgb(150, 0x1d, 0x8e, 190)));
            noMaxStatuDict.Add(ButtonStatus.PressedLeave, DrawNoMaxStatuBoxImage(Color.FromArgb(150, 0x1d, 0x8e, 190)));
            this.m_MoveActionImageContainer.Add(false, noMaxStatuDict);

            Dictionary<ButtonStatus, Image> hasMaxStatuDict = new Dictionary<ButtonStatus, Image>();
            hasMaxStatuDict.Add(ButtonStatus.Normal, DrawHasMaxStatuBoxImage(Color.FromArgb(0x33, 0x99, 0xcc)));
            hasMaxStatuDict.Add(ButtonStatus.Hover, DrawHasMaxStatuBoxImage(Color.FromArgb(150, 0x27, 0xaf, 0xe7)));
            hasMaxStatuDict.Add(ButtonStatus.Pressed, DrawHasMaxStatuBoxImage(Color.FromArgb(150, 0x1d, 0x8e, 190)));
            hasMaxStatuDict.Add(ButtonStatus.PressedLeave, DrawHasMaxStatuBoxImage(Color.FromArgb(150, 0x1d, 0x8e, 190)));
            this.m_MoveActionImageContainer.Add(true, hasMaxStatuDict);

        }

        public abstract void ButtonPressed(Point mousePoint);


        public Image DrawNoMaxStatuBoxImage(Color drawColor)
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
            using (GraphicsPath path = this.CreateFlagPath(rect))
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

        public virtual Image DrawHasMaxStatuBoxImage(Color drawColor)
        {
            return null;
        }

        protected virtual bool GetButtonIsInMaxStatu()
        {
            return false;
        }

        protected virtual GraphicsPath CreateFlagPath(Rectangle rect)
        {
            PointF tf = new PointF(rect.X + (((float)rect.Width) / 2f), rect.Y + (((float)rect.Height) / 2f));
            GraphicsPath path = new GraphicsPath();
            path.AddLine(tf.X, tf.Y - 2f, tf.X - 2f, tf.Y - 4f);
            path.AddLine((float)(tf.X - 2f), (float)(tf.Y - 4f), (float)(tf.X - 6f), (float)(tf.Y - 4f));
            path.AddLine(tf.X - 6f, tf.Y - 4f, tf.X - 2f, tf.Y);
            path.AddLine(tf.X - 2f, tf.Y, tf.X - 6f, tf.Y + 4f);
            path.AddLine((float)(tf.X - 6f), (float)(tf.Y + 4f), (float)(tf.X - 2f), (float)(tf.Y + 4f));
            path.AddLine(tf.X - 2f, tf.Y + 4f, tf.X, tf.Y + 2f);
            path.AddLine(tf.X, tf.Y + 2f, tf.X + 2f, tf.Y + 4f);
            path.AddLine((float)(tf.X + 2f), (float)(tf.Y + 4f), (float)(tf.X + 6f), (float)(tf.Y + 4f));
            path.AddLine(tf.X + 6f, tf.Y + 4f, tf.X + 2f, tf.Y);
            path.AddLine(tf.X + 2f, tf.Y, tf.X + 6f, tf.Y - 4f);
            path.AddLine((float)(tf.X + 6f), (float)(tf.Y - 4f), (float)(tf.X + 2f), (float)(tf.Y - 4f));
            path.CloseFigure();
            return path;
        }
    }
}
