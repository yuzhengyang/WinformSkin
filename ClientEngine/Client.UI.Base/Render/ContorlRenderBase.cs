using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Client.UI.Base.Configs;
using Client.UI.Base.Forms;

namespace Client.UI.Base.Render
{
    public abstract class ContorlRenderBase<THostForm>
        where THostForm:FormBase
    {
        protected THostForm m_HostForm = null;
        public void SetHostForm(THostForm form)
        {
            this.m_HostForm = form;
            this.InitConfig();
        }

        public abstract void Render(Graphics g);

        public abstract void InitConfig();
    }
}
