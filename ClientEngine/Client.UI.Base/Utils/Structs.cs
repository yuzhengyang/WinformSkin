using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Client.UI.Base.Utils
{
    /// <summary>
    /// 表示在二维平面中定义点的、整数 X 和 Y 坐标的有序对。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        /// X 坐标
        /// </summary>
        public int X;
        /// <summary>
        /// Y 坐标
        /// </summary>
        public int Y;

        /// <summary>
        /// 初始化 Paway.Windows.Win32.POINT 结构的新实例。
        /// </summary>
        /// <param name="x">x 水平坐标</param>
        /// <param name="y">y 垂直坐标</param>
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// 存储一组整数，共四个，表示一个矩形的位置和大小
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        #region 变量
        /// <summary>
        /// 获取此 RECT 结构左边缘的 x 坐标。
        /// </summary>
        public int Left;
        /// <summary>
        /// 获取此 RECT 结构上边缘的 y 坐标。
        /// </summary>
        public int Top;
        /// <summary>
        /// 获取 x 坐标，该坐标是此 RECT 结构的 X 与 Width 属性值之和。
        /// </summary>
        public int Right;
        /// <summary>
        /// 获取 y 坐标，该坐标是此 RECT 结构的 Y 与 Height 属性值之和。
        /// </summary>
        public int Bottom;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化 Paway.Windows.Win32.RECT 结构的新实例。
        /// </summary>
        /// <param name="left">此 RECT 结构左边缘的 x 坐标。</param>
        /// <param name="top">此 RECT 结构上边缘的 y 坐标。</param>
        /// <param name="right">x 坐标，该坐标是此 RECT 结构的 X 与 Width 属性值之和。</param>
        /// <param name="bottom">y 坐标，该坐标是此 RECT 结构的 Y 与 Height 属性值之和。</param>
        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        /// <summary>
        /// 初始化 Paway.Windows.Win32.RECT 结构的新实例。
        /// </summary>
        /// <param name="rect">System.Drawing.Rectangle 对象</param>
        public RECT(Rectangle rect)
        {
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Right = rect.Right;
            this.Bottom = rect.Bottom;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置此 System.Drawing.Rectangle 的区域。
        /// </summary>
        public Rectangle Rect
        {
            get { return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top); }
        }

        /// <summary>
        /// 获取或设置此 RECT 的大小。
        /// </summary>
        public Size Size
        {
            get { return new Size(this.Right - this.Left, this.Bottom - this.Top); }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyBoardHookStruct
    {
        /// <summary>
        /// 
        /// </summary>
        public int vkCode;
        /// <summary>
        /// 
        /// </summary>
        public int scanCode;
        /// <summary>
        /// 
        /// </summary>
        public int flags;
        /// <summary>
        /// 
        /// </summary>
        public int time;
        /// <summary>
        /// 
        /// </summary>
        public int dwExtraInfo;
    }

    /// <summary>
    /// 鼠标钩子的相关信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseHookStruct
    {
        /// <summary>
        /// 鼠标的屏幕坐标
        /// </summary>
        public POINT Point;

        /// <summary>
        /// 鼠标所按下的键
        /// </summary>
        public int MouseData;

        /// <summary>
        /// 指定事件注入标志
        /// </summary>
        public int Flags;

        /// <summary>
        /// 消息的时间戳
        /// </summary>
        public int Time;

        /// <summary>
        /// 与消息相关联的额外信息
        /// </summary>
        public int ExtraInfo;
    }

    /// <summary>
    /// 存储一个有序整数对，通常为矩形的宽度和高度。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        #region 变量

        /// <summary>
        /// 获取或设置此 SIZE 的水平分量。
        /// </summary>
        public int Width;
        /// <summary>
        /// 获取或设置此 SIZE 的垂直分量。
        /// </summary>
        public int Height;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化 Paway.Windows.Win32.SIZE 结构的新实例。
        /// </summary>
        /// <param name="width">此 SIZE 的水平分量</param>
        /// <param name="height">此 SIZE 的垂直分量。</param>
        public SIZE(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        /// <summary>
        /// 文件的图标句柄
        /// </summary>
        public IntPtr hIcon;
        /// <summary>
        /// 图标的系统索引号
        /// </summary>
        public int iIcon;
        /// <summary>
        /// 文件的属性值
        /// </summary>
        public int dwAttributes;
        /// <summary>
        /// 文件的显示名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        /// <summary>
        /// 文件的类型名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        /// <summary>
        /// 
        /// </summary>
        public byte BlendOp;
        /// <summary>
        /// 
        /// </summary>
        public byte BlendFlags;
        /// <summary>
        /// 
        /// </summary>
        public byte SourceConstantAlpha;
        /// <summary>
        /// 
        /// </summary>
        public byte AlphaFormat;
    }

    /// <summary>
    /// ARGB 通道
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ARGB
    {
        /// <summary>
        /// 蓝色值
        /// </summary>
        public byte Blue;
        /// <summary>
        /// 绿色值
        /// </summary>
        public byte Green;
        /// <summary>
        /// 红色值
        /// </summary>
        public byte Red;
        /// <summary>
        /// 透明度
        /// </summary>
        public byte Alpha;
    }

    /// <summary>
    /// CPU的信息结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CPU_INFO
    {
        /// <summary>
        /// 
        /// </summary>
        public uint dwOemId;
        /// <summary>
        /// 
        /// </summary>
        public uint dwPageSize;
        /// <summary>
        /// 
        /// </summary>
        public uint lpMinimumApplicationAddress;
        /// <summary>
        /// 
        /// </summary>
        public uint lpMaximumApplicationAddress;
        /// <summary>
        /// 
        /// </summary>
        public uint dwActiveProcessorMask;
        /// <summary>
        /// 
        /// </summary>
        public uint dwNumberOfProcessors;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorType;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAllocationGranularity;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorLevel;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorRevision;
    }

    /// <summary>
    /// 内存的信息结构 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_INFO
    {
        /// <summary>
        /// 
        /// </summary>
        public uint dwLength;
        /// <summary>
        /// 
        /// </summary>
        public uint dwMemoryLoad;
        /// <summary>
        /// 
        /// </summary>
        public uint dwTotalPhys;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAvailPhys;
        /// <summary>
        /// 
        /// </summary>
        public uint dwTotalPageFile;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAvailPageFile;
        /// <summary>
        /// 
        /// </summary>
        public uint dwTotalVirtual;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAvailVirtual;
    }

    /// <summary>
    /// 系统时间的信息结构 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME_INFO
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort wYear;
        /// <summary>
        /// 
        /// </summary>
        public ushort wMonth;
        /// <summary>
        /// 
        /// </summary>
        public ushort wDayOfWeek;
        /// <summary>
        /// 
        /// </summary>
        public ushort wDay;
        /// <summary>
        /// 
        /// </summary>
        public ushort wHour;
        /// <summary>
        /// 
        /// </summary>
        public ushort wMinute;
        /// <summary>
        /// 
        /// </summary>
        public ushort wSecond;
        /// <summary>
        /// 
        /// </summary>
        public ushort wMilliseconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public int fErase;
        public RECT rcPaint;
        public int fRestore;
        public int fIncUpdate;
        public int Reserved1;
        public int Reserved2;
        public int Reserved3;
        public int Reserved4;
        public int Reserved5;
        public int Reserved6;
        public int Reserved7;
        public int Reserved8;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLBARINFO
    {
        public int cbSize;
        public RECT rcScrollBar;
        public int dxyLineButton;
        public int xyThumbTop;
        public int xyThumbBottom;
        public int reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public int[] rgstate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWINFO
    {
        public uint cbSize;
        public RECT rcWindow;
        public RECT rcClient;
        public uint dwStyle;
        public uint dwExStyle;
        public uint dwWindowStatus;
        public uint cxWindowBorders;
        public uint cyWindowBorders;
        public IntPtr atomWindowType;
        public ushort wCreatorVersion;
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public int showCmd;
        public Point ptMinPosition;
        public Point ptMaxPosition;
        public RECT rcNormalPosition;
        public static WINDOWPLACEMENT Default
        {
            get
            {
                WINDOWPLACEMENT structure = new WINDOWPLACEMENT();
                structure.length = Marshal.SizeOf(structure);
                return structure;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INITCOMMONCONTROLSEX
    {
        public int dwSize;
        public int dwICC;
        public INITCOMMONCONTROLSEX(int flags)
        {
            this.dwSize = Marshal.SizeOf(typeof(INITCOMMONCONTROLSEX));
            this.dwICC = flags;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public Point reserved;
        public Size maxSize;
        public Point maxPosition;
        public Size minTrackSize;
        public Size maxTrackSize;
    }

    public static class Result
    {
        public static readonly IntPtr FALSE = new IntPtr(0);
        public static readonly IntPtr TRUE = new IntPtr(1);
    }
}
