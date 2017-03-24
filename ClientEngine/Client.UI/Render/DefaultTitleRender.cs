using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Client.UI.Base.Enums;
using Client.UI.Base.Render;
using Client.UI.Base.Forms;
using Client.UI.Base.Forms.Title;

namespace Client.UI.Render
{
    public class DefaultTitleRender : TitleRender
    {

        public override void AddCustomButtons()
        {
            this.AddButton(new CloseButton(m_HostForm));
            this.AddButton(new MaximizeButton(m_HostForm));
            this.AddButton(new MinimizeButton(m_HostForm));
        }
    }
}
