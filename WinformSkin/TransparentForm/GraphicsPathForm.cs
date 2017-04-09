﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransparentForm
{
    public partial class GraphicsPathForm : Form
    {
        #region 鼠标穿透
        private const uint WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE = (-16);
        private const int GWL_EXSTYLE = (-20);
        private const int LWA_ALPHA = 0;

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(
        IntPtr hwnd,
        int nIndex,
        uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(
        IntPtr hwnd,
        int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );

        /// <summary> 
        /// 设置窗体具有鼠标穿透效果 
        /// </summary> 
        public void SetPenetrate()
        {
            this.TopMost = true;
            GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
            SetLayeredWindowAttributes(this.Handle, 0, 100, LWA_ALPHA);
        }
        #endregion
        public GraphicsPathForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void GraphicsPathForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            BringToFront();

            FormBorderStyle = FormBorderStyle.None;
            Bitmap bitmap = new Bitmap(BackgroundImage);//背景图资源
            this.Region = new Region(GetWindowRegion(bitmap));
            SetPenetrate();//使用鼠标穿透
        }
        private GraphicsPath GetWindowRegion(Bitmap bitmap)
        {
            Color TempColor;
            GraphicsPath gp = new GraphicsPath();
            if (bitmap == null) return null;

            for (int nX = 0; nX < bitmap.Width; nX++)
            {
                for (int nY = 0; nY < bitmap.Height; nY++)
                {
                    TempColor = bitmap.GetPixel(nX, nY);
                    //if (TempColor.A != 0)//如果颜色不是全透明
                    if (TempColor.A == 255)//如果颜色带有透明
                    {
                        gp.AddRectangle(new Rectangle(nX, nY, 1, 1));
                    }
                }
            }
            return gp;
        }
    }
}