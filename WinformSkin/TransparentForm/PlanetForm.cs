using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransparentForm
{
    public partial class PlanetForm : Form
    {
        Point oldPoint = new Point(0, 0);
        bool mouseDown = false;
        bool haveHandle = false;

        private void InitializeStyles()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.UserPaint, true);
            //UpdateStyles();

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Selectable, false);
            UpdateStyles();
        }
        public PlanetForm()
        {
            InitializeComponent();

            Form_MoveEnable();
            Form_CloseEnable();
        }
        private void PlanetForm_Load(object sender, EventArgs e)
        {
            SetBits(new Bitmap(BackgroundImage));
            
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
        #region 任意位置移动窗体位置
        void Form_MoveEnable()
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);
            MouseUp += new MouseEventHandler(Form_MouseUp);
            MouseMove += new MouseEventHandler(Form_MouseMove);
        }
        void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Left += (e.X - oldPoint.X);
                this.Top += (e.Y - oldPoint.Y);
            }
        }
        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) this.Dispose();
            oldPoint = e.Location;
            mouseDown = true;
        }
        #endregion
        #region 关闭窗口
        void Form_CloseEnable()
        {
            DoubleClick += new EventHandler(Form_DoubleClick);
        }
        void Form_DoubleClick(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion

        #region MyRegion
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //DrawTitle(e.Graphics);
            //#region draw caption
            //using (var brush = new SolidBrush(this.CaptionBackgroundColor))
            //{
            //    e.Graphics.FillRectangle(brush, captionRect);
            //}

            //this.DrawTitle(e.Graphics);
            //this.DrawControlBox(e.Graphics);
            //#endregion

            //#region draw border
            //ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
            //#endregion
        }
        #endregion

        private void DrawTitle(Graphics g)
        {
            using (var brush = new SolidBrush(Color.Red))
            {
                g.DrawString("Title", Font, brush, 0, 0);
            }
        }

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case Win32.WM_COMMAND:
        //            Win32.SendMessage(Handle, Win32.WM_SYSCOMMAND, (int)m.WParam, (int)m.LParam);
        //            break;
        //        case Win32.WM_SYSCOMMAND:
        //            base.WndProc(ref m);

        //            if (m.WParam.ToInt64() == Win32.SC_RESTORE)
        //            {
        //                this.Height += 6;
        //                this.Width += 6;
        //                this.btnMaxResore.BackgroundImage = maxBitmap.Clone(new Rectangle(0, 0, 32, 22), PixelFormat.Format64bppPArgb);
        //                this.btnMaxResore.MouseMoveImage = maxBitmap.Clone(new Rectangle(32, 0, 32, 22), PixelFormat.Format64bppPArgb);
        //                this.btnMaxResore.MouseDownImage = maxBitmap.Clone(new Rectangle(64, 0, 32, 22), PixelFormat.Format64bppPArgb);
        //                this.btnMaxResore.Text = "还原";

        //                Shared.ChangeSkinColor(Shared.CurrentSkinColor, this.btnMaxResore, true);
        //            }
        //            else if (m.WParam.ToInt64() == Win32.SC_MAXIMIZE)
        //            {
        //                Application.DoEvents();
        //                this.btnMaxResore.NormalImage = resoreBitmap.Clone(new Rectangle(0, 0, 32, 22), PixelFormat.Format64bppPArgb);
        //                this.btnMaxResore.MouseMoveImage = resoreBitmap.Clone(new Rectangle(32, 0, 32, 22), PixelFormat.Format64bppPArgb);
        //                this.btnMaxResore.MouseDownImage = resoreBitmap.Clone(new Rectangle(64, 0, 32, 22), PixelFormat.Format64bppPArgb);
        //                this.btnMaxResore.ToolTip = "最大化";

        //                Shared.ChangeSkinColor(Shared.CurrentSkinColor, this.btnMaxResore, true);
        //            }

        //            break;
        //        default:
        //            base.WndProc(ref m);
        //            break;
        //    }
        //}
    }
}