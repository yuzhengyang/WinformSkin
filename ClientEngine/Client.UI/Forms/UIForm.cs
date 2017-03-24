using Client.UI.Base.Enums;
using Client.UI.Base.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Client.UI.Base.Forms;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Client.UI.Forms
{
    public class UIForm<TFormRender, TTitleButtonRender> : FormBase 
        where TFormRender:Base.Render.FormRender,new()
        where TTitleButtonRender : Base.Render.TitleRender, new()     
    {
        private int m_InWmWindowPosChanged;
        private bool _clientSizeSet;
        private Padding m_BorderPadding = new Padding(4);


        


        protected TTitleButtonRender m_TitleButtonRender = new TTitleButtonRender();
        protected TFormRender m_FormRender = new TFormRender();








        public UIForm()
        {
            m_TitleButtonRender.SetHostForm(this);
            m_FormRender.SetHostForm(this);
        }


        


        protected virtual void ResizeCore()
        {
            this.CalcDeltaRect();
            this.m_FormRender.SetReion();
        }



        protected void CalcDeltaRect()
        {
            if (base.WindowState == FormWindowState.Maximized)
            {
                Rectangle bounds = base.Bounds;
                Rectangle workingArea = Screen.GetWorkingArea(this);
                workingArea.X -= this.m_BorderPadding.Left;
                workingArea.Y -= this.m_BorderPadding.Top;
                workingArea.Width += this.m_BorderPadding.Horizontal;
                workingArea.Height += this.m_BorderPadding.Vertical;
                int x = 0;
                int y = 0;
                int width = 0;
                int height = 0;
                if (bounds.Left < workingArea.Left)
                {
                    x = workingArea.Left - bounds.Left;
                }
                if (bounds.Top < workingArea.Top)
                {
                    y = workingArea.Top - bounds.Top;
                }
                if (bounds.Width > workingArea.Width)
                {
                    width = bounds.Width - workingArea.Width;
                }
                if (bounds.Height > workingArea.Height)
                {
                    height = bounds.Height - workingArea.Height;
                }
                this.m_DeltaRect = new Rectangle(x, y, width, height);
            }
            else
            {
                this.m_DeltaRect = Rectangle.Empty;
            }
        }

        #region mouseAction

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

        #region override

        protected override void OnPaint(PaintEventArgs e)
        {
            m_FormRender.Render(e.Graphics);
            m_TitleButtonRender.Render(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.m_FormRender.SetReion();
        }

        protected override void OnResize(EventArgs e)
        {
            this.ResizeCore();
            base.OnResize(e);
            //测试
            this.Invalidate();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (base.Visible)
            {
                if (!base.DesignMode)
                {
                    m_FormRender.RenderShadow();
                }
            }
            base.OnVisibleChanged(e);
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            if (this._clientSizeSet)
            {
                this.ClientSize = this.ClientSize;
                this._clientSizeSet = false;
            }
            base.OnStyleChanged(e);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            this._clientSizeSet = false;
            System.Type type = typeof(Control);
            System.Type type2 = typeof(Form);
            FieldInfo field = type.GetField("clientWidth", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo info2 = type.GetField("clientHeight", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo info3 = type2.GetField("FormStateSetClientSize", BindingFlags.NonPublic | BindingFlags.Static);
            FieldInfo info4 = type2.GetField("formState", BindingFlags.NonPublic | BindingFlags.Instance);
            if (((field != null) && (info2 != null)) && ((info4 != null) && (info3 != null)))
            {
                this._clientSizeSet = true;
                base.Size = new System.Drawing.Size(x, y);
                field.SetValue(this, x);
                info2.SetValue(this, y);
                BitVector32.Section section = (BitVector32.Section)info3.GetValue(this);
                BitVector32 vector = (BitVector32)info4.GetValue(this);
                vector[section] = 1;
                info4.SetValue(this, vector);
                this.OnClientSizeChanged(EventArgs.Empty);
                vector[section] = 0;
                info4.SetValue(this, vector);
            }
            else
            {
                base.SetClientSizeCore(x, y);
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.m_InWmWindowPosChanged != 0)
            {
                try
                {
                    System.Type type = typeof(Form);
                    FieldInfo field = type.GetField("FormStateExWindowBoundsWidthIsClientSize", BindingFlags.NonPublic | BindingFlags.Static);
                    FieldInfo info2 = type.GetField("formStateEx", BindingFlags.NonPublic | BindingFlags.Instance);
                    FieldInfo info3 = type.GetField("restoredWindowBounds", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (((field != null) && (info2 != null)) && (info3 != null))
                    {
                        Rectangle rectangle = (Rectangle)info3.GetValue(this);
                        BitVector32.Section section = (BitVector32.Section)field.GetValue(this);
                        BitVector32 vector = (BitVector32)info2.GetValue(this);
                        if (vector[section] == 1)
                        {
                            width = rectangle.Width;
                            height = rectangle.Height;
                        }
                    }
                }
                catch
                {
                }
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            m_FormRender.Dispose();
        }

        #endregion

        

        #region >WindowsMessage<
        protected void WmNcActive(ref Message m)
        {
            if (m.WParam.ToInt32() == 1)
            {
                this.m_Active = true;
            }
            else
            {
                this.m_Active = false;
            }
            m.Result = new IntPtr(1);
            base.Invalidate();
        }

        private void WmNcHitTest(ref Message m)
        {
            System.Drawing.Point mouseLocation = new System.Drawing.Point(m.LParam.ToInt32());
            mouseLocation = PointToClient(mouseLocation);

            if (WindowState != FormWindowState.Maximized)
            {
                if (m_FormRender.CanResize == true)
                {
                    if (mouseLocation.X < 5 && mouseLocation.Y < 5)
                    {
                        m.Result = new IntPtr(NativeMethods.HTTOPLEFT);
                        return;
                    }

                    if (mouseLocation.X > Width - 5 && mouseLocation.Y < 5)
                    {
                        m.Result = new IntPtr(NativeMethods.HTTOPRIGHT);
                        return;
                    }

                    if (mouseLocation.X < 5 && mouseLocation.Y > Height - 5)
                    {
                        m.Result = new IntPtr(NativeMethods.HTBOTTOMLEFT);
                        return;
                    }

                    if (mouseLocation.X > Width - 5 && mouseLocation.Y > Height - 5)
                    {
                        m.Result = new IntPtr(NativeMethods.HTBOTTOMRIGHT);
                        return;
                    }

                    if (mouseLocation.Y < 3)
                    {
                        m.Result = new IntPtr(NativeMethods.HTTOP);
                        return;
                    }

                    if (mouseLocation.Y > Height - 3)
                    {
                        m.Result = new IntPtr(NativeMethods.HTBOTTOM);
                        return;
                    }

                    if (mouseLocation.X < 3)
                    {
                        m.Result = new IntPtr(NativeMethods.HTLEFT);
                        return;
                    }

                    if (mouseLocation.X > Width - 3)
                    {
                        m.Result = new IntPtr(NativeMethods.HTRIGHT);
                        return;
                    }
                }
            }
            m.Result = new IntPtr(NativeMethods.HTCLIENT);
        }

        private void WmNcCalcSize(ref Message m)
        {
            if (base.Opacity != 1.0)
            {
                base.Invalidate();
            }
        }

        private void WmWindowPosChanged(ref Message m)
        {
            this.m_InWmWindowPosChanged++;
            base.WndProc(ref m);
            this.m_InWmWindowPosChanged--;
        }

        private void WmGetMinMaxInfo(ref Message m)
        {
            MINMAXINFO structure = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
            if (this.MaximumSize != System.Drawing.Size.Empty)
            {
                structure.maxTrackSize = this.MaximumSize;
            }
            else
            {
                Rectangle workingArea = Screen.GetWorkingArea(this);
                int num = (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) ? 0 : -1;
                structure.maxPosition = new System.Drawing.Point(workingArea.X, workingArea.Y);
                structure.maxTrackSize = new System.Drawing.Size(workingArea.Width, workingArea.Height + num);
            }
            //if (this.MinimumSize != System.Drawing.Size.Empty)
            //{
            //    structure.minTrackSize = this.MinimumSize;
            //}
            //else
            //{
            //    this.GetDefaultMinTrackSize();
            //    structure.minTrackSize = new System.Drawing.Size((((this.AllButtonWidth(true) + this.ControlBoxOffset.X) + SystemInformation.SmallIconSize.Width) + (this.BorderPadding.Left * 2)) + 3, this.CaptionHeight);
            //}
            Marshal.StructureToPtr(structure, m.LParam, false);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_NCCALCSIZE://消除Winform窗体的标题栏
                    WmNcCalcSize(ref m);
                    return;
                case NativeMethods.WM_NCACTIVATE://窗体是否被激活
                    this.WmNcActive(ref m);
                    return;
                case NativeMethods.WM_NCHITTEST://与窗体大小改变有关
                    this.WmNcHitTest(ref m);
                    return;
                case NativeMethods.WM_WINDOWPOSCHANGED:
                    this.WmWindowPosChanged(ref m);
                    return;
                case NativeMethods.WM_GETMINMAXINFO:
                    this.WmGetMinMaxInfo(ref m);
                    return;
                default:
                    base.WndProc(ref m);
                    break;
            }

        }

        #endregion


    }
}
