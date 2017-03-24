using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Client.UI.Base.Configs;
using Client.UI.Base.Utils;
using System.Runtime.InteropServices;

namespace Client.UI.Base.Forms
{
    public class ShadowForm : Form
    {
        private FormBase m_HostForm;
        private FormRenderConfig m_Config;

        public Color[] CornerColors = new Color[] { Color.FromArgb(180, Color.Black), Color.Transparent };
        public Color[] ShadowColors = new Color[] { Color.FromArgb(60, Color.Black), Color.Transparent };
        public ShadowForm(FormBase main, FormRenderConfig config)
        {
            this.m_HostForm = main;
            m_Config = config;
            this.SetStyles();
            this.Init();
        }

        private void CanPenetrate()
        {
            NativeMethods.GetWindowLong(base.Handle, -20);
            NativeMethods.SetWindowLong(base.Handle, -20, 0x80020);
        }

        private void DrawCorners(Graphics g, System.Drawing.Size corSize)
        {
            Action<int> action = delegate(int n)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    System.Drawing.Point point;
                    System.Drawing.Point point3;
                    System.Drawing.Point point4;
                    PointF tf;
                    float num;
                    System.Drawing.Size size = new System.Drawing.Size(corSize.Width * 2, corSize.Height * 2);
                    System.Drawing.Size size2 = new System.Drawing.Size(m_Config.Radius * 2, m_Config.Radius * 2);
                    switch (n)
                    {
                        case 1:
                            point = new System.Drawing.Point(0, 0);
                            num = 180f;
                            tf = new PointF(size.Width - (size2.Width * 0.5f), size.Height - (size2.Height * 0.5f));
                            point3 = new System.Drawing.Point(corSize.Width, m_Config.ShadowWidth);
                            point4 = new System.Drawing.Point(m_Config.ShadowWidth, corSize.Height);
                            break;

                        case 3:
                            point = new System.Drawing.Point(this.Width - size.Width, 0);
                            num = 270f;
                            tf = new PointF(point.X + (size2.Width * 0.5f), size.Height - (size2.Height * 0.5f));
                            point3 = new System.Drawing.Point(this.Width - m_Config.ShadowWidth, corSize.Height);
                            point4 = new System.Drawing.Point(this.Width - corSize.Width, m_Config.ShadowWidth);
                            break;

                        case 7:
                            point = new System.Drawing.Point(0, this.Height - size.Height);
                            num = 90f;
                            tf = new PointF(size.Width - (size2.Width * 0.5f), point.Y + (size2.Height * 0.5f));
                            point3 = new System.Drawing.Point(m_Config.ShadowWidth, this.Height - corSize.Height);
                            point4 = new System.Drawing.Point(corSize.Width, this.Height - m_Config.ShadowWidth);
                            break;

                        default:
                            point = new System.Drawing.Point(this.Width - size.Width, this.Height - size.Height);
                            num = 0f;
                            tf = new PointF(point.X + (size2.Width * 0.5f), point.Y + (size2.Height * 0.5f));
                            point3 = new System.Drawing.Point(this.Width - corSize.Width, this.Height - m_Config.ShadowWidth);
                            point4 = new System.Drawing.Point(this.Width - m_Config.ShadowWidth, this.Height - corSize.Height);
                            break;
                    }
                    Rectangle rect = new Rectangle(point, size);
                    System.Drawing.Point location = new System.Drawing.Point(point.X + ((size.Width - size2.Width) / 2), point.Y + ((size.Height - size2.Height) / 2));
                    Rectangle rectangle2 = new Rectangle(location, size2);
                    path.AddArc(rect, num, 91f);
                    if (m_Config.Radius > 3)
                    {
                        path.AddArc(rectangle2, num + 90f, -91f);
                    }
                    else
                    {
                        path.AddLine(point3, point4);
                    }
                    using (PathGradientBrush brush = new PathGradientBrush(path))
                    {
                        Color[] colorArray = new Color[2];
                        float[] numArray = new float[2];
                        ColorBlend blend = new ColorBlend();
                        colorArray[0] = this.CornerColors[1];
                        colorArray[1] = this.CornerColors[0];
                        numArray[0] = 0f;
                        numArray[1] = 1f;
                        blend.Colors = colorArray;
                        blend.Positions = numArray;
                        brush.InterpolationColors = blend;
                        brush.CenterPoint = tf;
                        g.FillPath(brush, path);
                    }
                }
            };
            action(1);
            action(3);
            action(7);
            action(9);
        }

        private void DrawLines(Graphics g, System.Drawing.Size corSize, System.Drawing.Size gradientSize_LR, System.Drawing.Size gradientSize_TB)
        {
            Rectangle rect = new Rectangle(new System.Drawing.Point(corSize.Width, 0), gradientSize_TB);
            Rectangle rectangle2 = new Rectangle(new System.Drawing.Point(0, corSize.Width), gradientSize_LR);
            Rectangle rectangle3 = new Rectangle(new System.Drawing.Point(base.Size.Width - m_Config.ShadowWidth, corSize.Width), gradientSize_LR);
            Rectangle rectangle4 = new Rectangle(new System.Drawing.Point(corSize.Width, base.Size.Height - m_Config.ShadowWidth), gradientSize_TB);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, this.ShadowColors[1], this.ShadowColors[0], LinearGradientMode.Vertical))
            {
                using (LinearGradientBrush brush2 = new LinearGradientBrush(rectangle2, this.ShadowColors[1], this.ShadowColors[0], LinearGradientMode.Horizontal))
                {
                    using (LinearGradientBrush brush3 = new LinearGradientBrush(rectangle3, this.ShadowColors[0], this.ShadowColors[1], LinearGradientMode.Horizontal))
                    {
                        using (LinearGradientBrush brush4 = new LinearGradientBrush(rectangle4, this.ShadowColors[0], this.ShadowColors[1], LinearGradientMode.Vertical))
                        {
                            g.FillRectangle(brush, rect);
                            g.FillRectangle(brush2, rectangle2);
                            g.FillRectangle(brush3, rectangle3);
                            g.FillRectangle(brush4, rectangle4);
                        }
                    }
                }
            }
        }

        private void DrawShadow(Graphics g)
        {
            this.ShadowColors[0] = Color.FromArgb(60, Color.Black);
            this.CornerColors[0] = Color.FromArgb(180, Color.Black);
            System.Drawing.Size corSize = new System.Drawing.Size(m_Config.ShadowWidth + m_Config.Radius, m_Config.ShadowWidth + m_Config.Radius);
            System.Drawing.Size size2 = new System.Drawing.Size(m_Config.ShadowWidth, base.Size.Height - (corSize.Height * 2));
            System.Drawing.Size size3 = new System.Drawing.Size(base.Size.Width - (corSize.Width * 2), m_Config.ShadowWidth);
            this.DrawLines(g, corSize, size2, size3);
            this.DrawCorners(g, corSize);
        }

        private void Init()
        {
            base.TopMost = this.m_HostForm.TopMost;
            this.m_HostForm.BringToFront();
            base.ShowInTaskbar = false;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new System.Drawing.Point(this.m_HostForm.Location.X - m_Config.ShadowWidth, this.m_HostForm.Location.Y - m_Config.ShadowWidth);
            base.Icon = this.m_HostForm.Icon;
            base.ShowIcon = this.m_HostForm.ShowIcon;
            base.Width = this.m_HostForm.Width + (m_Config.ShadowWidth * 2);
            base.Height = this.m_HostForm.Height + (m_Config.ShadowWidth * 2);
            this.Text = this.m_HostForm.Text;
            this.m_HostForm.LocationChanged += new EventHandler(this.m_HostForm_LocationChanged);
            this.m_HostForm.SizeChanged += new EventHandler(this.m_HostForm_SizeChanged);
            this.m_HostForm.VisibleChanged += new EventHandler(this.m_HostForm_VisibleChanged);
            this.SetBits();
            this.CanPenetrate();
        }



        private void m_HostForm_LocationChanged(object sender, EventArgs e)
        {
            base.Location = new System.Drawing.Point(this.m_HostForm.Left - m_Config.ShadowWidth, this.m_HostForm.Top - m_Config.ShadowWidth);
        }

        private void m_HostForm_SizeChanged(object sender, EventArgs e)
        {
            base.Width = this.m_HostForm.Width + (m_Config.ShadowWidth * 2);
            base.Height = this.m_HostForm.Height + (m_Config.ShadowWidth * 2);
            this.SetBits();
        }

        private void m_HostForm_VisibleChanged(object sender, EventArgs e)
        {
            base.Visible = this.m_HostForm.Visible;
        }

        public void SetBits()
        {
            Bitmap image = new Bitmap(this.m_HostForm.Width + (m_Config.ShadowWidth * 2), this.m_HostForm.Height + (m_Config.ShadowWidth * 2));
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            this.DrawShadow(g);
            if (Image.IsCanonicalPixelFormat(image.PixelFormat) && Image.IsAlphaPixelFormat(image.PixelFormat))
            {
                IntPtr zero = IntPtr.Zero;
                //diff
                //IntPtr dC = NativeMethods.GetDC(new HandleRef(null, IntPtr.Zero));
                IntPtr dC = NativeMethods.GetDC(IntPtr.Zero);
                IntPtr hgdiobj = IntPtr.Zero;
                //diff
                //IntPtr hdc = NativeMethods.CreateCompatibleDC(new HandleRef(null, dC));
                IntPtr hdc = NativeMethods.CreateCompatibleDC(dC);
                try
                {
                    NativeMethods.POINTSTRUCT pptDst = new NativeMethods.POINTSTRUCT(base.Left, base.Top);
                    NativeMethods.SIZESTRUCT psize = new NativeMethods.SIZESTRUCT(base.Width, base.Height);
                    NativeMethods.BLENDFUNCTION pblend = new NativeMethods.BLENDFUNCTION();
                    NativeMethods.POINTSTRUCT pprSrc = new NativeMethods.POINTSTRUCT(0, 0);
                    hgdiobj = image.GetHbitmap(Color.Red);
                    zero = NativeMethods.SelectObject(hdc, hgdiobj);
                    pblend.BlendOp = 0;
                    pblend.SourceConstantAlpha = byte.Parse("255");
                    pblend.AlphaFormat = 1;
                    pblend.BlendFlags = 0;
                    NativeMethods.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, hdc, ref pprSrc, 0, ref pblend, 2);
                    return;
                }
                finally
                {
                    if (hgdiobj != IntPtr.Zero)
                    {
                        NativeMethods.SelectObject(hdc, zero);
                        NativeMethods.DeleteObject(hgdiobj);
                    }
                    NativeMethods.ReleaseDC(IntPtr.Zero, dC);
                    NativeMethods.DeleteDC(hdc);
                }
            }
            throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
        }

        private void SetStyles()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.UpdateStyles();
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x80000;
                return createParams;
            }
        }
    }
}
