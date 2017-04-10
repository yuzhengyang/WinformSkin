using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HollowForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetWindowLong(Handle, GWL_EXSTYLE, WS_EX_LAYERED);
            SetLayeredWindowAttributes(Handle, 0x00FF00, 255, LWA_COLORKEY);//替换某种颜色为透明（0x00FF00：绿色）
        }
        private const uint WS_EX_LAYERED = 0x80000;//异形窗体特效的实现
        private const int GWL_EXSTYLE = -20;//设定一个新的扩展风格
        private const int LWA_COLORKEY = 1;//透明方式
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        //改变指定窗口的属性
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        //设置分层窗口透明度
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

        private void Form1_Load(object sender, EventArgs e)
        {
            //TransparencyKey = BackColor;
        }
    }
}
