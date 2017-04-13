using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace CCWin
{
    //控件层
    public partial class SkinMain : Form
    {
        //绘制层
        private SkinForm skin;
        public SkinMain()
        {
            InitializeComponent();
            //减少闪烁
            SetStyles();
            //初始化
            Init();
        }
        #region 初始化
        private void Init()
        {
            //不显示在Windows任务栏中
            ShowInTaskbar = false;
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

        #region 全部显示
        public void AllShow()
        {
            this.Show();
            if (skin != null)
            {
                skin.Show();
            }
        }
        #endregion

        #region 全部隐藏
        public void AllHide()
        {
            skin.Hide();
            this.Hide();
        }
        #endregion

        #region 变量属性
        private int _gradienttime = 200;
        [Category("Skin")]
        [DefaultValue(200)]
        [Description("控件层渐变特效时长(越小越快)")]
        public int GradientTime
        {
            get { return _gradienttime; }
            set
            {
                if (_gradienttime != value)
                {
                    _gradienttime = value < 0 ? 0 : value;
                }
            }
        }

        private Size _skinsize;
        [Category("Skin")]
        [Description("绘图层窗口大小")]
        public Size SkinSize
        {
            get { return _skinsize; }
            set
            {
                if (_skinsize != value)
                {
                    _skinsize = value;
                    if (skin != null)
                    {
                        skin.Size = _skinsize;
                    }
                    //验证下宽高
                    BindSize();
                    //重新应用下绘图层背景
                    BindBack();
                }
            }
        }

        //不显示FormBorderStyle属性
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FormBorderStyle FormBorderStyle
        {
            get { return base.FormBorderStyle; }
            set { base.FormBorderStyle = FormBorderStyle.None; }
        }

        private Bitmap _skinback;
        [Category("Skin")]
        [Description("绘图层窗口背景")]
        public Bitmap SkinBack
        {
            get { return _skinback; }
            set
            {
                if (_skinback != value)
                {
                    _skinback = value;
                    //重新应用下绘图层背景
                    BindBack();
                    if (skin != null)
                    {
                        Bitmap bitmap = new Bitmap(SkinBack, SkinSize);
                        if (SkinTrankColor != Color.Transparent)
                        {
                            bitmap.MakeTransparent(SkinTrankColor);
                        }
                        skin.BackgroundImage = bitmap;
                    }
                }
            }
        }

        private int _skinopacity = 255;
        [Browsable(true)]
        [Category("Skin")]
        [Description("绘图层窗口透明度(0-255)")]
        [DefaultValue(255)]
        public int SkinOpacity
        {
            get { return _skinopacity; }
            set
            {
                if (_skinopacity != value)
                {
                    //如果赋值大与255，就等于255
                    _skinopacity = value > 255 ? 255 : value;
                    if (skin != null)
                    {
                        skin.SetBits();
                    }
                }
            }
        }


        private Point _mainposition;
        [Category("Skin")]
        [Description("窗口在绘图层位置")]
        public Point MainPosition
        {
            get { return _mainposition; }
            set
            {
                if (_mainposition != value)
                {
                    _mainposition = value;
                    //验证下宽高
                    BindSize();
                    //重新应用下绘图层背景
                    BindBack();
                    if (skin != null)
                    {
                        Location = new Point(skin.Left + MainPosition.X, skin.Top + MainPosition.Y);
                    }
                }
            }
        }

        private Color _skintrankcolor = Color.Transparent;
        [Category("Skin")]
        [Description("绘图层需要透明的颜色")]
        [DefaultValue(typeof(Color), "Color.Transparent")]
        public Color SkinTrankColor
        {
            get { return _skintrankcolor; }
            set
            {
                if (_skintrankcolor != value)
                {
                    _skintrankcolor = value;
                    if (BackgroundImage != null)
                    {
                        backs();
                    }
                    if (skin != null)
                    {
                        Bitmap bitmap = new Bitmap(SkinBack, SkinSize);
                        if (SkinTrankColor != Color.Transparent)
                        {
                            bitmap.MakeTransparent(SkinTrankColor);
                        }
                        skin.BackgroundImage = bitmap;
                    }
                }
            }
        }

        private bool _skinwhethertank = true;
        [Category("Skin")]
        [Description("绘图层是否开启位图仿透明\r\n注意(SkinOpacity < 255时，此属性为False可达到背景透明，控件不透明的效果。)")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinWhetherTank
        {
            get { return _skinwhethertank; }
            set
            {
                if (_skinwhethertank != value)
                {
                    _skinwhethertank = value;
                    if (skin != null)
                    {
                        BindBack();

                    }
                }
            }
        }

        private bool _skinshowintaskbar = true;
        [Category("Skin")]
        [Description("绘图层是否出现在Windows任务栏中。")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinShowInTaskbar
        {
            get { return _skinshowintaskbar; }
            set
            {
                if (_skinshowintaskbar != value)
                {
                    _skinshowintaskbar = value;
                }
            }
        }

        private bool _skinmobile = true;
        [Category("Skin")]
        [Description("窗体是否可以移动")]
        [DefaultValue(typeof(bool), "true")]
        public bool SkinMobile
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

        #region 绑定背景
        public void BindBack()
        {
            //绘图层背景属性不等于空，绘图层宽高不等于0，控件层宽高不等于0时才绑定背景
            if (_skinback != null && SkinSize != new Size(0, 0) && this.Size != new Size(0, 0))
            {
                //在设计器时，始终显示裁剪背景
                if (DesignMode)
                {
                    backs();
                }
                else
                {
                    if (SkinWhetherTank)
                    {
                        backs();
                    }
                    else
                    {
                        BackgroundImage = null;
                    }
                }
            }
        }

        //裁剪透明做背景
        public void backs()
        {
            ////裁剪下图片
            //Bitmap back = new Bitmap(SkinBack, _skinsize);
            //Rectangle cloneRect = new Rectangle(_mainposition.X, _mainposition.Y, Width, Height);
            //PixelFormat format = back.PixelFormat;
            //Bitmap cloneBitmap = back.Clone(cloneRect, format);
            //if (SkinTrankColor != Color.Transparent)
            //{
            //    cloneBitmap.MakeTransparent(_skintrankcolor);
            //}
            ////将裁剪好的图片给控件层赋值
            //this.BackgroundImage = cloneBitmap;
            //BackgroundImage = null;
            //BackColor = Color.Red;
            TransparencyKey = BackColor;
        }
        #endregion

        #region 验证大小
        private void BindSize()
        {
            //判断控件层和绘图层宽高都不等于0时
            if (Width != 0 && Height != 0 && SkinSize != new Size(0, 0))
            {
                //控件层宽度 大于 (绘图层宽度 - 控件层所在绘图层X值)时
                if (Width > SkinSize.Width - MainPosition.X)
                {
                    //等于最大限制的宽度
                    Width = SkinSize.Width - MainPosition.X;
                }
                //控件层宽度 大于 (绘图层宽度 - 控件层所在绘图层Y值)时
                if (Height > SkinSize.Height - MainPosition.Y)
                {
                    //等于最大限制的高度
                    Height = SkinSize.Height - MainPosition.Y;
                }
            }
        }
        #endregion

        #region 重载事件
        //窗体加载时
        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                skin = new SkinForm(this);
                skin.Show();
                //淡入特效
                //Win32.AnimateWindow(this.Handle, GradientTime, Win32.AW_CENTER | Win32.AW_ACTIVATE);
            }
            base.OnLoad(e);
        }

        //窗体关闭时
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Owner.Close();
            base.OnClosing(e);
        }

        //大小改变时
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //控制层宽高 大于或等于 （绘制层宽高 - 控制层在绘图层的位置XY）时重新绑定背景 
            if (Width <= (SkinSize.Width - MainPosition.X) && Height <= (SkinSize.Height - MainPosition.Y))
            {
                BindBack();
            }
            else
            {
                //否则重新验证宽高大小，并给出回馈
                BindSize();
            }
        }
        #endregion

        private void SkinMain_Load(object sender, EventArgs e)
        {
            BackgroundImage = null;
            TransparencyKey = BackColor;

        }
    }
}
