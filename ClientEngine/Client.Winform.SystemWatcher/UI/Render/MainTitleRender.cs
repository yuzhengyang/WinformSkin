using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Client.UI.Base.Forms.Title;
using Client.UI.Base.Render;

namespace Client.Winform.SystemWatcher.UI.Render
{
    public class MainTitleRender: TitleRender
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

                tempImg = Properties.Resources.title_button_min;
                this.AddButton(new MinimizeButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(86, -1),
                    TitleBoxSize = new Size(33, 22),
                    NormalImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 3),
                    HoverImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 2),
                    PressedImage = Client.UI.Base.Utils.ImageUtils.GetImageIndex(tempImg, 33, 22, 1)
                });

                tempImg = Properties.Resources.title_button_menuChose;
                this.AddButton(new MenuButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(119, -1),
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

    public class MenuButton : TitleButton
    {
        public MenuButton(Form form) :
            base(form)
        {
            this.TitleBoxOffset = new Point(70, 0);
        }

        public override void ButtonPressed(Point mousePoint)
        {
            //if (this.m_HostForm.ShowInTaskbar)
            //    this.m_HostForm.WindowState = FormWindowState.Minimized;
            //else
            //    this.m_HostForm.Hide();
        }

        protected override GraphicsPath CreateFlagPath(Rectangle rect)
        {
            PointF tf = new PointF(rect.X + (((float)rect.Width) / 2f), rect.Y + (((float)rect.Height) / 2f));
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(tf.X - 6f, tf.Y + 1f, 12f, 3f));
            return path;
        }
    }
}
