using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Client.UI.Base.Forms
{
    public class FormBase:Form
    {
        protected bool m_Active;
        protected Rectangle m_DeltaRect;

        public bool Active { get { return m_Active; } }

        public Rectangle DeltaRect
        {
            get { return m_DeltaRect; }
        }

        public event Client.UI.Base.Render.TitleRender.TitleButtonOnClickHandler TitleButtonOnClick;

        public void OnTitleButtonClick(object sender, Point mousePoint)
        {
            if (TitleButtonOnClick != null)
                TitleButtonOnClick(sender, mousePoint);
        }
    }
}
