using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Client.UI.Base.Animations;
using System.Windows.Forms;
using System.ComponentModel;
using Client.UI.Base.Enums;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Client.UI.Contorls
{
    internal class DoubleBitmapControl : Control, IFakeControl
    {
        private object bgBmp;
        private Container components;
        private object frame;

        public event EventHandler<PaintEventArgs> FramePainted;

        public event EventHandler<PaintEventArgs> FramePainting;

        public event EventHandler<TransfromNeededEventArg> TransfromNeeded;

        public DoubleBitmapControl()
        {
            this.InitializeComponent();
            base.Visible = false;
            base.SetStyle(ControlStyles.Selectable, false);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        public void InitParent(Control control, Padding padding)
        {
            base.Parent = control.Parent;
            int childIndex = control.Parent.Controls.GetChildIndex(control);
            control.Parent.Controls.SetChildIndex(this, childIndex);
            base.Bounds = new Rectangle(control.Left - padding.Left, control.Top - padding.Top, (control.Size.Width + padding.Left) + padding.Right, (control.Size.Height + padding.Top) + padding.Bottom);
        }

        protected virtual void OnFramePainted(PaintEventArgs e)
        {
            if (this.FramePainted != null)
            {
                this.FramePainted(this, e);
            }
        }

        protected virtual void OnFramePainting(PaintEventArgs e)
        {
            if (this.FramePainting != null)
            {
                this.FramePainting(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            this.OnFramePainting(e);
            try
            {
                graphics.DrawImage((Image)this.bgBmp, 0, 0);
                if (this.frame != null)
                {
                    TransfromNeededEventArg ea = new TransfromNeededEventArg
                    {
                        ClientRectangle = new Rectangle(0, 0, base.Width, base.Height)
                    };
                    this.OnTransfromNeeded(ea);
                    graphics.SetClip(ea.ClipRectangle);
                    graphics.Transform = ea.Matrix;
                    graphics.DrawImage((Image)this.frame, 0, 0);
                }
            }
            catch
            {
            }
            this.OnFramePainted(e);
        }

        private void OnTransfromNeeded(TransfromNeededEventArg ea)
        {
            if (this.TransfromNeeded != null)
            {
                this.TransfromNeeded(this, ea);
            }
        }

        Bitmap IFakeControl.BgBmp
        {
            get
            {
                return (Bitmap)this.bgBmp;
            }
            set
            {
                this.bgBmp = value;
            }
        }

        Bitmap IFakeControl.Frame
        {
            get
            {
                return (Bitmap)this.frame;
            }
            set
            {
                this.frame = value;
            }
        }
    }


    public class Controller
    {
        private Animation animation;
        private Point[] buffer;
        protected Rectangle clipRect;
        protected Bitmap ctrlBmp;
        private AnimateMode mode;
        private byte[] pixelsBuffer;

        public event EventHandler<PaintEventArgs> FramePainted;

        public event EventHandler<PaintEventArgs> FramePainting;

        public event EventHandler<MouseEventArgs> MouseDown;

        public event EventHandler<NonLinearTransfromNeededEventArg> NonLinearTransfromNeeded;

        public event EventHandler<TransfromNeededEventArg> TransfromNeeded;

        public Controller(Control control, AnimateMode mode, Animation animation, float timeStep, Rectangle controlClipRect)
        {
            this.DoubleBitmap = new DoubleBitmapControl();
            (this.DoubleBitmap as IFakeControl).FramePainting += new EventHandler<PaintEventArgs>(this.OnFramePainting);
            (this.DoubleBitmap as IFakeControl).FramePainted += new EventHandler<PaintEventArgs>(this.OnFramePainting);
            (this.DoubleBitmap as IFakeControl).TransfromNeeded += new EventHandler<TransfromNeededEventArg>(this.OnTransfromNeeded);
            this.DoubleBitmap.MouseDown += new MouseEventHandler(this.OnMouseDown);
            this.animation = animation;
            this.AnimatedControl = control;
            this.mode = mode;
            if (controlClipRect == new Rectangle())
            {
                this.clipRect = new Rectangle(Point.Empty, this.GetBounds().Size);
            }
            else
            {
                this.clipRect = this.ControlRectToMyRect(controlClipRect);
            }
            if ((mode == AnimateMode.Show) || (mode == AnimateMode.BeginUpdate))
            {
                timeStep = -timeStep;
            }
            this.TimeStep = timeStep * ((animation.TimeCoeff == 0f) ? 1f : animation.TimeCoeff);
            if (this.TimeStep == 0f)
            {
                timeStep = 0.01f;
            }
            switch (mode)
            {
                case AnimateMode.Show:
                    this.BgBmp = this.GetBackground(control, false, false);
                    (this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
                    this.DoubleBitmap.Visible = true;
                    this.DoubleBitmap.Refresh();
                    control.Visible = true;
                    this.ctrlBmp = this.GetForeground(control);
                    break;

                case AnimateMode.Hide:
                    this.BgBmp = this.GetBackground(control, false, false);
                    (this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
                    this.ctrlBmp = this.GetForeground(control);
                    this.DoubleBitmap.Visible = true;
                    control.Visible = false;
                    break;

                case AnimateMode.Update:
                case AnimateMode.BeginUpdate:
                    (this.DoubleBitmap as IFakeControl).InitParent(control, animation.Padding);
                    this.BgBmp = this.GetBackground(control, true, false);
                    this.DoubleBitmap.Visible = true;
                    break;
            }
            this.CurrentTime = (timeStep > 0f) ? animation.MinTime : animation.MaxTime;
        }

        internal void BuildNextFrame()
        {
            this.DoubleBitmap.Invalidate();
        }

        protected virtual Rectangle ControlRectToMyRect(Rectangle rect)
        {
            return new Rectangle(this.animation.Padding.Left + rect.Left, this.animation.Padding.Top + rect.Top, (rect.Width + this.animation.Padding.Left) + this.animation.Padding.Right, (rect.Height + this.animation.Padding.Top) + this.animation.Padding.Bottom);
        }

        public void Dispose()
        {
            if (this.ctrlBmp != null)
            {
                this.BgBmp.Dispose();
            }
            if (this.ctrlBmp != null)
            {
                this.ctrlBmp.Dispose();
            }
            if (this.Frame != null)
            {
                this.Frame.Dispose();
            }
            this.AnimatedControl = null;
            this.Hide();
        }

        public void EndUpdate()
        {
            Bitmap bitmap = this.GetBackground(this.AnimatedControl, true, true);
            if (this.animation.AnimateOnlyDifferences)
            {
                TransfromHelper.CalcDifference(bitmap, this.BgBmp);
            }
            this.ctrlBmp = bitmap;
            this.mode = AnimateMode.Update;
        }

        protected virtual Bitmap GetBackground(Control ctrl, bool includeForeground = false, bool clip = false)
        {
            if (ctrl is Form)
            {
                return this.GetScreenBackground(ctrl, includeForeground, clip);
            }
            Rectangle bounds = this.GetBounds();
            int width = bounds.Width;
            int height = bounds.Height;
            if (width == 0)
            {
                width = 1;
            }
            if (height == 1)
            {
                height = 1;
            }
            Bitmap image = new Bitmap(width, height);
            Rectangle clipRect = new Rectangle(0, 0, image.Width, image.Height);
            PaintEventArgs args = new PaintEventArgs(Graphics.FromImage(image), clipRect);
            if (clip)
            {
                args.Graphics.SetClip(this.clipRect);
            }
            for (int i = ctrl.Parent.Controls.Count - 1; i >= 0; i--)
            {
                Control control = ctrl.Parent.Controls[i];
                if ((control == ctrl) && !includeForeground)
                {
                    break;
                }
                if ((control.Visible && !control.IsDisposed) && control.Bounds.IntersectsWith(bounds))
                {
                    using (Bitmap bitmap2 = new Bitmap(control.Width, control.Height))
                    {
                        control.DrawToBitmap(bitmap2, new Rectangle(0, 0, control.Width, control.Height));
                        args.Graphics.DrawImage(bitmap2, control.Left - bounds.Left, control.Top - bounds.Top, control.Width, control.Height);
                    }
                }
                if (control == ctrl)
                {
                    break;
                }
            }
            args.Graphics.Dispose();
            return image;
        }

        protected virtual Rectangle GetBounds()
        {
            return new Rectangle(this.AnimatedControl.Left - this.animation.Padding.Left, this.AnimatedControl.Top - this.animation.Padding.Top, (this.AnimatedControl.Size.Width + this.animation.Padding.Left) + this.animation.Padding.Right, (this.AnimatedControl.Size.Height + this.animation.Padding.Top) + this.animation.Padding.Bottom);
        }

        protected virtual Bitmap GetForeground(Control ctrl)
        {
            Bitmap bitmap = new Bitmap(this.DoubleBitmap.Width, this.DoubleBitmap.Height);
            if (!ctrl.IsDisposed)
            {
                if (this.DoubleBitmap.Parent == null)
                {
                    ctrl.DrawToBitmap(bitmap, new Rectangle(this.animation.Padding.Left, this.animation.Padding.Top, ctrl.Width, ctrl.Height));
                    return bitmap;
                }
                ctrl.DrawToBitmap(bitmap, new Rectangle(ctrl.Left - this.DoubleBitmap.Left, ctrl.Top - this.DoubleBitmap.Top, ctrl.Width, ctrl.Height));
            }
            return bitmap;
        }

        private Bitmap GetScreenBackground(Control ctrl, bool includeForeground, bool clip)
        {
            Size blockRegionSize = Screen.PrimaryScreen.Bounds.Size;
            Graphics g = this.DoubleBitmap.CreateGraphics();
            Bitmap image = new Bitmap(blockRegionSize.Width, blockRegionSize.Height, g);
            Graphics.FromImage(image).CopyFromScreen(0, 0, 0, 0, blockRegionSize);
            return image;
        }

        public void Hide()
        {
            MethodInvoker method = null;
            if (this.DoubleBitmap != null)
            {
                try
                {
                    if (method == null)
                    {
                        method = delegate
                        {
                            if (this.DoubleBitmap.Visible)
                            {
                                this.DoubleBitmap.Hide();
                            }
                            this.DoubleBitmap.Parent = null;
                        };
                    }
                    this.DoubleBitmap.BeginInvoke(method);
                }
                catch
                {
                }
            }
        }

        protected virtual void OnFramePainted(object sender, PaintEventArgs e)
        {
            if (this.FramePainted != null)
            {
                this.FramePainted(this, e);
            }
        }

        protected virtual void OnFramePainting(object sender, PaintEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.Dispose();
            }
            this.Frame = null;
            if (this.mode != AnimateMode.BeginUpdate)
            {
                this.Frame = this.OnNonLinearTransfromNeeded();
                float maxTime = this.CurrentTime + this.TimeStep;
                if (maxTime > this.animation.MaxTime)
                {
                    maxTime = this.animation.MaxTime;
                }
                if (maxTime < this.animation.MinTime)
                {
                    maxTime = this.animation.MinTime;
                }
                this.CurrentTime = maxTime;
                if (this.FramePainting != null)
                {
                    this.FramePainting(this, e);
                }
            }
        }

        protected virtual void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (this.MouseDown != null)
            {
                this.MouseDown(this, e);
            }
        }

        protected virtual Bitmap OnNonLinearTransfromNeeded()
        {
            Bitmap bitmap = null;
            if (this.ctrlBmp == null)
            {
                return null;
            }
            try
            {
                bitmap = (Bitmap)this.ctrlBmp.Clone();
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                IntPtr source = bitmapdata.Scan0;
                int length = (bitmap.Width * bitmap.Height) * 4;
                byte[] destination = new byte[length];
                Marshal.Copy(source, destination, 0, length);
                NonLinearTransfromNeededEventArg e = new NonLinearTransfromNeededEventArg
                {
                    CurrentTime = this.CurrentTime,
                    ClientRectangle = this.DoubleBitmap.ClientRectangle,
                    Pixels = destination,
                    Stride = bitmapdata.Stride
                };
                if (this.NonLinearTransfromNeeded != null)
                {
                    this.NonLinearTransfromNeeded(this, e);
                }
                else
                {
                    e.UseDefaultTransform = true;
                }
                if (e.UseDefaultTransform)
                {
                    TransfromHelper.DoBlind(e, this.animation);
                    TransfromHelper.DoMosaic(e, this.animation, ref this.buffer, ref this.pixelsBuffer);
                    TransfromHelper.DoTransparent(e, this.animation);
                    TransfromHelper.DoLeaf(e, this.animation);
                }
                Marshal.Copy(destination, 0, source, length);
                bitmap.UnlockBits(bitmapdata);
            }
            catch
            {
            }
            return bitmap;
        }

        protected virtual void OnTransfromNeeded(object sender, TransfromNeededEventArg e)
        {
            try
            {
                e.ClipRectangle = this.clipRect;
                e.CurrentTime = this.CurrentTime;
                if (this.TransfromNeeded != null)
                {
                    this.TransfromNeeded(this, e);
                }
                else
                {
                    e.UseDefaultMatrix = true;
                }
                if (e.UseDefaultMatrix)
                {
                    TransfromHelper.DoScale(e, this.animation);
                    TransfromHelper.DoRotate(e, this.animation);
                    TransfromHelper.DoSlide(e, this.animation);
                }
            }
            catch
            {
            }
        }

        public Control AnimatedControl { get; set; }

        protected Bitmap BgBmp
        {
            get
            {
                return (this.DoubleBitmap as IFakeControl).BgBmp;
            }
            set
            {
                (this.DoubleBitmap as IFakeControl).BgBmp = value;
            }
        }

        public float CurrentTime { get; private set; }

        public Control DoubleBitmap { get; private set; }

        public Bitmap Frame
        {
            get
            {
                return (this.DoubleBitmap as IFakeControl).Frame;
            }
            set
            {
                (this.DoubleBitmap as IFakeControl).Frame = value;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return (((this.TimeStep >= 0f) && (this.CurrentTime >= this.animation.MaxTime)) || ((this.TimeStep <= 0f) && (this.CurrentTime <= this.animation.MinTime)));
            }
        }

        protected float TimeStep { get; private set; }
    }
}
