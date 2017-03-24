using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Client.Winform.SystemWatcher.UI.Render
{
    public class MainFormRender : Client.UI.Base.Render.FormRender
    {
        public override void FormRenderConfigInit(Client.UI.Base.Configs.FormRenderConfig config)
        {
            config.IsShowShadow = false;
            config.IconRect = new Rectangle(5, 5, 20, 20);
        }
    }
}
