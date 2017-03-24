//##########################################################################
//★★★★★★★           http://www.cnpopsoft.com           ★★★★★★★
//★★          VB & C# source code and articles for free !!!           ★★
//★★★★★★★                Davidwu                       ★★★★★★★
//##########################################################################

using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;

/// <summary>
/// Wind32API
/// </summary>
internal class Win32
{
    #region 消息
    public const int MF_REMOVE = 0x1000;

    public const int SC_RESTORE = 0xF120; //还原
    public const int SC_MOVE = 0xF010; //移动
    public const int SC_SIZE = 0xF000; //大小
    public const int SC_MINIMIZE = 0xF020; //最小化
    public const int SC_MAXIMIZE = 0xF030; //最大化
    public const int SC_CLOSE = 0xF060; //关闭 

    public const int WM_SYSCOMMAND = 0x0112;
    public const int WM_COMMAND = 0x0111;

    public const int GW_HWNDFIRST = 0;
    public const int GW_HWNDLAST = 1;
    public const int GW_HWNDNEXT = 2;
    public const int GW_HWNDPREV = 3;
    public const int GW_OWNER = 4;
    public const int GW_CHILD = 5;

    public const int WM_NCCALCSIZE = 0x83;
    public const int WM_WINDOWPOSCHANGING = 0x46;
    public const int WM_PAINT = 0xF;
    public const int WM_CREATE = 0x1;
    public const int WM_NCCREATE = 0x81;
    public const int WM_NCPAINT = 0x85;
    public const int WM_PRINT = 0x317;
    public const int WM_DESTROY = 0x2;
    public const int WM_SHOWWINDOW = 0x18;
    public const int WM_SHARED_MENU = 0x1E2;
    public const int HC_ACTION = 0;
    public const int WH_CALLWNDPROC = 4;
    public const int GWL_WNDPROC = -4;

    public const int WS_SYSMENU = 0x80000;
    public const int WS_SIZEBOX = 0x40000;

    public const int WS_MAXIMIZEBOX = 0x10000;

    public const int WS_MINIMIZEBOX = 0x20000;
    #endregion
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        public Int32 cx;
        public Int32 cy;

        public Size(Int32 x, Int32 y)
        {
            cx = x;
            cy = y;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BLENDFUNCTION
    {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public Int32 x;
        public Int32 y;

        public Point(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public const byte AC_SRC_OVER = 0;
    public const Int32 ULW_ALPHA = 2;
    public const byte AC_SRC_ALPHA = 1;

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll", ExactSpelling = true)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

    [DllImport("user32.dll", ExactSpelling = true)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int DeleteDC(IntPtr hDC);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int DeleteObject(IntPtr hObj);

    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);

    [DllImport("user32")]
    public static extern int SendMessage(IntPtr hwnd, int msg, int wp, int lp);

    #region 窗体边框阴影效果变量申明
    public const int CS_DropSHADOW = 0x20000;
    public const int GCL_STYLE = (-26);
    //声明Win32 API
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetClassLong(IntPtr hwnd, int nIndex);
    #endregion
}