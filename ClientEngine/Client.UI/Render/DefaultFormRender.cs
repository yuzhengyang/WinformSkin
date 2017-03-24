using System;
using System.Collections.Generic;
using System.Text;
using Client.UI.Base.Render;
using System.Drawing;
using Client.UI.Base.Forms;
using Client.UI.Base.Configs;

namespace Client.UI.Render
{
    public class DefaultFormRender :FormRender
    {
        public override void FormRenderConfigInit(FormRenderConfig config)
        {
            config.IconRect = new Rectangle(5, 5, 20, 20);
            //config.FormTextRect = new Rectangle(25, 9, 50, 20);
            config.IsShowShadow = true;
        }
    }
}
