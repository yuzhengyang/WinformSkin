using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.UI.Forms;
using Client.UI.Base.Render;
using Simples.Render;
using Client.UI.Render;
using Client.UI.Base.Enums;
using Client.UI.Base.Utils;

namespace Simples
{
    public  class CustomForm : UIForm<DefaultFormRender, CustomTitleRender>
    {
        public CustomForm()
        {
        }

        #region override

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (e.Clicks == 1))
            {
                if (m_TitleButtonRender.IsInTitleRegion(e.Location))
                {
                    this.m_TitleButtonRender.ProcessMouseOperate(e.Location, MouseOperate.Down);
                    return;
                }
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(base.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HTCAPTION, 0);
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            this.m_TitleButtonRender.ProcessMouseOperate(base.PointToClient(System.Windows.Forms.Control.MousePosition), MouseOperate.Hover);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.m_TitleButtonRender.ProcessMouseOperate(System.Drawing.Point.Empty, MouseOperate.Leave);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.m_TitleButtonRender.ProcessMouseOperate(e.Location, MouseOperate.Move);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.m_TitleButtonRender.ProcessMouseOperate(e.Location, MouseOperate.Up);
        }

        #endregion
    }
}
