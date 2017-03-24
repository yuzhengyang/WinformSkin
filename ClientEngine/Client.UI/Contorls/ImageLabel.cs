using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Client.UI.DefaultResource;
using System.ComponentModel;
using System.Windows.Forms;

namespace Client.UI.Contorls
{
    public class ImageLabel : System.Windows.Forms.Control
    {
        private Rectangle m_TextRect = Rectangle.Empty;

        protected Rectangle TextRect
        {
            get
            {
                if (m_TextRect == Rectangle.Empty)
                {
                    int startXPoint=m_IconPosition.X + Icon.Width;
                    return new Rectangle(startXPoint + 2, 3, this.Width-startXPoint , this.Height);
                }
                return m_TextRect;
            }
        }

        //private Size m_TextPositionSize = new Size(200, 20);

        //public Size TextPositionSize
        //{
        //    get { return m_TextPositionSize; }
        //    set
        //    {

        //        this.Invalidate(TextRect);
        //    }
        //}

        //private string m_Text = "Text";

        //public string Text
        //{
        //    get { return m_Text; }
        //    set { m_Text = value; }
        //}

        private Font m_TextFont = SystemFonts.CaptionFont;

        public Font TextFont
        {
            get { return m_TextFont; }
            set { m_TextFont = value; }
        }

        private Rectangle m_IconPosition = new Rectangle(2, 2, 17, 17);

        public Rectangle IconPosition
        {
            get { return m_IconPosition; }
            set { m_IconPosition = value; }
        }


        private Image m_Icon =null;

        [Description("该文本的图片"), Category("Skin")]
        public Image Icon
        {
            get
            {
                if (m_Icon == null)
                    m_Icon = GetDefaultResource.GetImage("Common.none.png");
                return m_Icon;
            }
            set { m_Icon = value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            this.Invalidate(TextRect);
            base.OnTextChanged(e);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(Icon, m_IconPosition);
            TextRenderer.DrawText(graphics, this.Text, m_TextFont, TextRect, Color.Black, TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);

            base.OnPaint(e);
        }
    }
}
