using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Client.UI.Base.Forms.Title;
using Client.UI.Base.Render;

namespace Client.Winform.SystemWatcher.UI.Render
{
    public class NormalTitleRender : TitleRender
    {
        public override void AddCustomButtons()
        {
            Image tempImg = null;
            try
            {
                tempImg = Properties.Resources.title_button_close;
                this.AddButton(new CloseButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(6, -1),
                    TitleBoxSize = new Size(47, 22),
                    NormalImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 47, 22, 3),
                    HoverImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 47, 22, 2),
                    PressedImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 47, 22, 1)
                });


                tempImg = Properties.Resources.title_button_max;
                Image tempImg2 = Properties.Resources.title_button_restore;
                this.AddButton(new MaximizeButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(53, -1),
                    TitleBoxSize = new Size(33, 22),
                    NormalImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 3),
                    HoverImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 2),
                    PressedImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 1),
                    MaxNormalImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg2, 33, 22, 3),
                    MaxHoverImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg2, 33, 22, 2),
                    MaxPressedImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg2, 33, 22, 1),
                });

                tempImg = Properties.Resources.title_button_min2;
                this.AddButton(new MinimizeButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(86, -1),
                    TitleBoxSize = new Size(33, 22),
                    NormalImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 3),
                    HoverImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 2),
                    PressedImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 1)
                });

                
            }
            catch
            { }
        }
    }
}
