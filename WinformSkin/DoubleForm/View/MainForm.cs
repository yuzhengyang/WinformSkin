using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleForm.View
{
    public partial class MainForm : Form
    {
        private SkinForm Skin;
        public MainForm()
        {
            InitializeComponent();
            //SetStyles();//减少闪烁
            ShowInTaskbar = false;//禁止控件层显示到任务栏
            FormBorderStyle = FormBorderStyle.None;//设置无边框的窗口样式
            Thread.Sleep(1000);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Skin = new SkinForm(this);//创建皮肤层 
                BackgroundImage = null;//去除控件层背景
                TransparencyKey = BackColor;//使控件层背景透明
                Skin.Show();//显示皮肤层 
            }
            Thread.Sleep(1000);
        }

        #region 属性
        private bool _skinmobile = true;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMovable
        {
            get { return _skinmobile; }
            set
            {
                if (_skinmobile != value)
                {
                    _skinmobile = value;
                }
            }
        }
        #endregion
        #region 减少闪烁
        private void SetStyles()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            //强制分配样式重新应用到控件上
            UpdateStyles();
            base.AutoScaleMode = AutoScaleMode.None;
        }
        #endregion
    }
}
