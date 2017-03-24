using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Winform.SystemWatcher.UI.Render
{
    public class FixedFormRender:Client.UI.Base.Render.FormRender
    {
        public override void FormRenderConfigInit(Client.UI.Base.Configs.FormRenderConfig config)
        {
            config.CanResize = false;
            config.FormTextRect = new System.Drawing.Rectangle(7, 7, this.m_HostForm.Width, this.m_HostForm.Font.Height);
        }
    }
}
