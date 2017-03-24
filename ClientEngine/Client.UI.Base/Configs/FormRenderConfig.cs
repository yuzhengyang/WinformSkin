using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Client.UI.Base.Enums;

namespace Client.UI.Base.Configs
{
    public class FormRenderConfig : RenderConfig
    {

        private Rectangle m_IconRect = Rectangle.Empty;
        private Rectangle m_FormTextRect = Rectangle.Empty;
        private Color m_FormTextColor = Color.Black;
        private int m_Radius = 6;
        private RoundStyle m_RoundStyle = RoundStyle.All;
        private bool m_CanResize = true;
        private bool m_IsShowBorder = true;
        private bool m_IsShowShadow = false;
        private int m_ShadowWidth = 4;


        public Rectangle IconRect
        {
            get { return m_IconRect; }
            set { m_IconRect = value; }
        }

        public Rectangle FormTextRect
        {
            get { return m_FormTextRect; }
            set { m_FormTextRect = value; }
        }

        public Color FormTextColor
        {
            get { return m_FormTextColor; }
            set { m_FormTextColor = value; }
        }

        public int Radius
        {
            get
            {
                return m_Radius;
            }
            set
            {
                m_Radius = value;
            }
        }

        public RoundStyle RoundStyle
        {
            get
            {
                return m_RoundStyle;
            }
            set
            {
                m_RoundStyle = value;
            }
        }

        public bool CanResize
        {
            get { return m_CanResize; }
            set { m_CanResize = value; }
        }

        public bool IsShowBorder
        {
            get { return m_IsShowBorder; }
            set { m_IsShowBorder = value; }
        }

        public int ShadowWidth
        {
            get { return m_ShadowWidth; }
            set { m_ShadowWidth = value; }
        }

        public bool IsShowShadow
        {
            get { return m_IsShowShadow; }
            set { m_IsShowShadow = value; }
        }

    }
}
