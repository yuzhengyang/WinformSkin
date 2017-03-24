using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using Client.UI.Base.Enums;
using Client.UI.DefaultResource;
using System.Drawing.Drawing2D;

namespace Client.UI.Contorls
{
    /// <summary>
    /// 工具栏
    /// </summary>
    [DefaultProperty("Items")]
    [DefaultEvent("SelectedIndexChanged")]
    public class UIToolBar : Control
    {
        #region 变量

        #region 资源图片
        /// <summary>
        /// 
        /// </summary>
        private Image _normalImage = GetDefaultResource.GetImage("Control.toolbar_normal.png");
        /// <summary>
        /// 
        /// </summary>
        private Image _pushedImage = GetDefaultResource.GetImage("Control.toolbar_pushed.png");
        /// <summary>
        /// 
        /// </summary>
        private Image _hoverImage = GetDefaultResource.GetImage("Control.toolbar_hover.png");
        #endregion

        #region 成员

        /// <summary>
        /// 工具栏中的项
        /// </summary>
        private ToolItemCollection _items = null;
        /// <summary>
        /// 每一项的大小
        /// </summary>
        private Size _itemSize = new Size(74, 82);
        /// <summary>
        /// 每一项图片显示的大小
        /// </summary>
        private Size _imageSize = new Size(48, 48);
        /// <summary>
        /// 项与项之间的间隔
        /// </summary>
        private int _itemSpace = 5;
        ///// <summary>
        ///// 鼠标状态
        ///// </summary>
        //private MouseOperate _mouseState = MouseOperate.Normal;
        /// <summary>
        /// 选中项的索引
        /// </summary>
        private int _selectedIndex = 0;
        /// <summary>
        /// 当前选中项
        /// </summary>
        private UIToolBarItem _selectedItem = null;

        #endregion

        #region 事件对像
        /// <summary>
        /// 当选中项的索引发生改变时事件的 Key
        /// </summary>
        private static readonly object EventSelectedIndexChanged = new object();
        /// <summary>
        /// 当选中项的发生改变时事件的 Key
        /// </summary>
        private static readonly object EventSelectedItemChanged = new object();
        #endregion

        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化 Paway.Windows.Forms.ToolBar 新的实例。
        /// </summary>
        public UIToolBar()
        {
            this.SetStyle(
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.Selectable |
               ControlStyles.SupportsTransparentBackColor |
               ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.UpdateStyles();
            this.Initialize();
        }

        #endregion

        #region 属性
        /// <summary>
        /// 工具栏中的项
        /// </summary>
        [Description("工具栏中的项"),EditorBrowsable(EditorBrowsableState.Always),DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolItemCollection Items
        {
            get
            {
                if (this._items == null)
                    this._items = new ToolItemCollection(this);
                return this._items;
            }
        }
        /// <summary>
        /// Item 的大小
        /// </summary>
        [Description("Item 的大小")]
        public Size ItemSize
        {
            get { return this._itemSize; }
        }
        /// <summary>
        /// 项与项之间的间隔
        /// </summary>
        [Description("项与项之间的间隔")]
        public int ItemSpace
        {
            get { return this._itemSpace; }
            set
            {
                this._itemSpace = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// 当前选中的 Item
        /// </summary>
        [Browsable(false), Description("当前选中的 Item")]
        public UIToolBarItem SelectedItem
        {
            get
            {
                if (this._selectedItem == null && this.Items.Count != 0)
                    this._selectedItem = this.Items[0];
                return this._selectedItem;
            }
        }
        /// <summary>
        /// 选中 Item 的索引
        /// </summary>
        [Browsable(false), Description("选中 Item 的索引")]
        public int SelectedIndex
        {
            get { return this._selectedIndex; }
        }
        /// <summary>
        /// 重写父类的默认大小
        /// </summary>
        protected override Size DefaultSize
        {
            get { return new Size(300, 82); }
        }
        
        #endregion

        #region 事件
        /// <summary>
        /// 当选中项的索引发生改变时
        /// </summary>
        public event EventHandler SelectedIndexChanged
        {
            add { base.Events.AddHandler(EventSelectedIndexChanged, value); }
            remove { base.Events.RemoveHandler(EventSelectedIndexChanged, value); }
        }
        /// <summary>
        /// 当选中项的发生改变时
        /// </summary>
        public event EventHandler SelectedItemChanged
        {
            add { base.Events.AddHandler(EventSelectedItemChanged, value); }
            remove { base.Events.RemoveHandler(EventSelectedItemChanged, value); }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void Initialize()
        {
            this.BackColor = Color.Transparent;
        }
        /// <summary>
        /// 跳到选择项
        /// </summary>
        /// <param name="index">索引</param>
        public void SelectIndex( int index)
        {
            if (index >= this._items.Count||index<0)
                return;
            this._selectedItem = _items[index];
            this._selectedIndex = index;
            this.Invalidate();
            this.OnSelectedIndexChanged(EventArgs.Empty);
        }
        #endregion

        #region Override Methods
        /// <summary>
        /// 引发 System.Windows.Forms.Form.Paint 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 System.Windows.Forms.PaintEventArgs。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int xPos = this.Padding.Left;
            int yPos = this.Padding.Top;
            foreach (UIToolBarItem item in this.Items)
            {
                // 当前 Item 所在的矩型区域
                Rectangle itemRect = new Rectangle(xPos, yPos, this._itemSize.Width, this._itemSize.Height);
                if (!DesignMode)
                {
                    item.Rectangle = itemRect;
                    if (item != this.SelectedItem)
                    {
                        if (item.MouseState == MouseOperate.Normal ||
                            item.MouseState == MouseOperate.Leave)
                        {
                            g.DrawImage(this._normalImage, itemRect);
                        }
                        else if (item.MouseState == MouseOperate.Move ||
                            item.MouseState == MouseOperate.Up)
                        {
                            g.DrawImage(this._hoverImage, itemRect);
                        }
                    }
                    else
                    {
                        g.DrawImage(this._pushedImage, itemRect);
                    }
                }
                if (item.Image != null)     // 绘制图片
                {
                    Rectangle imageRect = new Rectangle();
                    imageRect.X = itemRect.X + (itemRect.Width - this._imageSize.Width) / 2;
                    imageRect.Y = 6;
                    imageRect.Size = this._imageSize;
                    g.DrawImage(item.Image, imageRect);
                }
                if (!string.IsNullOrEmpty(item.Text))   // 绘制文字
                {
                    Rectangle textRect = new Rectangle();
                    textRect.X = itemRect.X;
                    textRect.Y = itemRect.Height / 5 * 3;
                    textRect.Height = itemRect.Height / 5 * 2;
                    textRect.Width = itemRect.Width;
                    TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                    TextRenderer.DrawText(g, item.Text, this.Font, textRect, this.ForeColor, flags);
                }
                xPos += itemRect.Width + this._itemSpace;
            }
        }
        /// <summary>
        /// 引发 System.Windows.Forms.Form.MouseMove 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 System.Windows.Forms.MouseEventArgs。</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!this.DesignMode)
            {
                Point point = e.Location;
                foreach (UIToolBarItem item in this.Items)
                {
                    if (item.MouseState == MouseOperate.Down)
                    {
                        continue;
                    }
                    else if (item.Rectangle.Contains(point))
                    {
                        item.MouseState = MouseOperate.Move;
                        this.Invalidate(item.Rectangle);
                    }
                    else
                    {
                        item.MouseState = MouseOperate.Leave;
                        this.Invalidate(item.Rectangle);
                    }
                }
            }
        }
        /// <summary>
        /// 引发 System.Windows.Forms.Form.MouseLeave 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 System.EventArgs。</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.DesignMode)
            {
                foreach (UIToolBarItem item in this.Items)
                {
                    if (item != this.SelectedItem)
                    {
                        item.MouseState = MouseOperate.Leave;
                        this.Invalidate(item.Rectangle);
                    }
                }
            }
        }
        /// <summary>
        /// 引发 System.Windows.Forms.Form.MouseDown 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 System.Windows.Forms.MouseEventArgs。</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.DesignMode)
            {
                Point point = e.Location;
                foreach (UIToolBarItem item in this.Items)
                {
                    if (item.Rectangle.Contains(point))
                    {
                        if (item != this.SelectedItem)
                        {
                            this._selectedItem = item;
                            this.OnSelectedItemChanged(EventArgs.Empty);
                            this._selectedIndex = this.Items.GetIndexOfRange(item);
                            this.OnSelectedIndexChanged(EventArgs.Empty);
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        item.MouseState = MouseOperate.Normal;
                        this.Invalidate(item.Rectangle);
                    }
                }
            }
        }
        /// <summary>
        /// 引发 System.Windows.Forms.Form.MouseUp 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 System.Windows.Forms.MouseEventArgs。</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!this.DesignMode)
            {
                Point point = e.Location;
                foreach (UIToolBarItem item in this.Items)
                {
                    if (item != this.SelectedItem)
                    {
                        if (item.Rectangle.Contains(point))
                        {
                            item.MouseState = MouseOperate.Up;
                            this.Invalidate(item.Rectangle);
                        }
                    }
                }
            }
        }
        #endregion

        #region 激发事件的方法
        /// <summary>
        /// 当选择的 Item 发生改变时激发。
        /// </summary>
        /// <param name="e">包含事件数据的 System.EventArgs。</param>
        public virtual void OnSelectedItemChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EventSelectedItemChanged] as EventHandler;
            if (handler != null)
                handler(this, e);
        }
        /// <summary>
        /// 当选择的 Item 索引发生改变时激发。
        /// </summary>
        /// <param name="e">包含事件数据的 System.EventArgs。</param>
        public virtual void OnSelectedIndexChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EventSelectedIndexChanged] as EventHandler;
            if (handler != null)
                handler(this, e);
        }
        #endregion
    }

    /// <summary>
    /// 表示 ToolBar 控件中的单个项。
    /// </summary>
    public class UIToolBarItem
    {
        #region 属性
        /// <summary>
        /// Item 显示的图片
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// 获取或设置包含有关控件的数据的对象。 
        /// </summary>
        public object Tag { get; set; }
        /// <summary>
        /// Item 上显示的文字信息
        /// </summary>
        [DefaultValue("toolItem")]
        public string Text { get; set; }
        /// <summary>
        /// 当前 Item 在 ToolBar 中的 Rectangle
        /// </summary>
        internal Rectangle Rectangle { get; set; }
        /// <summary>
        /// Item 当前的鼠标状态
        /// </summary>
        internal MouseOperate MouseState { get; set; }

        #endregion
    }

    /// <summary>
    /// 代表 ToolBar 中项的集合。
    /// </summary>
    [ListBindable(false)]
    public class ToolItemCollection : List<UIToolBarItem>
    {
        #region 变量
        /// <summary>
        /// ToolBar
        /// </summary>
        private UIToolBar _owner = null;

        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化 Paway.Windows.Forms.ToolItemCollection 新的实例。
        /// </summary>
        /// <param name="owner">ToolBar</param>
        public ToolItemCollection(UIToolBar owner)
        {
            this._owner = owner;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 返回该项在集合中的索引值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int GetIndexOfRange(UIToolBarItem item)
        {
            int result = -1;
            for (int i = 0; i < base.Count; i++)
            {
                if (item == base[i])
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        #endregion
    }
}
