using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Client.UI.Base.Animations;
using Client.UI.Base.Enums;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Client.UI.Contorls
{
    internal class DecorationControl : UserControl
    {
        private bool isSnapshotNow;
        private System.Windows.Forms.Timer tm;

        public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded;

        public DecorationControl(DecorationType type, Control decoratedControl)
        {
            this.DecorationType = type;
            this.DecoratedControl = decoratedControl;
            decoratedControl.VisibleChanged += new EventHandler(this.control_VisibleChanged);
            decoratedControl.ParentChanged += new EventHandler(this.control_VisibleChanged);
            decoratedControl.LocationChanged += new EventHandler(this.control_VisibleChanged);
            decoratedControl.Paint += new PaintEventHandler(this.decoratedControl_Paint);
            base.SetStyle(ControlStyles.Selectable, false);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.InitPadding();
            this.tm = new System.Windows.Forms.Timer();
            this.tm.Interval = 100;
            this.tm.Tick += new EventHandler(this.tm_Tick);
            this.tm.Enabled = true;
        }

        private void control_VisibleChanged(object sender, EventArgs e)
        {
            this.Init();
        }

        private void decoratedControl_Paint(object sender, PaintEventArgs e)
        {
            if (!this.isSnapshotNow)
            {
                base.Invalidate();
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.tm.Stop();
            this.tm.Dispose();
            base.Dispose(disposing);
        }

        protected virtual Bitmap GetForeground(Control ctrl)
        {
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            if (!ctrl.IsDisposed)
            {
                this.isSnapshotNow = true;
                ctrl.DrawToBitmap(bitmap, new Rectangle(this.Padding.Left, this.Padding.Top, ctrl.Width, ctrl.Height));
                this.isSnapshotNow = false;
            }
            return bitmap;
        }

        private byte[] GetPixels(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bitmapdata = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr source = bitmapdata.Scan0;
            int length = (bmp.Width * bmp.Height) * 4;
            byte[] destination = new byte[length];
            Marshal.Copy(source, destination, 0, length);
            bmp.UnlockBits(bitmapdata);
            return destination;
        }

        private void Init()
        {
            base.Parent = this.DecoratedControl.Parent;
            base.Visible = this.DecoratedControl.Visible;
            base.Location = new Point(this.DecoratedControl.Left - this.Padding.Left, this.DecoratedControl.Top - this.Padding.Top);
            if (base.Parent != null)
            {
                int childIndex = base.Parent.Controls.GetChildIndex(this.DecoratedControl);
                base.Parent.Controls.SetChildIndex(this, childIndex + 1);
            }
            Size size = new Size((this.DecoratedControl.Width + this.Padding.Left) + this.Padding.Right, (this.DecoratedControl.Height + this.Padding.Top) + this.Padding.Bottom);
            if (size != base.Size)
            {
                base.Size = size;
            }
        }

        private void InitPadding()
        {
            if (this.DecorationType == DecorationType.BottomMirror)
            {
                this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            }
        }

        protected virtual Bitmap OnNonLinearTransfromNeeded()
        {
            Bitmap bitmap = null;
            if (this.CtrlBmp == null)
            {
                return null;
            }
            try
            {
                bitmap = new Bitmap(base.Width, base.Height);
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr source = bitmapdata.Scan0;
                int length = (bitmap.Width * bitmap.Height) * 4;
                byte[] destination = new byte[length];
                Marshal.Copy(source, destination, 0, length);
                NonLinearTransfromNeededEventArg e = new NonLinearTransfromNeededEventArg
                {
                    CurrentTime = this.CurrentTime,
                    ClientRectangle = base.ClientRectangle,
                    Pixels = destination,
                    Stride = bitmapdata.Stride,
                    SourcePixels = this.CtrlPixels,
                    SourceClientRectangle = new Rectangle(this.Padding.Left, this.Padding.Top, this.DecoratedControl.Width, this.DecoratedControl.Height),
                    SourceStride = this.CtrlStride
                };
                try
                {
                    if (this.NonLinearTransfromNeeded != null)
                    {
                        this.NonLinearTransfromNeeded(this, e);
                    }
                    else
                    {
                        e.UseDefaultTransform = true;
                    }
                    if (e.UseDefaultTransform && (this.DecorationType == DecorationType.BottomMirror))
                    {
                        TransfromHelper.DoBottomMirror(e);
                    }
                }
                catch
                {
                }
                Marshal.Copy(destination, 0, source, length);
                bitmap.UnlockBits(bitmapdata);
            }
            catch
            {
            }
            return bitmap;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.CtrlBmp = this.GetForeground(this.DecoratedControl);
            this.CtrlPixels = this.GetPixels(this.CtrlBmp);
            if (this.Frame != null)
            {
                this.Frame.Dispose();
            }
            this.Frame = this.OnNonLinearTransfromNeeded();
            if (this.Frame != null)
            {
                e.Graphics.DrawImage(this.Frame, Point.Empty);
            }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            switch (this.DecorationType)
            {
                case DecorationType.BottomMirror:
                case DecorationType.Custom:
                    base.Invalidate();
                    return;
            }
        }

        public Bitmap CtrlBmp { get; set; }

        public byte[] CtrlPixels { get; set; }

        public int CtrlStride { get; set; }

        public float CurrentTime { get; set; }

        public Control DecoratedControl { get; set; }

        public DecorationType DecorationType { get; set; }

        public Bitmap Frame { get; set; }

        public System.Windows.Forms.Padding Padding { get; set; }
    }
}
