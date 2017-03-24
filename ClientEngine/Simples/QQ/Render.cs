using System;
using System.Collections.Generic;
using System.Text;
using Client.UI.Base.Render;
using System.Drawing;
using Client.UI.Base.Forms.Title;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Client.UI.Render;

namespace Simples.QQ
{


    public class QQTitleRender : TitleRender
    {


        public override void AddCustomButtons()
        {
            Image tempImg = null;
            try
            {

                this.AddButton(new CloseButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(0, 0),
                    TitleBoxSize = new Size(39,20),
                    NormalImage = Bitmap.FromFile(@".\Res\SystemButton\close_normal.png"),
                    HoverImage = Bitmap.FromFile(@".\Res\SystemButton\close_highlight.png"),
                    PressedImage = Bitmap.FromFile(@".\Res\SystemButton\close_press.png")
                });

                this.AddButton(new MaximizeButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(39, 0),
                    TitleBoxSize = new Size(28, 20),
                    NormalImage = Bitmap.FromFile(@".\Res\SystemButton\max_normal.png"),
                    HoverImage = Bitmap.FromFile(@".\Res\SystemButton\max_highlight.png"),
                    PressedImage = Bitmap.FromFile(@".\Res\SystemButton\max_press.png"),
                    MaxNormalImage = Bitmap.FromFile(@".\Res\SystemButton\restore_normal.png"),
                    MaxHoverImage = Bitmap.FromFile(@".\Res\SystemButton\restore_highlight.png"),
                    MaxPressedImage = Bitmap.FromFile(@".\Res\SystemButton\restore_press.png")
                });

                this.AddButton(new MinimizeButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(67, 0),
                    TitleBoxSize = new Size(28, 20),
                    NormalImage = Bitmap.FromFile(@".\Res\SystemButton\min_normal.png"),
                    HoverImage = Bitmap.FromFile(@".\Res\SystemButton\min_highlight.png"),
                    PressedImage = Bitmap.FromFile(@".\Res\SystemButton\min_press.png")
                });

                this.AddButton(new MenuButton(m_HostForm)
                {
                    TitleBoxOffset = new Point(95, 0),
                    TitleBoxSize = new Size(28, 22),
                    NormalImage = Bitmap.FromFile(@".\Res\SystemButton\setup_normal.png"),
                    HoverImage = Bitmap.FromFile(@".\Res\SystemButton\setup_highlight.png"),
                    PressedImage = Bitmap.FromFile(@".\Res\SystemButton\setup_press.png")
                });

                //this.AddButton(new SkinChoseButton(m_HostForm)
                //{
                //    TitleBoxOffset = new Point(119, -1),
                //    TitleBoxSize = new Size(33, 22),
                //    NormalImage = Bitmap.FromFile(@".\Res\SystemButton\"),
                //    HoverImage = Bitmap.FromFile(@".\Res\SystemButton\"),
                //    PressedImage = Bitmap.FromFile(@".\Res\SystemButton\")
                //});
            }
            catch
            { }
        }
    }

    public class SkinChoseButton : TitleButton
    {
        public SkinChoseButton(Form form) :
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

    public class MenuButton : TitleButton
    {
        public MenuButton(Form form) :
            base(form)
        {
            this.TitleBoxOffset = new Point(70, 0);
        }

        public override void ButtonPressed(Point mousePoint)
        {

        }

        protected override GraphicsPath CreateFlagPath(Rectangle rect)
        {
            PointF tf = new PointF(rect.X + (((float)rect.Width) / 2f), rect.Y + (((float)rect.Height) / 2f));
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(tf.X - 6f, tf.Y + 1f, 12f, 3f));
            return path;
        }
    }

    public class QQCustomForm:Client.UI.Forms.UIForm<DefaultFormRender,QQTitleRender>
    {

    }
}
