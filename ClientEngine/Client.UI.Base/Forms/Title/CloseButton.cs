using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Client.UI.Base.Enums;
using System.Drawing;

namespace Client.UI.Base.Forms.Title
{
    public class CloseButton : TitleButton
    {
        public CloseButton(Form form) :
            base(form)
        {
            this.m_MoveActionImageContainer[false][ButtonStatus.Hover] = DrawNoMaxStatuBoxImage(Color.FromArgb(0xd5, 0x42, 0x16));
            this.m_MoveActionImageContainer[false][ButtonStatus.Pressed] = DrawNoMaxStatuBoxImage(Color.FromArgb(0xab, 0x35, 0x11));
        }

        public override void ButtonPressed(Point mousePoint)
        {
            this.m_HostForm.Close();
        }
    }
}
