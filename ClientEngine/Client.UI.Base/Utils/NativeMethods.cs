using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Client.UI.Base.Utils
{
    [SuppressUnmanagedCodeSecurity]
    public static class NativeMethods
    {
        #region Fields

        public static HandleRef HWND_TOP;
        public static HandleRef HWND_TOPMOST;
        public static HandleRef HWND_BOTTOM;
        public static HandleRef NullHandleRef;

        private static int wmMouseEnterMessage;

        public static readonly int TTM_ADDTOOL;
        public static readonly int TTM_DELTOOL;
        public static readonly int TTM_ENUMTOOLS;
        public static readonly int TTM_GETCURRENTTOOL;
        public static readonly int TTM_GETTEXT;
        public static readonly int TTM_GETTOOLINFO;
        public static readonly int TTM_HITTEST;
        public static readonly int TTM_NEWTOOLRECT;
        public static readonly int TTM_SETTITLE;
        public static readonly int TTM_SETTOOLINFO;
        public static readonly int TTM_UPDATETIPTEXT;

        #endregion

        static NativeMethods()
        {
            NativeMethods.HWND_TOP = new HandleRef(null, IntPtr.Zero);
            NativeMethods.HWND_TOPMOST = new HandleRef(null, new IntPtr(-1));
            NativeMethods.HWND_BOTTOM = new HandleRef(null, (IntPtr)1);
            NativeMethods.NullHandleRef = new HandleRef(null, IntPtr.Zero);
            NativeMethods.wmMouseEnterMessage = -1;

            // RadToolTip
            if (Marshal.SystemDefaultCharSize == 1)
            {
                NativeMethods.TTM_ADDTOOL = 0x404;
                NativeMethods.TTM_SETTITLE = 0x420;
                NativeMethods.TTM_DELTOOL = 0x405;
                NativeMethods.TTM_NEWTOOLRECT = 0x406;
                NativeMethods.TTM_GETTOOLINFO = 0x408;
                NativeMethods.TTM_SETTOOLINFO = 0x409;
                NativeMethods.TTM_HITTEST = 0x40a;
                NativeMethods.TTM_GETTEXT = 0x40b;
                NativeMethods.TTM_UPDATETIPTEXT = 0x40c;
                NativeMethods.TTM_ENUMTOOLS = 0x40e;
                NativeMethods.TTM_GETCURRENTTOOL = 0x40f;
            }
            else
            {
                NativeMethods.TTM_ADDTOOL = 0x432;
                NativeMethods.TTM_SETTITLE = 0x421;
                NativeMethods.TTM_DELTOOL = 0x433;
                NativeMethods.TTM_NEWTOOLRECT = 0x434;
                NativeMethods.TTM_GETTOOLINFO = 0x435;
                NativeMethods.TTM_SETTOOLINFO = 0x436;
                NativeMethods.TTM_HITTEST = 0x437;
                NativeMethods.TTM_GETTEXT = 0x438;
                NativeMethods.TTM_UPDATETIPTEXT = 0x439;
                NativeMethods.TTM_ENUMTOOLS = 0x43a;
                NativeMethods.TTM_GETCURRENTTOOL = 0x43b;
            }
        }

        #region Constants

        #region Messages

        public const int WM_KEYFIRST = 0x100;
        public const int WM_KEYLAST = 0x108;
        public const int WM_MOUSEFIRST = 0x200;
        public const int WM_MOUSELAST = 0x20a;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 260;
        public const int WM_SYSKEYUP = 0x105;
        public const int WM_CHAR = 0x102;
        public const int WM_SYSCHAR = 0x106;
        public const int WM_MOUSEACTIVATE = 0x21;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_ACTIVATE = 6;
        public const int WM_ACTIVATEAPP = 0x1c;
        public const int WM_NCACTIVATE = 0x86;
        public const int WM_NCCALCSIZE = 0x83;
        public const int WM_NCCREATE = 0x81;
        public const int WM_NCDESTROY = 130;
        public const int WM_NCHITTEST = 0x84;
        public const int WM_NCLBUTTONDBLCLK = 0xa3;
        public const int WM_NCLBUTTONDOWN = 0xa1;
        public const int WM_NCLBUTTONUP = 0xa2;
        public const int WM_NCMBUTTONDBLCLK = 0xa9;
        public const int WM_NCMBUTTONDOWN = 0xa7;
        public const int WM_NCMBUTTONUP = 0xa8;
        public const int WM_NCMOUSELEAVE = 0x2a2;
        public const int WM_NCMOUSEMOVE = 160;
        public const int WM_NCPAINT = 0x85;
        public const int WM_NCRBUTTONDBLCLK = 0xa6;
        public const int WM_NCRBUTTONDOWN = 0xa4;
        public const int WM_NCRBUTTONUP = 0xa5;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_MBUTTONDBLCLK = 0x209;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_MBUTTONUP = 520;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_XBUTTONDBLCLK = 0x20d;
        public const int WM_XBUTTONDOWN = 0x20b;
        public const int WM_XBUTTONUP = 0x20c;
        public const int WM_PAINT = 15;
        public const int WM_ERASEBKGND = 20;
        public const int WM_SHOWWINDOW = 0x18;
        public const int WM_CAPTURECHANGED = 0x215;
        public const int WM_DWMCOMPOSITIONCHANGED = 0x31e;
        public const int WM_NCUAHDRAWCAPTION = 0xae;
        public const int WM_NCUAHDRAWFRAME = 0xaf;
        public const int WM_SIZE = 5;
        public const int WM_SIZING = 0x214;
        public const int WM_MOVE = 3;
        public const int WM_MOVING = 0x216;
        public const int WM_GETMINMAXINFO = 0x24;
        public const int WM_PRINT = 0x317;
        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;
        public const int WM_MOUSEWHEEL = 0x20a;
        public const int WM_SETFOCUS = 7;
        public const int WM_KILLFOCUS = 8;
        public const int WM_SYSCOMMAND = 0x112;
        public const int WM_POPUPSYSTEMMENU = 0x313;
        public const int WM_SETTEXT = 12;
        public const int WM_SETICON = 0x80;
        public const int WM_STYLECHANGED = 0x7d;
        public const int WM_MDIACTIVATE = 0x222;
        public const int WM_WINDOWPOSCHANGED = 0x47;
        public const int WM_WINDOWPOSCHANGING = 70;
        public const int WM_MOUSELEAVE = 0x2a3;
        public const int WM_SETREDRAW = 11;
        public const int WM_PARENTNOTIFY = 0x210;

        #endregion

        #region Window styles

        public const int WS_BORDER = 0x800000;
        public const int WS_CAPTION = 0xc00000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_CLIPCHILDREN = 0x2000000;
        public const int WS_CLIPSIBLINGS = 0x4000000;
        public const int WS_DISABLED = 0x8000000;
        public const int WS_DLGFRAME = 0x400000;
        public const int WS_EX_APPWINDOW = 0x40000;
        public const int WS_EX_CLIENTEDGE = 0x200;
        public const int WS_EX_CONTEXTHELP = 0x400;
        public const int WS_EX_CONTROLPARENT = 0x10000;
        public const int WS_EX_DLGMODALFRAME = 1;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int WS_EX_LAYOUTRTL = 0x400000;
        public const int WS_EX_LEFT = 0;
        public const int WS_EX_LTRREADING = 0x00000000;
        public const int WS_EX_LEFTSCROLLBAR = 0x4000;
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
        public const int WS_EX_MDICHILD = 0x40;
        public const int WS_EX_NOINHERITLAYOUT = 0x100000;
        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const int WS_EX_RIGHT = 0x1000;
        public const int WS_EX_RTLREADING = 0x2000;
        public const int WS_EX_STATICEDGE = 0x20000;
        public const int WS_EX_TOOLWINDOW = 0x80;
        public const int WS_EX_TOPMOST = 8;
        public const int WS_HSCROLL = 0x100000;
        public const int WS_MAXIMIZE = 0x1000000;
        public const int WS_MAXIMIZEBOX = 0x10000;
        public const int WS_MINIMIZE = 0x20000000;
        public const int WS_MINIMIZEBOX = 0x20000;
        public const int WS_OVERLAPPED = 0;
        public const int WS_POPUP = -2147483648;
        public const int WS_SYSMENU = 0x80000;
        public const int WS_TABSTOP = 0x10000;
        public const int WS_THICKFRAME = 0x40000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_VSCROLL = 0x200000;

        public const int CS_DBLCLKS = 8;
        public const int CS_DROPSHADOW = 0x20000;
        public const int CS_SAVEBITS = 0x800;

        #endregion

        #region Hit points

        public const int HTERROR = -2;
        public const int HTTRANSPARENT = -1;
        public const int HTNOWHERE = 0;
        public const int HTCLIENT = 1;
        public const int HTCAPTION = 2;
        public const int HTSYSMENU = 3;
        public const int HTGROWBOX = 4;
        public const int HTSIZE = HTGROWBOX;
        public const int HTMENU = 5;
        public const int HTHSCROLL = 6;
        public const int HTVSCROLL = 7;
        public const int HTMINBUTTON = 8;
        public const int HTMAXBUTTON = 9;
        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;
        public const int HTBORDER = 18;
        public const int HTREDUCE = HTMINBUTTON;
        public const int HTZOOM = HTMAXBUTTON;
        public const int HTSIZEFIRST = HTLEFT;
        public const int HTSIZELAST = HTBOTTOMRIGHT;
        public const int HTOBJECT = 19;
        public const int HTCLOSE = 20;
        public const int HTHELP = 21;

        #endregion

        #region BitBlt Operations

        public const int SRCAND = 0x8800c6;
        public const int SRCCOPY = 0xcc0020;
        public const int SRCPAINT = 0xee0086;

        #endregion

        #region SetWindowPos

        public const int SWP_DRAWFRAME = 0x20;
        public const int SWP_NOSENDCHANGING = 0x400;
        public const int SWP_DEFERERASE = 0x2000;
        public const int SWP_FRAMECHANGED = SWP_DRAWFRAME;
        public const int SWP_HIDEWINDOW = 0x80;
        public const int SWP_NOACTIVATE = 0x10;
        public const int SWP_NOCOPYBITS = 0x100;
        public const int SWP_NOMOVE = 2;
        public const int SWP_NOOWNERZORDER = 0x200;
        public const int SWP_NOSIZE = 1;
        public const int SWP_NOZORDER = 4;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_SHOWWINDOW = 0x40;

        #endregion

        #region Virtual Keys

        public const int VK_RETURN = 0x0D;
        public const int VK_CONTROL = 0x11;
        public const int VK_DOWN = 40;
        public const int VK_ESCAPE = 0x1b;
        public const int VK_INSERT = 0x2d;
        public const int VK_LEFT = 0x25;
        public const int VK_MENU = 0x12;
        public const int VK_RIGHT = 0x27;
        public const int VK_SHIFT = 0x10;
        public const int VK_TAB = 9;
        public const int VK_UP = 0x26;
        public const int VK_SPACE = 0x20;

        #endregion

        #region SysCommand types

        public const int SC_CLOSE = 0xf060;
        public const int SC_CONTEXTHELP = 0xf180;
        public const int SC_KEYMENU = 0xf100;
        public const int SC_MAXIMIZE = 0xf030;
        public const int SC_MINIMIZE = 0xf020;
        public const int SC_MOVE = 0xf010;
        public const int SC_RESTORE = 0xf120;
        public const int SC_SIZE = 0xf000;

        #endregion

        #region Track movement

        public const int TME_HOVER = 1;
        public const int TME_LEAVE = 2;
        public const int TME_NONCLIENT = 0x10;
        public const int TME_QUERY = 0x40000000;
        public const int TME_CANCEL = 0x8;

        #endregion

        #region Print areas

        public const int PRF_CHECKVISIBLE = 1;
        public const int PRF_CHILDREN = 0x10;
        public const int PRF_CLIENT = 4;
        public const int PRF_ERASEBKGND = 8;
        public const int PRF_OWNED = 0x00000020;
        public const int PRF_NONCLIENT = 2;

        #endregion

        #region Graphics objects

        public const int OBJ_BITMAP = 7;
        public const int OBJ_BRUSH = 2;
        public const int OBJ_DC = 3;
        public const int OBJ_ENHMETADC = 12;
        public const int OBJ_EXTPEN = 11;
        public const int OBJ_FONT = 6;
        public const int OBJ_MEMDC = 10;
        public const int OBJ_METADC = 4;
        public const int OBJ_METAFILE = 9;
        public const int OBJ_PAL = 5;
        public const int OBJ_PEN = 1;
        public const int OBJ_REGION = 8;

        #endregion

        public const int EM_POSFROMCHAR = 0xd6;
        public const int EM_LINEFROMCHAR = 0xc9;

        public const int SW_SHOWNOACTIVATE = 4;
        public const int WA_ACTIVE = 1;
        public const int WA_CLICKACTIVE = 2;
        public const int MA_NOACTIVATE = 3;

        public const int DCX_CACHE = 2;
        public const int DCX_INTERSECTRGN = 0x80;
        public const int DCX_LOCKWINDOWUPDATE = 0x400;
        public const int DCX_WINDOW = 1;
        public const int DCX_CLIPSIBLINGS = 0x00000010;
        public const int DCX_VALIDATE = 0x00200000;

        public const int SIZE_MAXIMIZED = 2;
        public const int SIZE_MINIMIZED = 1;
        public const int SIZE_RESTORED = 0;

        public const int RDW_ALLCHILDREN = 0x80;
        public const int RDW_ERASE = 4;
        public const int RDW_ERASENOW = 0x200;
        public const int RDW_FRAME = 0x400;
        public const int RDW_INVALIDATE = 1;
        public const int RDW_UPDATENOW = 0x100;

        public const int ICON_BIG = 1;
        public const int ICON_SMALL = 0;

        public const int LWA_ALPHA = 2;
        public const int LWA_COLORKEY = 1;

        public const int DWM_BB_ENABLE = 0x00000001;
        public const int DWM_BB_BLURREGION = 0x00000002;
        public const int DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;

        public const int GW_CHILD = 5;
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_ID = -12;
        public const int GWL_STYLE = -16;
        public const int GWL_WNDPROC = -4;
        public const int GA_PARENT = 1;
        public const int GA_ROOT = 2;

        public const int TTM_GETDELAYTIME = 0x415;

        public static int WM_MOUSEENTER
        {
            get
            {
                if (NativeMethods.wmMouseEnterMessage == -1)
                {
                    NativeMethods.wmMouseEnterMessage = RegisterWindowMessage("WinFormsMouseEnter");
                }
                return NativeMethods.wmMouseEnterMessage;
            }
        }

        #endregion

        #region Nested Types

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND
        {
            public uint dwFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fEnable;
            public IntPtr hRegionBlur;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fTransitionOnMaximized;

            public const uint DWM_BB_ENABLE = 0x00000001;
            public const uint DWM_BB_BLURREGION = 0x00000002;
            public const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;
        }


        [StructLayout(LayoutKind.Sequential)]
        public class SIZE
        {
            public int cx;
            public int cy;
            public SIZE()
            {
            }
            public SIZE(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TOOLINFO_TOOLTIP
        {
            public int cbSize;
            public int uFlags;
            public IntPtr hwnd;
            public IntPtr uId;
            public RECT rect;
            public IntPtr hinst;
            public IntPtr lpszText;
            public IntPtr lParam;
            public TOOLINFO_TOOLTIP()
            {
                this.cbSize = Marshal.SizeOf(typeof(NativeMethods.TOOLINFO_TOOLTIP));
                this.hinst = IntPtr.Zero;
                this.lParam = IntPtr.Zero;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public RECT[] rgrc;
            public IntPtr lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTSTRUCT
        {
            public int x;
            public int y;
            public POINTSTRUCT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SIZESTRUCT
        {
            public int cx;
            public int cy;
            public SIZESTRUCT(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
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

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TEXTMETRIC
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public char tmFirstChar;
            public char tmLastChar;
            public char tmDefaultChar;
            public char tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
            public MINMAXINFO()
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class TRACKMOUSEEVENT
        {
            public int cbSize;
            public int dwFlags;
            public IntPtr hwndTrack;
            public int dwHoverTime;
            public TRACKMOUSEEVENT()
            {
                this.cbSize = Marshal.SizeOf(typeof(NativeMethods.TRACKMOUSEEVENT));
                this.dwHoverTime = 100;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }

        // RadToolTip
        [StructLayout(LayoutKind.Sequential)]
        public class INITCOMMONCONTROLSEX
        {
            public int dwSize;
            public int dwICC;
            public INITCOMMONCONTROLSEX()
            {
                this.dwSize = 8;
            }
        }

 

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LOGFONT
        {
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string lfFaceName;
            public LOGFONT()
            {
            }
            public LOGFONT(NativeMethods.LOGFONT lf)
            {
                this.lfHeight = lf.lfHeight;
                this.lfWidth = lf.lfWidth;
                this.lfEscapement = lf.lfEscapement;
                this.lfOrientation = lf.lfOrientation;
                this.lfWeight = lf.lfWeight;
                this.lfItalic = lf.lfItalic;
                this.lfUnderline = lf.lfUnderline;
                this.lfStrikeOut = lf.lfStrikeOut;
                this.lfCharSet = lf.lfCharSet;
                this.lfOutPrecision = lf.lfOutPrecision;
                this.lfClipPrecision = lf.lfClipPrecision;
                this.lfQuality = lf.lfQuality;
                this.lfPitchAndFamily = lf.lfPitchAndFamily;
                this.lfFaceName = lf.lfFaceName;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class LOGPEN
        {
            public int lopnStyle;
            public int lopnWidth_x;
            public int lopnWidth_y;
            public int lopnColor;
            public LOGPEN()
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class LOGBRUSH
        {
            public int lbStyle;
            public int lbColor;
            public IntPtr lbHatch;
            public LOGBRUSH()
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAP
        {
            public int bmType;
            public int bmWidth;
            public int bmHeight;
            public int bmWidthBytes;
            public short bmPlanes;
            public short bmBitsPixel;
            public IntPtr bmBits;
            public BITMAP()
            {
                this.bmBits = IntPtr.Zero;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO
        {
            public int bmiHeader_biSize;
            public int bmiHeader_biWidth;
            public int bmiHeader_biHeight;
            public short bmiHeader_biPlanes;
            public short bmiHeader_biBitCount;
            public int bmiHeader_biCompression;
            public int bmiHeader_biSizeImage;
            public int bmiHeader_biXPelsPerMeter;
            public int bmiHeader_biYPelsPerMeter;
            public int bmiHeader_biClrUsed;
            public int bmiHeader_biClrImportant;
            public byte bmiColors_rgbBlue;
            public byte bmiColors_rgbGreen;
            public byte bmiColors_rgbRed;
            public byte bmiColors_rgbReserved;
            internal BITMAPINFO()
            {
                this.bmiHeader_biSize = 40;
            }
        }

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        public sealed class CommonHandles
        {
            // Methods
            static CommonHandles()
            {
                NativeMethods.CommonHandles.Accelerator = HandleCollector.RegisterType("Accelerator", 80, 50);
                NativeMethods.CommonHandles.Cursor = HandleCollector.RegisterType("Cursor", 20, 500);
                NativeMethods.CommonHandles.EMF = HandleCollector.RegisterType("EnhancedMetaFile", 20, 500);
                NativeMethods.CommonHandles.Find = HandleCollector.RegisterType("Find", 0, 0x3e8);
                NativeMethods.CommonHandles.GDI = HandleCollector.RegisterType("GDI", 50, 500);
                NativeMethods.CommonHandles.HDC = HandleCollector.RegisterType("HDC", 100, 2);
                NativeMethods.CommonHandles.CompatibleHDC = HandleCollector.RegisterType("ComptibleHDC", 50, 50);
                NativeMethods.CommonHandles.Icon = HandleCollector.RegisterType("Icon", 20, 500);
                NativeMethods.CommonHandles.Kernel = HandleCollector.RegisterType("Kernel", 0, 0x3e8);
                NativeMethods.CommonHandles.Menu = HandleCollector.RegisterType("Menu", 30, 0x3e8);
                NativeMethods.CommonHandles.Window = HandleCollector.RegisterType("Window", 5, 0x3e8);
            }

            public CommonHandles()
            {
            }

            // Fields
            public static readonly int Accelerator;
            public static readonly int CompatibleHDC;
            public static readonly int Cursor;
            public static readonly int EMF;
            public static readonly int Find;
            public static readonly int GDI;
            public static readonly int HDC;
            public static readonly int Icon;
            public static readonly int Kernel;
            public static readonly int Menu;
            public static readonly int Window;
        }

        public static class Util
        {
            private static int GetEmbeddedNullStringLengthAnsi(string s)
            {
                int num1 = s.IndexOf('\0');
                if (num1 > -1)
                {
                    string text1 = s.Substring(0, num1);
                    string text2 = s.Substring(num1 + 1);
                    return ((NativeMethods.Util.GetPInvokeStringLength(text1) + NativeMethods.Util.GetEmbeddedNullStringLengthAnsi(text2)) + 1);
                }
                return NativeMethods.Util.GetPInvokeStringLength(s);
            }

            public static int GetPInvokeStringLength(string s)
            {
                if (s == null)
                {
                    return 0;
                }
                if (Marshal.SystemDefaultCharSize == 2)
                {
                    return s.Length;
                }
                if (s.Length == 0)
                {
                    return 0;
                }
                if (s.IndexOf('\0') > -1)
                {
                    return NativeMethods.Util.GetEmbeddedNullStringLengthAnsi(s);
                }
                return NativeMethods.lstrlen(s);
            }

            public static int HIWORD(int n)
            {
                return ((n >> 0x10) & 0xffff);
            }

            public static int HIWORD(IntPtr n)
            {
                return NativeMethods.Util.HIWORD((int)((long)n));
            }

            public static int LOWORD(int n)
            {
                return (n & 0xffff);
            }

            public static int LOWORD(IntPtr n)
            {
                return NativeMethods.Util.LOWORD((int)((long)n));
            }

            public static int MAKELONG(int low, int high)
            {
                return ((high << 0x10) | (low & 0xffff));
            }

            public static IntPtr MAKELPARAM(int low, int high)
            {
                return (IntPtr)((high << 0x10) | (low & 0xffff));
            }

            public static int SignedHIWORD(int n)
            {
                return (short)((n >> 0x10) & 0xffff);
            }

            public static int SignedHIWORD(IntPtr n)
            {
                return NativeMethods.Util.SignedHIWORD((int)((long)n));
            }

            public static int SignedLOWORD(int n)
            {
                return (short)(n & 0xffff);
            }

            public static int SignedLOWORD(IntPtr n)
            {
                return NativeMethods.Util.SignedLOWORD((int)((long)n));
            }

            public static int LowOrder(int param)
            {
                return (param & 0xffff);
            }

            public static int HighOrder(int param)
            {
                return ((param >> 0x10) & 0xffff);
            }
        }

        #endregion

        #region Kernel32

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string libname);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int lstrlen(string s);

        #endregion

        #region User32

        #region SendMessage Methods

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, bool wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, [In, Out] ref Rectangle lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int[] lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, [In, Out, MarshalAs(UnmanagedType.Bool)] ref bool wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, ref short wParam, ref short lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.IUnknown)] out object editOle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hwnd, int msg, bool wparam, int lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, POINT lParam);

        #endregion

        #region PostMessage Methods

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, IntPtr lparam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int PostMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);

        #endregion

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool RedrawWindow(HandleRef hwnd, IntPtr rcUpdate, HandleRef hrgnUpdate, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool RedrawWindow(HandleRef hwnd, ref RECT rcUpdate, HandleRef hrgnUpdate, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr _WindowFromPoint(POINTSTRUCT pt);

        [DllImport("user32.dll", EntryPoint = "GetDC", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr IntGetDC(HandleRef hWnd);

        [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr IntGetDCEx(HandleRef hWnd, HandleRef hrgnClip, int flags);

        [DllImport("user32.dll", EntryPoint = "GetWindowDC", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr IntGetWindowDC(HandleRef hWnd);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern int IntReleaseDC(HandleRef hWnd, HandleRef hDC);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINTSTRUCT pptDst, ref NativeMethods.SIZESTRUCT psize, IntPtr hdcSrc, ref POINTSTRUCT pprSrc, int crKey, ref NativeMethods.BLENDFUNCTION pblend, int dwFlags);

        [DllImport("user32.dll")]
        public static extern int MsgWaitForMultipleObjects(int nCount, int pHandles, bool bWaitAll, int dwMilliseconds, int dwWakeMask);

        [DllImport("user32.dll")]
        public static extern bool HideCaret(System.IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsWindow(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsZoomed(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool IsIconic(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetFocus(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        public extern static IntPtr SetActiveWindow(HandleRef handle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ClientToScreen(HandleRef hWnd, [In, Out] POINT pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool AdjustWindowRectEx(ref RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref RECT rect, int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] POINT pt, int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetLayeredWindowAttributes(HandleRef hwnd, int crKey, byte bAlpha, int dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool MessageBeep(int type);

        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
        public static extern bool InvertRect(IntPtr hDC, [In] ref RECT lprc);

        public static void InvertRect(Graphics graphics, Rectangle rectangle)
        {
            IntPtr hdc = graphics.GetHdc();
            RECT rect = new RECT(rectangle.X, rectangle.Y, rectangle.Right, rectangle.Bottom);
            NativeMethods.InvertRect(hdc, ref rect);
            graphics.ReleaseHdc();
        }

        #endregion

        #region GDI32

        [DllImport("Gdi32.dll")]
        public static extern bool GetTextMetrics(IntPtr hdc, ref TEXTMETRIC tm);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool IntDeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool PatBlt(HandleRef hdc, int left, int top, int width, int height, int rop);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr IntCreateCompatibleDC(HandleRef hDC);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern bool IntDeleteDC(HandleRef hDC);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("gdi32.dll", EntryPoint = "CreateBitmap", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr IntCreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, IntPtr lpvBits);

        [DllImport("gdi32.dll", EntryPoint = "CreateBitmap", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr IntCreateBitmapByte(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, byte[] lpvBits);

        [DllImport("gdi32.dll", EntryPoint = "CreateBitmap", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr IntCreateBitmapShort(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits);

        [DllImport("gdi32.dll", EntryPoint = "CreateBrushIndirect", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr IntCreateBrushIndirect(NativeMethods.LOGBRUSH lb);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr CreateDIBSection(IntPtr hdc, [In, MarshalAs(UnmanagedType.LPStruct)]NativeMethods.BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport("gdi32.dll")]
        public static extern bool PtInRegion(IntPtr hRgn, int x, int y);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string strDriver, string strDevice, string strOutput, IntPtr pData);

        [DllImport("gdi32.dll")]
        public static extern int GetPixel(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll", EntryPoint = "SaveDC", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SaveDC(HandleRef hDC);

        [DllImport("gdi32.dll", EntryPoint = "RestoreDC", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool RestoreDC(HandleRef hDC, int nSavedDC);

        #endregion

        #region COMCTL32

        [DllImport("comctl32.dll", ExactSpelling = true)]
        public static extern bool _TrackMouseEvent(NativeMethods.TRACKMOUSEEVENT tme);

        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControlsEx(NativeMethods.INITCOMMONCONTROLSEX icc);

        #endregion

        #region Multi-Touch Support

        [StructLayout(LayoutKind.Sequential)]
        public struct GESTURECONFIG
        {
            public uint dwID;
            public uint dwWant;
            public uint dwBlock;
        }

        [DllImport("user32")]
        public static extern bool SetGestureConfig(IntPtr hwnd, uint dwReserved, uint cIDs, GESTURECONFIG[] pGestureConfig, uint cbSize);

        public static double GID_ROTATE_ANGLE_FROM_ARGUMENT(ulong arg) { return ((((double)arg / 65535.0) * 4.0 * 3.14159265) - 2.0 * 3.14159265); }

        public const int WM_GESTURE = 0x0119;

        public const int GID_BEGIN = 1;
        public const int GID_END = 2;
        public const int GID_ZOOM = 3;
        public const int GID_PAN = 4;
        public const int GID_ROTATE = 5;
        public const int GID_TWOFINGERTAP = 6;
        public const int GID_PRESSANDTAP = 7;

        public const uint GC_ALLGESTURES = 0x00000001;
        public const uint GC_PAN = 0x00000001;
        public const uint GC_PAN_WITH_SINGLE_FINGER_VERTICALLY = 0x00000002;
        public const uint GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY = 0x00000004;
        public const uint GC_PAN_WITH_GUTTER = 0x00000008;
        public const uint GC_PAN_WITH_INERTIA = 0x00000010;
        public const uint GC_ZOOM = 0x00000001;
        public const uint GC_ROTATE = 0x00000001;
        public const uint GC_TWOFINGERTAP = 0x00000001;
        public const uint GC_PRESSANDTAP = 0x00000001;

        public const uint GF_BEGIN = 0x00000001;
        public const uint GF_INERTIA = 0x00000002;
        public const uint GF_END = 0x00000004;

        public static ushort LoWord(uint number)
        {
            return (ushort)(number & 0xffff);
        }

        public static ushort HiWord(uint number)
        {
            return (ushort)((number >> 16) & 0xffff);
        }

        public static uint LoDWord(ulong number)
        {
            return (uint)(number & 0xffffffff);
        }

        public static uint HiDWord(ulong number)
        {
            return (uint)((number >> 32) & 0xffffffff);
        }

        public static short LoWord(int number)
        {
            return (short)number;
        }

        public static short HiWord(int number)
        {
            return (short)(number >> 16);
        }

        public static int LoDWord(long number)
        {
            return (int)(number);
        }

        public static int HiDWord(long number)
        {
            return (int)((number >> 32));
        }

        #endregion

        #region Get Font DPI

        /// <summary>Determines the current screen resolution in DPI.</summary>
        /// <returns>Point.X is the X DPI, Point.Y is the Y DPI.</returns>
        public static Point GetSystemDpi()
        {
            Point result = new Point();

            IntPtr hDC = DeviceCapsNativeMethods.GetDC(IntPtr.Zero);

            result.X = DeviceCapsNativeMethods.GetDeviceCaps(hDC, DeviceCapsNativeMethods.LOGPIXELSX);
            result.Y = DeviceCapsNativeMethods.GetDeviceCaps(hDC, DeviceCapsNativeMethods.LOGPIXELSY);

            DeviceCapsNativeMethods.ReleaseDC(IntPtr.Zero, hDC);

            return result;
        }

        /// <summary>
        /// Checks if font is not default.
        /// </summary>
        /// <returns>True if font DPI is not 96.</returns>
        public static bool IsDifferentFont()
        {
            Point result = GetSystemDpi();

            return result.X != 96 || result.Y != 96;
        }

        private static class DeviceCapsNativeMethods
        {
            public static readonly int LOGPIXELSX = 88;    // Used for GetDeviceCaps().
            public static readonly int LOGPIXELSY = 90;    // Used for GetDeviceCaps().

            [DllImport("gdi32.dll")]
            public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

            [DllImport("user32.dll")]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        }

        #endregion

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        public static IntPtr GetDCEx(HandleRef hWnd, HandleRef hrgnClip, int flags)
        {
            return HandleCollector.Add(IntGetDCEx(hWnd, hrgnClip, flags), NativeMethods.CommonHandles.HDC);
        }

        public static IntPtr GetWindowDC(HandleRef hWnd)
        {
            return HandleCollector.Add(IntGetWindowDC(hWnd), NativeMethods.CommonHandles.HDC);
        }

        public static IntPtr CreateCompatibleDC(HandleRef hDC)
        {
            return HandleCollector.Add(IntCreateCompatibleDC(hDC), NativeMethods.CommonHandles.CompatibleHDC);
        }

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        public static IntPtr WindowFromPoint(int x, int y)
        {
            POINTSTRUCT pointstruct1 = new POINTSTRUCT(x, y);
            return _WindowFromPoint(pointstruct1);
        }

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        #region GetObject

        public static int GetObject(HandleRef hObject, NativeMethods.LOGBRUSH lb)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(NativeMethods.LOGBRUSH)), lb);
        }

        public static int GetObject(HandleRef hObject, LOGFONT lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(LOGFONT)), lp);
        }

        public static int GetObject(HandleRef hObject, LOGPEN lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(LOGPEN)), lp);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, ref int nEntries);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] BITMAP bm);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] LOGPEN lp);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, int[] nEntries);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] LOGBRUSH lb);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] LOGFONT lf);

        #endregion

        public static void UpdateZOrder(HandleRef handle, HandleRef pos, bool activate)
        {
            int flags = 0x603;
            if (!activate)
            {
                flags |= 0x10;
            }
            NativeMethods.SetWindowPos(handle, pos, 0, 0, 0, 0, flags);
        }

        #region RadToolTip

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, HandleRef dwNewLong);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);

        [DllImport("user32")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        public static extern uint GetClassLongPtr32(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        public static extern IntPtr GetClassLongPtr64(HandleRef hWnd, int nIndex);

        public static IntPtr GetClassLongPtr(HandleRef hWnd, int nIndex)
        {
            if (IntPtr.Size > 4)
                return GetClassLongPtr64(hWnd, nIndex);
            else
                return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
        }

        [DllImport("user32.dll", EntryPoint = "SetClassLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClassLongPtr32(HandleRef hwnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetClassLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClassLongPtr64(HandleRef hwnd, int nIndex, IntPtr dwNewLong);

        public static IntPtr SetClassLong(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetClassLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetClassLongPtr64(hWnd, nIndex, dwNewLong);
        }

        //[DllImport("user32.dll", SetLastError = true, ExactSpelling = true)]
        //public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        #endregion

        #region RadDock

        [Flags]
        public enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        public enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        [DllImport("user32.dll", EntryPoint = "AnimateWindow", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool AnimateWindow(IntPtr hwnd, int time, AnimateWindowFlags flags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetTopWindow(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

        #endregion

        #region PDF export

        public delegate int FontEnumDelegate([MarshalAs(UnmanagedType.Struct)] ref EnumLogFont lpelf, [MarshalAs(UnmanagedType.Struct)] ref NewTextMetric lpntm, int fontType, int lParam);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct EnumLogFont
        {
            public LOGFONT elfLogFont;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] elfFullName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public char[] elfStyle;
        } ;

        [StructLayout(LayoutKind.Sequential)]
        public class GlyphSet
        {
            public int cbThis = 0;
            public int flAccel = 0;
            public int cGlyphsSupported = 0;
            public int cRanges = 0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20000)]
            public byte[] ranges = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct NewTextMetric
        {
            public long tmHeight;
            public long tmAscent;
            public long tmDescent;
            public long tmInternalLeading;
            public long tmExternalLeading;
            public long tmAvecharWidth;
            public long tmMaxcharWidth;
            public long tmWeight;
            public long tmOverhang;
            public long tmDigitizedAspectX;
            public long tmDigitizedAspectY;
            public char tmFirstchar;
            public char tmLastchar;
            public char tmDefaultchar;
            public char tmBreakchar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmcharSet;
            public ulong ntmFlags;
            public int ntmSizeEM;
            public int ntmCellHeight;
            public int ntmAvgWidth;
        }

        public enum GdiDcObject
        {
            Pen = 1,
            Brush = 2,
            Pal = 5,
            Font = 6,
            Bitmap = 7
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetTextFace(IntPtr hdc, int nCount, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpFaceName);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetFontUnicodeRanges(IntPtr hdc, [Out, MarshalAs(UnmanagedType.LPStruct)]GlyphSet lpgs);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetFontData(IntPtr hdc, int dwTable, int dwOffset, [MarshalAs(UnmanagedType.LPArray)]byte[] lpvBuffer, int cbData);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int GetGlyphIndices(IntPtr hdc, string lpstr, int c, [MarshalAs(UnmanagedType.LPArray)]Int16[] pgi, int fl);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentObject(IntPtr hdc, GdiDcObject uObjectType);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentObject(HandleRef hdc, int uObjectType);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int EnumFontFamilies(IntPtr hdc, [MarshalAs(UnmanagedType.LPTStr)] string lpszFamily, FontEnumDelegate lpEnumFontFamProc, int lParam);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int EnumFontFamiliesEx(IntPtr hdc, [MarshalAs(UnmanagedType.LPStruct)] LOGFONT lplf, FontEnumDelegate lpEnumFontFamProc, int lParam, int dwFlags);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFontIndirect([MarshalAs(UnmanagedType.LPStruct)]LOGFONT lplf);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int AddFontResourceEx([In, MarshalAs(UnmanagedType.LPTStr)]string lpszFilename, int fl, int pdv);

        #endregion

        public static Region CreateRoundRectRgn(Rectangle bounds, int radius)
        {
            IntPtr region = NativeMethods.CreateRoundRectRgn(bounds.X, bounds.Y, bounds.Width + 1, bounds.Height + 1, radius, radius);
            Region roundRegion = Region.FromHrgn(region);
            //NativeMethods.DeleteObject(new HandleRef(null, region));
            NativeMethods.DeleteObject(region);
            return roundRegion;
        }

        public static IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, IntPtr lpvBits)
        {
            return HandleCollector.Add(IntCreateBitmap(nWidth, nHeight, nPlanes, nBitsPerPixel, lpvBits), CommonHandles.GDI);
        }

        public static IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, byte[] lpvBits)
        {
            return HandleCollector.Add(IntCreateBitmapByte(nWidth, nHeight, nPlanes, nBitsPerPixel, lpvBits), CommonHandles.GDI);
        }

        public static IntPtr CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits)
        {
            return HandleCollector.Add(IntCreateBitmapShort(nWidth, nHeight, nPlanes, nBitsPerPixel, lpvBits), CommonHandles.GDI);
        }

        public static IntPtr CreateBrushIndirect(NativeMethods.LOGBRUSH lb)
        {
            return HandleCollector.Add(IntCreateBrushIndirect(lb), NativeMethods.CommonHandles.GDI);
        }

        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath,
                                    uint dwFileAttributes,
                                    ref SHFILEINFO psfi,
                                    uint cbSizeFileInfo,
                                    uint uFlags);



        #region FindWindow

        /// <summary>
        /// <para>返回与指定字符串相匹配的窗口类名或窗口名的最顶层窗口的窗口句柄</para>
        /// <para>如果函数执行成功，则返回值是拥有指定窗口类名或窗口名的窗口的句柄。</para>
        /// <para>如果函数执行失败，则返回值为 NULL 。</para>
        /// <para>可以通过调用GetLastError函数获得更加详细的错误信息。</para>
        /// </summary>
        /// <param name="lpClassName">指向包含了窗口类名的空中止(C语言)字串的指针;或设为零,表示接收任何类</param>
        /// <param name="lpWindowName">指向包含了窗口文本(或标签)的空中止(C语言)字串的指针;或设
        /// 为零,表示接收任何窗口标题</param>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwndParent">
        /// <para>在其中查找子的父窗口。</para>
        /// <para>如设为零，表示使用桌面窗口</para>
        /// <para>（通常说的顶级窗口都被认为是桌面的子窗口，所以也会对它们进行查找）</para>
        /// </param>
        /// <param name="hwndChildAfter">
        /// <para>，从这个窗口后开始查找。</para>
        /// <para>这样便可利用对FindWindowEx的多次调用找到符合条件的所有子窗口。</para>
        /// <para>如设为零，表示从第一个子窗口开始搜索</para>
        /// </param>
        /// <param name="lpClassName">欲搜索的类名。零表示忽略</param>
        /// <param name="lpWindowName">欲搜索的类名。零表示忽略</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

        #endregion

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        /// <summary>
        /// <para>该函数获取窗口客户区的坐标。</para>
        /// <para>客户区坐标指定客户区的左上角和右下角。</para>
        /// <para>由于客户区坐标是相对窗口客户区的左上角而言的，因此左上角坐标为（0，0）</para>
        /// </summary>
        /// <param name="hWnd">目标窗口</param>
        /// <param name="lpRect">指定一个矩形，用客户区域的大小载入（以像素为单位）</param>
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(int hWnd, ref RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, ref RECT r);
        /// <summary>
        /// <para>该函数检取光标的位置，以屏幕坐标表示。</para>
        /// <para>返回值：如果成功，返回值非零；如果失败，返回值为零。</para>
        /// </summary>
        /// <param name="lpPoint">随同指针在屏幕像素坐标中的位置载入的一个结构</param>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref POINT lpPoint);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool PtInRect(ref RECT lprc, POINT pt);

    }
}
