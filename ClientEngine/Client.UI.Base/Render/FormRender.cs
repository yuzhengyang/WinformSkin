using System;
using System.Collections.Generic;
using System.Text;
using Client.UI.Base.Forms;
using System.Drawing;
using System.Windows.Forms;
using Client.UI.Base.Configs;
using Client.UI.Base.Enums;
using System.Drawing.Drawing2D;

namespace Client.UI.Base.Render
{
    public abstract class FormRender : ContorlRenderBase<FormBase>,IDisposable
    {

        private FormRenderConfig m_Rconfig = null;
        private ShadowForm m_ShadowForm = null;

        internal Rectangle FormTextRect
        {
            get
            {
                if (m_HostForm.Text.Length != 0 && m_Rconfig.FormTextRect == Rectangle.Empty)
                {
                    return new Rectangle(m_Rconfig.IconRect.Right + 2, 9, m_HostForm.Width - (8 + m_Rconfig.IconRect.Width + 2), m_HostForm.Font.Height);
                }
                return m_Rconfig.FormTextRect;
            }
        }

        public Rectangle RealClientRect
        {
            get
            {
                if ( m_HostForm.WindowState == FormWindowState.Maximized)
                {
                    return new Rectangle(m_HostForm.DeltaRect.X, m_HostForm.DeltaRect.Y, m_HostForm.Width - m_HostForm.DeltaRect.Width, m_HostForm.Height - m_HostForm.DeltaRect.Height);
                }
                return new Rectangle(System.Drawing.Point.Empty, m_HostForm.Size);
            }
        }

        public bool CanResize
        {
            get { return m_Rconfig.CanResize; }
        }

        public override void Render(Graphics g)
        {
            if (m_Rconfig.IconRect != Rectangle.Empty)
                g.DrawIcon(m_HostForm.Icon, m_Rconfig.IconRect);
            if (m_HostForm.Text.Length != 0)
                TextRenderer.DrawText(g, m_HostForm.Text, m_HostForm.Font, FormTextRect, m_Rconfig.FormTextColor, TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
            if (m_Rconfig.IsShowBorder)
                DrawBorder(g, RealClientRect, m_Rconfig.RoundStyle, m_Rconfig.Radius);
        }

        private void DrawBorder(Graphics g, Rectangle formRect, RoundStyle roundStyle, int radius)
        {
            Rectangle rect = formRect;
            g.SmoothingMode = SmoothingMode.HighQuality;
            rect.Width--;
            rect.Height--;
            using (GraphicsPath path = Utils.GraphicUtils.CreatePath(rect, radius, roundStyle, false))
            {
                using (Pen pen = new Pen(Color.FromArgb(100, 0, 0, 0)))
                {
                    g.DrawPath(pen, path);
                }
            }
            rect.Inflate(-1, -1);
            using (GraphicsPath path2 = Utils.GraphicUtils.CreatePath(rect, radius, roundStyle, false))
            {
                using (Pen pen2 = new Pen( Color.FromArgb(100, 250, 250, 250)))
                {
                    g.DrawPath(pen2, path2);
                }
            }
        }

        public override void InitConfig()
        {
            m_Rconfig = new FormRenderConfig();
            FormRenderConfigInit(m_Rconfig);
        }

        public abstract void FormRenderConfigInit(FormRenderConfig config);

        /// <summary>
        /// 定义圆角的弧度
        /// </summary>
        public void SetReion()
        {
            if (m_HostForm.Region != null)
                m_HostForm.Region.Dispose();
            Client.UI.Base.Utils.GraphicUtils.CreateRegion(m_HostForm, RealClientRect, m_Rconfig.Radius, m_Rconfig.RoundStyle);
        }

        public void RenderShadow()
        {
            if (m_Rconfig.IsShowShadow && m_ShadowForm == null)
            {
                m_ShadowForm = new ShadowForm(m_HostForm, m_Rconfig);
                m_ShadowForm.Show();
            }
        }

        public void Dispose()
        {
            if (m_ShadowForm != null)
                m_ShadowForm.Close();
        }
    }
}
