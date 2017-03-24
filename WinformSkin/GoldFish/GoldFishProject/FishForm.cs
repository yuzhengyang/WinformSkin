//##########################################################################
//¡ï¡ï¡ï¡ï¡ï¡ï¡ï           http://www.cnpopsoft.com           ¡ï¡ï¡ï¡ï¡ï¡ï¡ï
//¡ï¡ï          VB & C# source code and articles for free !!!           ¡ï¡ï
//¡ï¡ï¡ï¡ï¡ï¡ï¡ï                Davidwu                       ¡ï¡ï¡ï¡ï¡ï¡ï¡ï
//##########################################################################

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RotateTransformDemo
{
    public partial class FishForm : Form
    {
        Point oldPoint = new Point(0, 0);
        bool mouseDown = false;
        bool haveHandle = false;
        Timer timerSpeed = new Timer();
        int MaxCount = 50;
        float stepX = 2f;
        float stepY = 0f;
        int count = 0;
        bool speedMode = false;
        float left = 0f, top = 0f;

        bool toRight = true;
        int frameCount = 20;
        int frame = 0; 
        int frameWidth = 100;
        int frameHeight = 100; 

        public FishForm()
        {
            InitializeComponent();
            this.TopMost = true;
            toRight = true;
            frame = 20;
            frame = 0;
            frameWidth = FullImage.Width / 20;
            frameHeight = FullImage.Height;
            left = -frameWidth;
            top = Screen.PrimaryScreen.WorkingArea.Height / 2f;

            timerSpeed.Interval = 50;
            timerSpeed.Enabled = true;
            timerSpeed.Tick += new EventHandler(timerSpeed_Tick);

            this.DoubleClick += new EventHandler(Form2_DoubleClick);
            this.MouseDown += new MouseEventHandler(Form2_MouseDown);
            this.MouseUp += new MouseEventHandler(Form2_MouseUp);
            this.MouseMove += new MouseEventHandler(Form2_MouseMove);
        }

        #region Override

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            haveHandle = false;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InitializeStyles();
            base.OnHandleCreated(e);
            haveHandle = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cParms;
            }
        }

        #endregion

        void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            count = 0;
            MaxCount = new Random().Next(70) + 40;
            timerSpeed.Interval = new Random().Next(20) + 2;
            speedMode = true;
            mouseDown = false;
        }

        private void InitializeStyles()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        void timerSpeed_Tick(object sender, EventArgs e)
        {
            if (!mouseDown)
            {
                count++;
                if (count > MaxCount)
                {
                    MaxCount = new Random().Next(70) + 30;
                    if (speedMode) timerSpeed.Interval = 50;

                    count = 0;
                    stepX = (float)new Random().NextDouble() * 3f + 0.5f;
                    stepY = ((float)new Random().NextDouble() - 0.5f) * 0.5f;
                }

                left = (left + (toRight ? 1 : -1) * stepX);
                top = (top + stepY);
                FixLeftTop();
                this.Left = (int)left;
                this.Top = (int)top;
            }
            frame++;
            if (frame >= frameCount) frame = 0;

            SetBits(FrameImage);
        }

        private void FixLeftTop()
        {
            if (toRight && left > Screen.PrimaryScreen.WorkingArea.Width)
            {
                toRight = false;
                frame = 0;
                count = 0;
            }
            else if (!toRight && left < -frameWidth)
            {
                toRight = true;
                frame = 0;
                count = 0;
            }
            if (top < -frameHeight)
            {
                stepY = 1f;
                count = 0;
            }
            else if (top > Screen.PrimaryScreen.WorkingArea.Height)
            {
                stepY = -1f;
                count = 0;
            }
        }

        private Image FullImage
        {
            get
            {
                if (toRight)
                    return RotateTransformDemo.Properties.Resources.Right;
                else
                    return RotateTransformDemo.Properties.Resources.Left;
            }
        }

        public Bitmap FrameImage
        {
            get
            {
                Bitmap bitmap = new Bitmap(frameWidth, frameHeight);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(FullImage, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(frameWidth * frame, 0, frameWidth, frameHeight), GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        void Form2_DoubleClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Left += (e.X - oldPoint.X);
                this.Top += (e.Y - oldPoint.Y);
                left = this.Left;
                top = this.Top;
                FixLeftTop();
            }
        }

        void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) this.Dispose();
            oldPoint = e.Location;
            mouseDown = true;
        }

        public void SetBits(Bitmap bitmap)
        {
            if (!haveHandle) return;

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("The picture must be 32bit picture with alpha channel.");

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }
    }
}