using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Client.UI.Base.Enums;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using Client.UI.Base.Animations;
using Client.UI.Base.Utils;
using Client.UI.DefaultResource;

namespace Client.UI.Contorls
{
    public delegate void UpDownButtonPaintEventHandler(object sender, UpDownButtonPaintEventArgs e);
    [ToolboxBitmap(typeof(TabControl))]
    public class UITabControl : TabControl
    {
        private const string UpDownButtonClassName = "msctls_updown32";
        private UIAnimator animator;
        private UITabControl.UpDownButtonNativeWindow _upDownButtonNativeWindow;
        private Color _pagebaseColor;
        private Color _arrowbaseColor;
        private Color _backColor;
        private Color _pageborderColor;
        private Color _arrowborderColor;
        private Color _arrowColor;
        private UITabControl.ePageImagePosition pageImagePosition;
        private ContentAlignment pageTextAlign;
        private int radius;
        private int imgTxtSpace;
        private static readonly object EventPaintUpDownButton;
        private DrawStyle drawType;
        private bool itemStretch;
        private System.Drawing.Size imgSize;
        private bool pagepalace;
        private Rectangle pagebackrectangle;
        private bool animationStart;
        private Rectangle _btnArrowRect;
        private bool _isFocus;
        private Rectangle _closeRect;
        private bool pageCloseLeftToRight;
        private bool pageCloseVisble;
        private Image pageCloseHover;
        private Image pageCloseNormal;
        private Image pageArrowHover;
        private Image pageArrowDown;
        private bool pageArrowVisble;
        private Image pageNorml;
        private Image pageHover;
        private Image pageDown;
        private bool OneShow;
        private Rectangle selectPageClose;

        [Category("PageClose")]
        [Description("Page关闭按钮的位置及大小。")]
        public Rectangle CloseRect
        {
            get
            {
                return this._closeRect;
            }
            set
            {
                this._closeRect = value;
                this.Invalidate();
            }
        }

        [Description("Page关闭按钮位置是否在右。")]
        [DefaultValue(typeof(bool), "true")]
        [Category("PageClose")]
        public bool PageCloseLeftToRight
        {
            get
            {
                return this.pageCloseLeftToRight;
            }
            set
            {
                if (this.pageCloseLeftToRight == value)
                    return;
                this.pageCloseLeftToRight = value;
                this.Invalidate();
            }
        }

        [Category("PageClose")]
        [Description("Page是否开启关闭按钮")]
        [DefaultValue(typeof(bool), "false")]
        public bool PageCloseVisble
        {
            get
            {
                return this.pageCloseVisble;
            }
            set
            {
                if (this.pageCloseVisble == value)
                    return;
                this.pageCloseVisble = value;
                this.Invalidate();
            }
        }

        [Description("Page关闭按钮悬浮时图像")]
        [Category("PageClose")]
        public Image PageCloseHover
        {
            get
            {
                return this.pageCloseHover;
            }
            set
            {
                this.pageCloseHover = value;
                this.Invalidate(true);
            }
        }

        [Category("PageClose")]
        [Description("Page关闭按钮默认图像")]
        public Image PageCloseNormal
        {
            get
            {
                return this.pageCloseNormal;
            }
            set
            {
                this.pageCloseNormal = value;
                this.Invalidate(true);
            }
        }

        [Category("Page")]
        [DefaultValue(typeof(int), "4")]
        [Description("选项卡文本与图标之间的间隙")]
        public int ImgTxtSpace
        {
            get
            {
                return this.imgTxtSpace;
            }
            set
            {
                this.imgTxtSpace = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(DrawStyle), "1")]
        [Category("Page")]
        [Description("选项卡标签的绘画模式")]
        public DrawStyle DrawType
        {
            get
            {
                return this.drawType;
            }
            set
            {
                if (this.drawType == value)
                    return;
                this.drawType = value;
                this.Invalidate();
            }
        }

        [Category("Page")]
        [Description("选项卡标签大小是否可以自动拉伸")]
        [DefaultValue(typeof(bool), "false")]
        public bool ItemStretch
        {
            get
            {
                return this.itemStretch;
            }
            set
            {
                if (this.Alignment != TabAlignment.Top && this.Alignment != TabAlignment.Bottom && !this.ItemStretch)
                {
                    int num = (int)MessageBox.Show("自动拉伸不支持左右选项卡模式。", "界面库提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.itemStretch = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Page")]
        [DefaultValue(typeof(System.Drawing.Size), "20,20")]
        [Description("选项卡上图标的大小")]
        public System.Drawing.Size ImgSize
        {
            get
            {
                return this.imgSize;
            }
            set
            {
                if (!(this.imgSize != value))
                    return;
                this.imgSize = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(bool), "false")]
        [Description("Page是否开启九宫绘图")]
        [Category("Page")]
        public bool PagePalace
        {
            get
            {
                return this.pagepalace;
            }
            set
            {
                if (this.pagepalace == value)
                    return;
                this.pagepalace = value;
                this.Invalidate();
            }
        }

        [Category("Page")]
        [Description("Page九宫绘画区域")]
        [DefaultValue(typeof(Rectangle), "10,10,10,10")]
        public Rectangle PageBackRectangle
        {
            get
            {
                return this.pagebackrectangle;
            }
            set
            {
                if (this.pagebackrectangle != value)
                    this.pagebackrectangle = value;
                this.Invalidate();
            }
        }

        [Category("PageArrow")]
        [Description("PageArrow菜单箭头悬浮时背景")]
        public Image PageArrowHover
        {
            get
            {
                return this.pageArrowHover;
            }
            set
            {
                this.pageArrowHover = value;
                this.Invalidate(true);
            }
        }

        [Category("PageArrow")]
        [Description("PageArrow菜单箭头按下时背景")]
        public Image PageArrowDown
        {
            get
            {
                return this.pageArrowDown;
            }
            set
            {
                this.pageArrowDown = value;
                this.Invalidate(true);
            }
        }

        [Description("PageArrow菜单箭头是否显示")]
        [DefaultValue(true)]
        [Category("PageArrow")]
        public bool PageArrowVisble
        {
            get
            {
                return this.pageArrowVisble;
            }
            set
            {
                this.pageArrowVisble = value;
                this.Invalidate(true);
            }
        }

        [Description("Page标签默认背景")]
        [Category("Page")]
        public Image PageNorml
        {
            get
            {
                return this.pageNorml;
            }
            set
            {
                this.pageNorml = value;
                this.Invalidate(true);
            }
        }

        [Category("Page")]
        [Description("Page标签悬浮时背景")]
        public Image PageHover
        {
            get
            {
                return this.pageHover;
            }
            set
            {
                this.pageHover = value;
                this.Invalidate(true);
            }
        }

        [Category("Page")]
        [Description("Page标签按下时背景")]
        public Image PageDown
        {
            get
            {
                return this.pageDown;
            }
            set
            {
                this.pageDown = value;
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(int), "6")]
        [Category("Page")]
        [Description("选项卡的圆角弧度")]
        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value < 1 ? 1 : value;
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(UITabControl.ePageImagePosition), "Overlay")]
        [Description("指定选项卡上图像与文本的对齐方式")]
        [Category("Page")]
        public UITabControl.ePageImagePosition PageImagePosition
        {
            get
            {
                return this.pageImagePosition;
            }
            set
            {
                this.pageImagePosition = value;
                this.Invalidate(true);
            }
        }

        [Description("将在选项卡标签上显示的文本的对齐方式")]
        [Category("Page")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment PageTextAlign
        {
            get
            {
                return this.pageTextAlign;
            }
            set
            {
                this.pageTextAlign = value;
                this.Invalidate(true);
            }
        }

        [Category("Skin")]
        [Description("动画效果控制")]
        public AnimationType AnimatorType
        {
            get
            {
                return this.animator.AnimationType;
            }
            set
            {
                if (value == this.animator.AnimationType)
                    return;
                this.animator.AnimationType = value;
            }
        }

        [Description("设置动画")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Category("Skin")]
        public Animation Animation
        {
            get
            {
                return this.animator.DefaultAnimation;
            }
            set
            {
                if (value == this.animator.DefaultAnimation)
                    return;
                this.animator.DefaultAnimation = value;
            }
        }

        [Description("是否开启动画切换效果")]
        [DefaultValue(typeof(bool), "true")]
        [Category("Skin")]
        public bool AnimationStart
        {
            get
            {
                return this.animationStart;
            }
            set
            {
                if (this.animationStart == value)
                    return;
                this.animationStart = value;
            }
        }

        [Category("Page")]
        [DefaultValue(typeof(Color), "166, 222, 255")]
        [Description("选项卡标签的背景色")]
        public Color PageBaseColor
        {
            get
            {
                return this._pagebaseColor;
            }
            set
            {
                this._pagebaseColor = value;
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                this._backColor = value;
                this.Invalidate(true);
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Category("Page")]
        [Description("边框颜色")]
        [DefaultValue(typeof(Color), "23, 169, 254")]
        public Color PageBorderColor
        {
            get
            {
                return this._pageborderColor;
            }
            set
            {
                this._pageborderColor = value;
                this.Invalidate(true);
            }
        }

        [Description("左右选项卡的箭头颜色")]
        [DefaultValue(typeof(Color), "0, 79, 125")]
        [Category("Arrow")]
        public Color ArrowColor
        {
            get
            {
                return this._arrowColor;
            }
            set
            {
                this._arrowColor = value;
                this.Invalidate(true);
            }
        }

        [Category("Arrow")]
        [Description("左右选项卡的箭头边框颜色")]
        [DefaultValue(typeof(Color), "23, 169, 254")]
        public Color ArrowBorderColor
        {
            get
            {
                return this._arrowborderColor;
            }
            set
            {
                this._arrowborderColor = value;
                this.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "166, 222, 255")]
        [Category("Arrow")]
        [Description("左右选项卡的箭头背景色")]
        public Color ArrowBaseColor
        {
            get
            {
                return this._arrowbaseColor;
            }
            set
            {
                this._arrowbaseColor = value;
                this.Invalidate(true);
            }
        }

        internal IntPtr UpDownButtonHandle
        {
            get
            {
                return this.FindUpDownButton();
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle displayRectangle = base.DisplayRectangle;
                return new Rectangle(displayRectangle.Left - 4, displayRectangle.Top - 4, displayRectangle.Width + 8, displayRectangle.Height + 8);
            }
        }

        public event UpDownButtonPaintEventHandler PaintUpDownButton
        {
            add
            {
                this.Events.AddHandler(UITabControl.EventPaintUpDownButton, (Delegate)value);
            }
            remove
            {
                this.Events.RemoveHandler(UITabControl.EventPaintUpDownButton, (Delegate)value);
            }
        }

        static UITabControl()
        {
            UITabControl.EventPaintUpDownButton = new object();
        }

        public UITabControl()
        {
            this._pagebaseColor = Color.FromArgb(166, 222, (int)byte.MaxValue);
            this._arrowbaseColor = Color.FromArgb(166, 222, (int)byte.MaxValue);
            this._backColor = Color.Transparent;
            this._pageborderColor = Color.FromArgb(23, 169, 254);
            this._arrowborderColor = Color.FromArgb(23, 169, 254);
            this._arrowColor = Color.FromArgb(0, 79, 125);
            this.pageTextAlign = ContentAlignment.MiddleCenter;
            this.radius = 6;
            this.imgTxtSpace = 4;
            this.drawType = DrawStyle.Img;
            this.imgSize = new System.Drawing.Size(20, 20);
            this.pagebackrectangle = new Rectangle(10, 10, 10, 10);
            this.animationStart = true;
            this._btnArrowRect = Rectangle.Empty;
            this._closeRect = new Rectangle(2, 2, 12, 12);
            this.pageCloseLeftToRight = true;
            this.pageCloseHover = GetDefaultResource.GetImage("Control.close_over.png");  //Resources.close_over;
            this.pageCloseNormal = GetDefaultResource.GetImage("Control.close_normal.png"); //Resources.close_normal;
            this.pageArrowHover = GetDefaultResource.GetImage("Control.main_tabbtn_highlight.png");  //Resources.main_tabbtn_highlight;
            this.pageArrowDown = GetDefaultResource.GetImage("Control.main_tabbtn_down.png");//Resources.main_tabbtn_down;
            this.pageHover = GetDefaultResource.GetImage("Control.main_tab_check.png");// Resources.main_tab_check;
            this.pageDown = GetDefaultResource.GetImage("Control.main_tab_highlight.png"); //Resources.main_tab_highlight;
            this.pageArrowVisble = true;
            this.selectPageClose = Rectangle.Empty;

            this.SetStyles();
            this.animator = new UIAnimator();
            this.animator.AnimationType = AnimationType.HorizSlide;
            this.animator.DefaultAnimation.TimeCoeff = 2f;
            this.animator.DefaultAnimation.AnimateOnlyDifferences = false;
            this.ItemSize = new System.Drawing.Size(70, 36);
            this.SizeMode = TabSizeMode.Fixed;
            this.BackColor = Color.Transparent;
        }

        protected virtual void OnPaintUpDownButton(UpDownButtonPaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle clipRectangle = e.ClipRectangle;
            Color baseColor1 = this._arrowbaseColor;
            Color borderColor1 = this._arrowborderColor;
            Color arrowColor1 = this._arrowColor;
            Color baseColor2 = this._arrowbaseColor;
            Color borderColor2 = this._arrowborderColor;
            Color arrowColor2 = this._arrowColor;
            Rectangle rect1 = clipRectangle;
            rect1.Width = clipRectangle.Width / 2 - 1;
            rect1.Height -= 2;
            Rectangle rect2 = clipRectangle;
            rect2.X = rect1.Right + 2;
            rect2.Width = clipRectangle.Width / 2 - 2;
            rect2.Height -= 2;
            if (this.Enabled)
            {
                if (e.MouseOver)
                {
                    if (e.MousePress)
                    {
                        if (e.MouseInUpButton)
                            baseColor1 = this.GetColor(this._arrowbaseColor, 0, -35, -24, -9);
                        else
                            baseColor2 = this.GetColor(this._arrowbaseColor, 0, -35, -24, -9);
                    }
                    else if (e.MouseInUpButton)
                        baseColor1 = this.GetColor(this._arrowbaseColor, 0, 35, 24, 9);
                    else
                        baseColor2 = this.GetColor(this._arrowbaseColor, 0, 35, 24, 9);
                }
            }
            else
            {
                baseColor1 = SystemColors.Control;
                borderColor1 = SystemColors.ControlDark;
                arrowColor1 = SystemColors.ControlDark;
                baseColor2 = SystemColors.Control;
                borderColor2 = SystemColors.ControlDark;
                arrowColor2 = SystemColors.ControlDark;
            }
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (!this.Enabled)
            {
                Color control = SystemColors.Control;
            }
            using (SolidBrush solidBrush = new SolidBrush(this._backColor))
            {
                clipRectangle.Inflate(1, 1);
                graphics.FillRectangle((Brush)solidBrush, clipRectangle);
            }
            this.RenderButton(graphics, rect1, baseColor1, borderColor1, arrowColor1, ArrowDirection.Left);
            this.RenderButton(graphics, rect2, baseColor2, borderColor2, arrowColor2, ArrowDirection.Right);
            UpDownButtonPaintEventHandler paintEventHandler = this.Events[UITabControl.EventPaintUpDownButton] as UpDownButtonPaintEventHandler;
            if (paintEventHandler == null)
                return;
            paintEventHandler((object)this, e);
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if ((this.OneShow && this.DesignMode || !this.DesignMode) && this.AnimationStart)
            {
                this.animator.BeginUpdateSync((Control)this, false, (Animation)null, new Rectangle(0, this.ItemSize.Height + 3, this.Width, this.Height - this.ItemSize.Height - 3));
                this.BeginInvoke(new MethodInvoker(() => this.animator.EndUpdate((Control)this)));
            }
            this.OneShow = true;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.DesignMode || e.Button != MouseButtons.Left)
                return;
            Rectangle tabRect = this.GetTabRect(this.SelectedIndex);
            Rectangle rectangle = new Rectangle(this.CloseRect.X + tabRect.X, this.CloseRect.Y + tabRect.Y, this.CloseRect.Width, this.CloseRect.Height);
            if (this._btnArrowRect.Contains(e.Location) && this.PageArrowVisble)
            {
                this._isFocus = true;
                this.Invalidate(this._btnArrowRect);
            }
            else
            {
                if (!this.selectPageClose.Contains(e.Location) || !this.PageCloseVisble)
                    return;
                this.TabPages.Remove(this.SelectedTab);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if ((this.Alignment == TabAlignment.Top || this.Alignment == TabAlignment.Bottom) && (this.ItemStretch && this.TabCount != 0))
            {
                this.Multiline = false;
                this.SizeMode = TabSizeMode.Fixed;
                System.Drawing.Size size = new System.Drawing.Size((this.Width - 3) / this.TabCount, this.ItemSize.Height);
                if (this.ItemSize != size)
                    this.ItemSize = size;
            }
            else if ((this.Alignment == TabAlignment.Left || this.Alignment == TabAlignment.Right) && this.ItemStretch)
                this.ItemStretch = false;
            this.DrawTabContrl(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!(this.UpDownButtonHandle != IntPtr.Zero) || this._upDownButtonNativeWindow != null)
                return;
            this._upDownButtonNativeWindow = new UITabControl.UpDownButtonNativeWindow(this);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!(this.UpDownButtonHandle != IntPtr.Zero) || this._upDownButtonNativeWindow != null)
                return;
            this._upDownButtonNativeWindow = new UITabControl.UpDownButtonNativeWindow(this);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (this._upDownButtonNativeWindow == null)
                return;
            this._upDownButtonNativeWindow.Dispose();
            this._upDownButtonNativeWindow = (UITabControl.UpDownButtonNativeWindow)null;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!(this.UpDownButtonHandle != IntPtr.Zero) || this._upDownButtonNativeWindow != null)
                return;
            this._upDownButtonNativeWindow = new UITabControl.UpDownButtonNativeWindow(this);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!(this.UpDownButtonHandle != IntPtr.Zero) || this._upDownButtonNativeWindow != null)
                return;
            this._upDownButtonNativeWindow = new UITabControl.UpDownButtonNativeWindow(this);
        }

        private void SetStyles()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        private IntPtr FindUpDownButton()
        {
            return NativeMethods.FindWindowEx(this.Handle, IntPtr.Zero, "msctls_updown32", (string)null);
        }

        private void DrawTabContrl(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            this.DrawDrawBackgroundAndHeader(graphics);
            this.DrawTabPages(e);
            this.DrawBorder(graphics);
        }

        private void DrawDrawBackgroundAndHeader(Graphics g)
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    x = 0;
                    y = 0;
                    width = this.ClientRectangle.Width;
                    height = this.ClientRectangle.Height - this.DisplayRectangle.Height;
                    break;
                case TabAlignment.Bottom:
                    x = 0;
                    y = this.DisplayRectangle.Height;
                    width = this.ClientRectangle.Width;
                    height = this.ClientRectangle.Height - this.DisplayRectangle.Height;
                    break;
                case TabAlignment.Left:
                    x = 0;
                    y = 0;
                    width = this.ClientRectangle.Width - this.DisplayRectangle.Width;
                    height = this.ClientRectangle.Height;
                    break;
                case TabAlignment.Right:
                    x = this.DisplayRectangle.Width;
                    y = 0;
                    width = this.ClientRectangle.Width - this.DisplayRectangle.Width;
                    height = this.ClientRectangle.Height;
                    break;
            }
            Rectangle rect = new Rectangle(x, y, width, height);
            using (SolidBrush solidBrush = new SolidBrush(this.Enabled ? this._backColor : SystemColors.Control))
            {
                g.FillRectangle((Brush)solidBrush, this.ClientRectangle);
                g.FillRectangle((Brush)solidBrush, rect);
            }
        }

        private void CalculateRect(TabPage page, Rectangle tabRect, out Rectangle imageRect, out Rectangle textRect)
        {
            System.Drawing.Size size = TextRenderer.MeasureText(page.Text, page.Font);
            int num = page.Text.Length == 0 ? 0 : this.ImgTxtSpace;
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            Image image = (Image)null;
            if (this.ImageList != null)
            {
                if (page.ImageIndex != -1)
                    image = this.ImageList.Images[page.ImageIndex];
                else if (page.ImageKey != null)
                    image = this.ImageList.Images[page.ImageKey];
            }
            if (image == null)
            {
                textRect = tabRect;
            }
            else
            {
                switch (this.PageImagePosition)
                {
                    case UITabControl.ePageImagePosition.Left:
                        if (this.PageTextAlign != ContentAlignment.BottomLeft && this.PageTextAlign != ContentAlignment.MiddleLeft && this.PageTextAlign != ContentAlignment.TopLeft)
                        {
                            if (this.PageTextAlign != ContentAlignment.BottomCenter && this.PageTextAlign != ContentAlignment.MiddleCenter && this.PageTextAlign != ContentAlignment.TopCenter)
                            {
                                imageRect = new Rectangle(tabRect.X + tabRect.Width - (size.Width + num) - this.ImgSize.Width, tabRect.Y + (tabRect.Height - this.ImgSize.Height) / 2, this.ImgSize.Width, this.ImgSize.Height);
                                textRect = new Rectangle(imageRect.Right + num, tabRect.Y + (tabRect.Height - size.Height) / 2, size.Width, size.Height);
                                break;
                            }
                            else
                            {
                                imageRect = new Rectangle(tabRect.X + (tabRect.Width - (this.ImgSize.Width + size.Width + num)) / 2, tabRect.Y + (tabRect.Height - this.ImgSize.Height) / 2, this.ImgSize.Width, this.ImgSize.Height);
                                textRect = new Rectangle(imageRect.Right + num, tabRect.Y + (tabRect.Height - size.Height) / 2, tabRect.Width - this.ImgSize.Width - (imageRect.X - tabRect.X) - num, size.Height);
                                break;
                            }
                        }
                        else
                        {
                            imageRect = new Rectangle(tabRect.X, tabRect.Y + (tabRect.Height - this.ImgSize.Height) / 2, this.ImgSize.Width, this.ImgSize.Height);
                            textRect = new Rectangle(imageRect.Right + num, tabRect.Y + (tabRect.Height - size.Height) / 2, tabRect.Width - this.ImgSize.Width - (imageRect.X - tabRect.X) - num, size.Height);
                            break;
                        }
                    case UITabControl.ePageImagePosition.Right:
                        if (this.PageTextAlign != ContentAlignment.BottomLeft && this.PageTextAlign != ContentAlignment.MiddleLeft && this.PageTextAlign != ContentAlignment.TopLeft)
                        {
                            if (this.PageTextAlign != ContentAlignment.BottomCenter && this.PageTextAlign != ContentAlignment.MiddleCenter && this.PageTextAlign != ContentAlignment.TopCenter)
                            {
                                imageRect = new Rectangle(tabRect.X + tabRect.Width - this.ImgSize.Width, tabRect.Y + (tabRect.Height - this.ImgSize.Height) / 2, this.ImgSize.Width, this.ImgSize.Height);
                                textRect = new Rectangle(imageRect.X - size.Width - num, tabRect.Y + (tabRect.Height - size.Height) / 2, size.Width, size.Height);
                                break;
                            }
                            else
                            {
                                imageRect = new Rectangle(tabRect.X + (tabRect.Width - (this.ImgSize.Width + size.Width + num)) / 2 + (size.Width + num), tabRect.Y + (tabRect.Height - this.ImgSize.Height) / 2, this.ImgSize.Width, this.ImgSize.Height);
                                textRect = new Rectangle(imageRect.X - size.Width - num, tabRect.Y + (tabRect.Height - size.Height) / 2, size.Width, size.Height);
                                break;
                            }
                        }
                        else
                        {
                            imageRect = new Rectangle(tabRect.X + size.Width + num, tabRect.Y + (tabRect.Height - this.ImgSize.Height) / 2, this.ImgSize.Width, this.ImgSize.Height);
                            textRect = new Rectangle(tabRect.X, tabRect.Y + (tabRect.Height - size.Height) / 2, size.Width, size.Height);
                            break;
                        }
                    case UITabControl.ePageImagePosition.Top:
                        imageRect = new Rectangle(tabRect.X + (tabRect.Width - this.ImgSize.Width) / 2, tabRect.Y + (tabRect.Height - (this.ImgSize.Height + size.Height + num)) / 2, this.ImgSize.Width, this.ImgSize.Height);
                        textRect = new Rectangle(tabRect.X, imageRect.Bottom + num, tabRect.Width, tabRect.Height - (imageRect.Bottom + num - tabRect.Top));
                        break;
                    case UITabControl.ePageImagePosition.Bottom:
                        imageRect = new Rectangle(tabRect.X + (tabRect.Width - this.ImgSize.Width) / 2, tabRect.Y + (tabRect.Height - (this.ImgSize.Height + size.Height + num)) / 2 + (size.Height + num), this.ImgSize.Width, this.ImgSize.Height);
                        textRect = new Rectangle(tabRect.X, tabRect.Y, tabRect.Width, imageRect.Y - tabRect.Y - num);
                        break;
                }
            }
        }

        private void DrawTabPages(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            System.Drawing.Point pt1 = this.PointToClient(Control.MousePosition);
            bool flag1 = false;
            bool flag2 = this.Alignment == TabAlignment.Top || this.Alignment == TabAlignment.Bottom;
            LinearGradientMode mode = LinearGradientMode.Vertical;
            if (flag2)
            {
                IntPtr downButtonHandle = this.UpDownButtonHandle;
                if (downButtonHandle != IntPtr.Zero && NativeMethods.IsWindowVisible(downButtonHandle))
                {
                    RECT lpRect = new RECT();
                    NativeMethods.GetWindowRect(downButtonHandle, ref lpRect);
                    Rectangle rect = this.RectangleToClient(Rectangle.FromLTRB(lpRect.Left, lpRect.Top, lpRect.Right, lpRect.Bottom));
                    switch (this.Alignment)
                    {
                        case TabAlignment.Top:
                            rect.Y = 0;
                            break;
                        case TabAlignment.Bottom:
                            rect.Y = this.ClientRectangle.Height - this.DisplayRectangle.Height;
                            break;
                    }
                    rect.Height = this.ClientRectangle.Height;
                    graphics.SetClip(rect, CombineMode.Exclude);
                    flag1 = true;
                }
            }
            for (int index = 0; index < this.TabCount; ++index)
            {
                TabPage page = this.TabPages[index];
                Rectangle rectangle = this.GetTabRect(index);
                if (this.ItemStretch && this.Width > 0 && (this.Alignment == TabAlignment.Top || this.Alignment == TabAlignment.Bottom))
                {
                    int width = this.Width / this.TabCount;
                    int height = this.ItemSize.Height;
                    int num = this.DrawType != DrawStyle.Draw ? 2 : 0;
                    rectangle = new Rectangle(index * width + num, rectangle.Y, width, height);
                }
                bool flag3 = rectangle.Contains(pt1);
                bool flag4 = this.SelectedIndex == index;
                Color baseColor1 = this._pagebaseColor;
                Color borderColor = this._pageborderColor;
                Image image1 = this.PageNorml;
                System.Drawing.Point pt2 = this.PointToClient(Control.MousePosition);
                if (flag4)
                {
                    baseColor1 = this.GetColor(this._pagebaseColor, 0, -45, -30, -14);
                    image1 = this.PageDown;
                }
                else if (flag3)
                {
                    baseColor1 = this.GetColor(this._pagebaseColor, 0, 35, 24, 9);
                    image1 = this.PageHover;
                }
                if (this.DrawType == DrawStyle.Img && image1 != null)
                {
                    int x = this.Alignment == TabAlignment.Right ? 1 : -2;
                    int y = this.Alignment == TabAlignment.Bottom ? 1 : -2;
                    rectangle.Offset(x, y);
                    if (this.PagePalace)
                        GraphicUtils.DrawRect(graphics, (Bitmap)image1, rectangle, Rectangle.FromLTRB(this.PageBackRectangle.X, this.PageBackRectangle.Y, this.PageBackRectangle.Width, this.PageBackRectangle.Height), 1, 1);
                    else
                        this.DrawImage(graphics, image1, rectangle);
                    if (flag4 && this.PageArrowVisble)
                    {
                        System.Drawing.Point screenLocation = this.PointToScreen(new System.Drawing.Point(this._btnArrowRect.Left, this._btnArrowRect.Top + this._btnArrowRect.Height + 5));
                        ContextMenuStrip contextMenuStrip = this.TabPages[index].ContextMenuStrip;
                        if (contextMenuStrip != null)
                        {
                            contextMenuStrip.Closed -= new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
                            contextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
                            if (screenLocation.X + contextMenuStrip.Width > Screen.PrimaryScreen.WorkingArea.Width - 20)
                                screenLocation.X = Screen.PrimaryScreen.WorkingArea.Width - contextMenuStrip.Width - 50;
                            Image image2;
                            if (rectangle.Contains(pt2))
                            {
                                if (this._isFocus)
                                {
                                    image2 = this.pageArrowDown;
                                    contextMenuStrip.Show(screenLocation);
                                }
                                else
                                    image2 = this.pageArrowHover;
                                this._btnArrowRect = new Rectangle(rectangle.X + rectangle.Width - image2.Width, rectangle.Y, image2.Width, rectangle.Height);
                            }
                            else if (this._isFocus)
                            {
                                image2 = this.pageArrowDown;
                                contextMenuStrip.Show(screenLocation);
                            }
                            else
                                image2 = (Image)null;
                            if (image2 != null)
                                this.DrawImage(graphics, image2, this._btnArrowRect);
                        }
                    }
                }
                else if (this.DrawType == DrawStyle.Draw)
                {
                    this.RenderTabBackgroundInternal(graphics, rectangle, baseColor1, borderColor, 0.45f, mode);
                }
                else
                {
                    int x = this.Alignment == TabAlignment.Right ? 1 : -2;
                    int y = this.Alignment == TabAlignment.Bottom ? 1 : -2;
                    rectangle.Offset(x, y);
                }
                Rectangle imageRect;
                Rectangle textRect;
                this.CalculateRect(page, rectangle, out imageRect, out textRect);
                this.DrawTabImage(graphics, page, imageRect);
                TextRenderer.DrawText((IDeviceContext)graphics, page.Text, page.Font, textRect, page.ForeColor, this.GetTextFormatFlags(this.PageTextAlign, page.RightToLeft == RightToLeft.Yes, page));
                if (this.PageCloseVisble)
                {
                    Rectangle rect = new Rectangle(this.CloseRect.X + rectangle.X, this.CloseRect.Y + rectangle.Y, this.CloseRect.Width, this.CloseRect.Height);
                    if (this.PageCloseLeftToRight)
                        rect = new Rectangle(rectangle.Right - this.CloseRect.Width - this.CloseRect.X, this.CloseRect.Y + rectangle.Y, this.CloseRect.Width, this.CloseRect.Height);
                    this.selectPageClose = rect.Contains(pt1) ? rect : this.selectPageClose;
                    if (this.DrawType == DrawStyle.Draw)
                    {
                        Color baseColor2 = rect.Contains(pt1) ? this.GetColor(this._pagebaseColor, 0, 35, 24, 9) : this._pagebaseColor;
                        this.RenderBackgroundInternal(graphics, rect, baseColor2, borderColor, 0.45f, true, LinearGradientMode.Vertical);
                        using (Pen pen = new Pen(Color.Black))
                        {
                            System.Drawing.Point pt1_1 = new System.Drawing.Point(rect.X + 3, rect.Y + 3);
                            System.Drawing.Point pt2_1 = new System.Drawing.Point(rect.X + rect.Width - 3, rect.Y + rect.Height - 3);
                            graphics.DrawLine(pen, pt1_1, pt2_1);
                            System.Drawing.Point pt1_2 = new System.Drawing.Point(rect.X + 3, rect.Y + rect.Height - 3);
                            System.Drawing.Point pt2_2 = new System.Drawing.Point(rect.X + rect.Width - 3, rect.Y + 3);
                            graphics.DrawLine(pen, pt1_2, pt2_2);
                        }
                    }
                    else if (this.DrawType == DrawStyle.Img)
                    {
                        Image image2 = rect.Contains(pt1) ? this.PageCloseHover : this.PageCloseNormal;
                        if (image2 != null)
                            graphics.DrawImage(image2, rect);
                    }
                }
            }
            if (!flag1)
                return;
            graphics.ResetClip();
        }

        private void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this._isFocus = false;
            this.Invalidate(this._btnArrowRect);
        }

        public TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft, TabPage page)
        {
            TextFormatFlags textFormatFlags1 = TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;
            TextFormatFlags textFormatFlags2 = !rightToleft ? textFormatFlags1 : textFormatFlags1 | TextFormatFlags.Right | TextFormatFlags.RightToLeft;
            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    textFormatFlags2 |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomRight:
                    textFormatFlags2 |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleRight:
                    textFormatFlags2 |= TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    textFormatFlags2 |= TextFormatFlags.Bottom;
                    break;
                case ContentAlignment.TopLeft:
                    textFormatFlags2 = textFormatFlags2;
                    break;
                case ContentAlignment.TopCenter:
                    textFormatFlags2 |= TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopRight:
                    textFormatFlags2 |= TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleLeft:
                    textFormatFlags2 |= TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleCenter:
                    textFormatFlags2 |= TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                    break;
            }
            Image image = (Image)null;
            if (this.ImageList != null)
            {
                if (page.ImageIndex != -1)
                    image = this.ImageList.Images[page.ImageIndex];
                else if (page.ImageKey != null)
                    image = this.ImageList.Images[page.ImageKey];
            }
            if ((this.PageImagePosition == UITabControl.ePageImagePosition.Left || this.PageImagePosition == UITabControl.ePageImagePosition.Right) && image != null)
                textFormatFlags2 = TextFormatFlags.Default;
            return textFormatFlags2;
        }

        private void DrawImage(Graphics g, Image image, Rectangle rect)
        {
            g.DrawImage(image, new Rectangle(rect.X, rect.Y, 5, rect.Height), 0, 0, 5, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height), 5, 0, image.Width - 10, image.Height, GraphicsUnit.Pixel);
            g.DrawImage(image, new Rectangle(rect.X + rect.Width - 5, rect.Y, 5, rect.Height), image.Width - 5, 0, 5, image.Height, GraphicsUnit.Pixel);
        }

        private void DrawBorder(Graphics g)
        {
            if (this.SelectedIndex == -1)
                return;
            Rectangle tabRect = this.GetTabRect(this.SelectedIndex);
            Rectangle clientRectangle = this.ClientRectangle;
            System.Drawing.Point[] points = new System.Drawing.Point[6];
            IntPtr downButtonHandle = this.UpDownButtonHandle;
            if (downButtonHandle != IntPtr.Zero && NativeMethods.IsWindowVisible(downButtonHandle))
            {
                RECT lpRect = new RECT();
                NativeMethods.GetWindowRect(downButtonHandle, ref lpRect);
                Rectangle rectangle = this.RectangleToClient(Rectangle.FromLTRB(lpRect.Left, lpRect.Top, lpRect.Right, lpRect.Bottom));
                tabRect.X = tabRect.X > rectangle.X ? rectangle.X : tabRect.X;
                tabRect.Width = tabRect.Right > rectangle.X ? rectangle.X - tabRect.X : tabRect.Width;
            }
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    points[0] = new System.Drawing.Point(tabRect.X, tabRect.Bottom);
                    points[1] = new System.Drawing.Point(clientRectangle.X, tabRect.Bottom);
                    points[2] = new System.Drawing.Point(clientRectangle.X, clientRectangle.Bottom - 1);
                    points[3] = new System.Drawing.Point(clientRectangle.Right - 1, clientRectangle.Bottom - 1);
                    points[4] = new System.Drawing.Point(clientRectangle.Right - 1, tabRect.Bottom);
                    points[5] = new System.Drawing.Point(tabRect.Right, tabRect.Bottom);
                    break;
                case TabAlignment.Bottom:
                    points[0] = new System.Drawing.Point(tabRect.X, tabRect.Y);
                    points[1] = new System.Drawing.Point(clientRectangle.X, tabRect.Y);
                    points[2] = new System.Drawing.Point(clientRectangle.X, clientRectangle.Y);
                    points[3] = new System.Drawing.Point(clientRectangle.Right - 1, clientRectangle.Y);
                    points[4] = new System.Drawing.Point(clientRectangle.Right - 1, tabRect.Y);
                    points[5] = new System.Drawing.Point(tabRect.Right, tabRect.Y);
                    break;
                case TabAlignment.Left:
                    points[0] = new System.Drawing.Point(tabRect.Right, tabRect.Y);
                    points[1] = new System.Drawing.Point(tabRect.Right, clientRectangle.Y);
                    points[2] = new System.Drawing.Point(clientRectangle.Right - 1, clientRectangle.Y);
                    points[3] = new System.Drawing.Point(clientRectangle.Right - 1, clientRectangle.Bottom - 1);
                    points[4] = new System.Drawing.Point(tabRect.Right, clientRectangle.Bottom - 1);
                    points[5] = new System.Drawing.Point(tabRect.Right, tabRect.Bottom);
                    break;
                case TabAlignment.Right:
                    points[0] = new System.Drawing.Point(tabRect.X, tabRect.Y);
                    points[1] = new System.Drawing.Point(tabRect.X, clientRectangle.Y);
                    points[2] = new System.Drawing.Point(clientRectangle.X, clientRectangle.Y);
                    points[3] = new System.Drawing.Point(clientRectangle.X, clientRectangle.Bottom - 1);
                    points[4] = new System.Drawing.Point(tabRect.X, clientRectangle.Bottom - 1);
                    points[5] = new System.Drawing.Point(tabRect.X, tabRect.Bottom);
                    break;
            }
            using (Pen pen = new Pen(this._pageborderColor))
                g.DrawLines(pen, points);
        }

        internal void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
        {
            System.Drawing.Point point = new System.Drawing.Point(dropDownRect.Left + dropDownRect.Width / 2, dropDownRect.Top + dropDownRect.Height / 2);
            System.Drawing.Point[] points;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new System.Drawing.Point[3]
          {
            new System.Drawing.Point(point.X + 1, point.Y - 4),
            new System.Drawing.Point(point.X + 1, point.Y + 4),
            new System.Drawing.Point(point.X - 2, point.Y)
          };
                    break;
                case ArrowDirection.Up:
                    points = new System.Drawing.Point[3]
          {
            new System.Drawing.Point(point.X - 3, point.Y + 1),
            new System.Drawing.Point(point.X + 3, point.Y + 1),
            new System.Drawing.Point(point.X, point.Y - 1)
          };
                    break;
                case ArrowDirection.Right:
                    points = new System.Drawing.Point[3]
          {
            new System.Drawing.Point(point.X - 1, point.Y - 4),
            new System.Drawing.Point(point.X - 1, point.Y + 4),
            new System.Drawing.Point(point.X + 2, point.Y)
          };
                    break;
                default:
                    points = new System.Drawing.Point[3]
          {
            new System.Drawing.Point(point.X - 3, point.Y - 1),
            new System.Drawing.Point(point.X + 3, point.Y - 1),
            new System.Drawing.Point(point.X, point.Y + 1)
          };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal void RenderButton(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color arrowColor, ArrowDirection direction)
        {
            this.RenderBackgroundInternal(g, rect, baseColor, borderColor, 0.45f, true, LinearGradientMode.Vertical);
            using (SolidBrush solidBrush = new SolidBrush(arrowColor))
                this.RenderArrowInternal(g, rect, direction, (Brush)solidBrush);
        }

        internal void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, float basePosition, bool drawBorder, LinearGradientMode mode)
        {
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colorArray = new Color[4]
        {
          this.GetColor(baseColor, 0, 35, 24, 9),
          this.GetColor(baseColor, 0, 13, 8, 3),
          baseColor,
          this.GetColor(baseColor, 0, 68, 69, 54)
        };
                linearGradientBrush.InterpolationColors = new ColorBlend()
                {
                    Positions = new float[4]
          {
            0.0f,
            basePosition,
            basePosition + 0.05f,
            1f
          },
                    Colors = colorArray
                };
                g.FillRectangle((Brush)linearGradientBrush, rect);
            }
            if ((int)baseColor.A > 80)
            {
                Rectangle rect1 = rect;
                if (mode == LinearGradientMode.Vertical)
                    rect1.Height = (int)((double)rect1.Height * (double)basePosition);
                else
                    rect1.Width = (int)((double)rect.Width * (double)basePosition);
                using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue)))
                    g.FillRectangle((Brush)solidBrush, rect1);
            }
            if (!drawBorder)
                return;
            using (Pen pen = new Pen(borderColor))
                g.DrawRectangle(pen, rect);
        }

        internal void RenderTabBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, float basePosition, LinearGradientMode mode)
        {
            using (GraphicsPath tabPath1 = this.CreateTabPath(rect))
            {
                using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
                {
                    Color[] colorArray = new Color[4]
          {
            this.GetColor(baseColor, 0, 35, 24, 9),
            this.GetColor(baseColor, 0, 13, 8, 3),
            baseColor,
            this.GetColor(baseColor, 0, 68, 69, 54)
          };
                    linearGradientBrush.InterpolationColors = new ColorBlend()
                    {
                        Positions = new float[4]
            {
              0.0f,
              basePosition,
              basePosition + 0.05f,
              1f
            },
                        Colors = colorArray
                    };
                    g.FillPath((Brush)linearGradientBrush, tabPath1);
                }
                if ((int)baseColor.A > 80)
                {
                    Rectangle rect1 = rect;
                    if (mode == LinearGradientMode.Vertical)
                        rect1.Height = (int)((double)rect1.Height * (double)basePosition);
                    else
                        rect1.Width = (int)((double)rect.Width * (double)basePosition);
                    using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue)))
                        g.FillRectangle((Brush)solidBrush, rect1);
                }
                rect.Inflate(-1, -1);
                using (GraphicsPath tabPath2 = this.CreateTabPath(rect))
                {
                    using (Pen pen = new Pen(Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue)))
                    {
                        if (this.Multiline)
                            g.DrawPath(pen, tabPath2);
                        else
                            g.DrawLines(pen, tabPath2.PathPoints);
                    }
                }
                using (Pen pen = new Pen(borderColor))
                {
                    if (this.Multiline)
                        g.DrawPath(pen, tabPath1);
                    g.DrawLines(pen, tabPath1.PathPoints);
                }
            }
        }

        private void DrawTabImage(Graphics g, TabPage page, Rectangle rect)
        {
            if (this.ImageList == null)
                return;
            Image image = (Image)null;
            if (page.ImageIndex != -1)
                image = this.ImageList.Images[page.ImageIndex];
            else if (page.ImageKey != null)
                image = this.ImageList.Images[page.ImageKey];
            if (image == null)
                return;
            g.DrawImage(image, rect);
        }

        private GraphicsPath CreateTabPath(Rectangle rect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    ++rect.X;
                    rect.Width -= 2;
                    graphicsPath.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + this.radius / 2);
                    graphicsPath.AddArc(rect.X, rect.Y, this.radius, this.radius, 180f, 90f);
                    graphicsPath.AddArc(rect.Right - this.radius, rect.Y, this.radius, this.radius, 270f, 90f);
                    graphicsPath.AddLine(rect.Right, rect.Y + this.radius / 2, rect.Right, rect.Bottom);
                    break;
                case TabAlignment.Bottom:
                    ++rect.X;
                    rect.Width -= 2;
                    graphicsPath.AddLine(rect.X, rect.Y, rect.X, rect.Bottom - this.radius / 2);
                    graphicsPath.AddArc(rect.X, rect.Bottom - this.radius, this.radius, this.radius, 180f, -90f);
                    graphicsPath.AddArc(rect.Right - this.radius, rect.Bottom - this.radius, this.radius, this.radius, 90f, -90f);
                    graphicsPath.AddLine(rect.Right, rect.Bottom - this.radius / 2, rect.Right, rect.Y);
                    break;
                case TabAlignment.Left:
                    ++rect.Y;
                    rect.Height -= 2;
                    graphicsPath.AddLine(rect.Right, rect.Y, rect.X + this.radius / 2, rect.Y);
                    graphicsPath.AddArc(rect.X, rect.Y, this.radius, this.radius, 270f, -90f);
                    graphicsPath.AddArc(rect.X, rect.Bottom - this.radius, this.radius, this.radius, 180f, -90f);
                    graphicsPath.AddLine(rect.X + this.radius / 2, rect.Bottom, rect.Right, rect.Bottom);
                    break;
                case TabAlignment.Right:
                    ++rect.Y;
                    rect.Height -= 2;
                    graphicsPath.AddLine(rect.X, rect.Y, rect.Right - this.radius / 2, rect.Y);
                    graphicsPath.AddArc(rect.Right - this.radius, rect.Y, this.radius, this.radius, 270f, 90f);
                    graphicsPath.AddArc(rect.Right - this.radius, rect.Bottom - this.radius, this.radius, this.radius, 0.0f, 90f);
                    graphicsPath.AddLine(rect.Right - this.radius / 2, rect.Bottom, rect.X, rect.Bottom);
                    break;
            }
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int num1 = (int)colorBase.A;
            int num2 = (int)colorBase.R;
            int num3 = (int)colorBase.G;
            int num4 = (int)colorBase.B;
            a = a + num1 <= (int)byte.MaxValue ? Math.Max(a + num1, 0) : (int)byte.MaxValue;
            r = r + num2 <= (int)byte.MaxValue ? Math.Max(r + num2, 0) : (int)byte.MaxValue;
            g = g + num3 <= (int)byte.MaxValue ? Math.Max(g + num3, 0) : (int)byte.MaxValue;
            b = b + num4 <= (int)byte.MaxValue ? Math.Max(b + num4, 0) : (int)byte.MaxValue;
            return Color.FromArgb(a, r, g, b);
        }

        public enum ePageImagePosition
        {
            Left,
            Right,
            Top,
            Bottom,
        }

        private class TransparentControl : Control
        {
            public TransparentControl()
            {
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
            }

            protected override void OnPaint(PaintEventArgs e)
            {
            }
        }

        private class UpDownButtonNativeWindow : NativeWindow, IDisposable
        {
            public const int VK_LBUTTON = 1;
            public const int VK_RBUTTON = 2;
            private UITabControl _owner;
            private bool _bPainting;

            public UpDownButtonNativeWindow(UITabControl owner)
            {
                this._owner = owner;
                this.AssignHandle(owner.UpDownButtonHandle);
            }

            private bool LeftKeyPressed()
            {
                if (SystemInformation.MouseButtonsSwapped)
                    return (int)NativeMethods.GetKeyState(2) < 0;
                else
                    return (int)NativeMethods.GetKeyState(1) < 0;
            }

            private void DrawUpDownButton()
            {
                bool mousePress = this.LeftKeyPressed();
                RECT rect = new RECT();
                NativeMethods.GetClientRect(this.Handle, ref rect);
                Rectangle clipRect = Rectangle.FromLTRB(rect.Top, rect.Left, rect.Right, rect.Bottom);
                POINT lpPoint = new POINT();
                NativeMethods.GetCursorPos(ref lpPoint);
                NativeMethods.GetWindowRect(this.Handle, ref rect);
                bool mouseOver = NativeMethods.PtInRect(ref rect, lpPoint);
                lpPoint.X -= rect.Left;
                lpPoint.Y -= rect.Top;
                bool mouseInUpButton = lpPoint.X < clipRect.Width / 2;
                using (Graphics graphics = Graphics.FromHwnd(this.Handle))
                    this._owner.OnPaintUpDownButton(new UpDownButtonPaintEventArgs(graphics, clipRect, mouseOver, mousePress, mouseInUpButton));
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 15)
                {
                    if (!this._bPainting)
                    {
                        PAINTSTRUCT ps = new PAINTSTRUCT();
                        this._bPainting = true;
                        NativeMethods.BeginPaint(m.HWnd, ref ps);
                        this.DrawUpDownButton();
                        NativeMethods.EndPaint(m.HWnd, ref ps);
                        this._bPainting = false;
                        m.Result = Result.TRUE;
                    }
                    else
                        base.WndProc(ref m);
                }
                else
                    base.WndProc(ref m);
            }

            public void Dispose()
            {
                this._owner = (UITabControl)null;
                this.ReleaseHandle();
            }
        }
    }

    public class UpDownButtonPaintEventArgs : PaintEventArgs
    {
        private bool _mouseInUpButton;
        private bool _mouseOver;
        private bool _mousePress;

        public UpDownButtonPaintEventArgs(Graphics graphics, Rectangle clipRect, bool mouseOver, bool mousePress, bool mouseInUpButton)
            : base(graphics, clipRect)
        {
            this._mouseOver = mouseOver;
            this._mousePress = mousePress;
            this._mouseInUpButton = mouseInUpButton;
        }

        public bool MouseInUpButton
        {
            get
            {
                return this._mouseInUpButton;
            }
        }

        public bool MouseOver
        {
            get
            {
                return this._mouseOver;
            }
        }

        public bool MousePress
        {
            get
            {
                return this._mousePress;
            }
        }
    }
}
