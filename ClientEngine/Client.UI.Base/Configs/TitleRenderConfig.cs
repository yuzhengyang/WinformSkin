using System;
using System.Collections.Generic;
using System.Text;
using Client.UI.Base.Forms.Title;

namespace Client.UI.Base.Configs
{
    public class TitleRenderConfig:RenderConfig
    {
        private List<TitleButton> m_ButtonList = new List<TitleButton>();

        public List<TitleButton> ButtonList
        {
            get { return m_ButtonList; }
        }
    }

    public class RenderConfig
    {
 
    }
}
