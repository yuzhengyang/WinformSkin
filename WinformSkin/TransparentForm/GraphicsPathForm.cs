using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TransparentForm
{
    public partial class GraphicsPathForm : Form
    {
        public GraphicsPathForm()
        {
            InitializeComponent();
        }
        private void GraphicsPathForm_Load(object sender, EventArgs e)
        {
            TopMost = true;//设置为最顶层
            FormBorderStyle = FormBorderStyle.None;//取消窗口边框
            this.Region = new Region(GetWindowRegion(new Bitmap(BackgroundImage)));//设置不规则窗体
            FormMovableEvent();//设置拖动窗体移动
        }
        #region 设置不规则窗体
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
                    //if (TempColor.A != 0)//去掉完全透明区域
                    if (TempColor.A == 255)//保留完全不透明的区域
                    {
                        gp.AddRectangle(new Rectangle(nX, nY, 1, 1));
                    }
                }
            }
            return gp;
        }
        #endregion
        #region 无标题栏的窗口移动
        private Point mouseOffset; //记录鼠标指针的坐标
        private bool isMouseDown = false; //记录鼠标按键是否按下

        /// <summary>
        /// 窗体移动监听绑定
        /// </summary>
        private void FormMovableEvent()
        {
            //窗体移动
            this.MouseDown += new MouseEventHandler(Frm_MouseDown);
            this.MouseMove += new MouseEventHandler(Frm_MouseMove);
            this.MouseUp += new MouseEventHandler(Frm_MouseUp);
        }

        /// <summary>
        /// 窗体按下时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            //点击窗体时，记录鼠标位置，启动移动
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        /// <summary>
        /// 窗体移动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                //移动的位置计算
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        /// <summary>
        /// 窗体按下并释放按钮时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            // 修改鼠标状态isMouseDown的值
            // 确保只有鼠标左键按下并移动时，才移动窗体
            if (e.Button == MouseButtons.Left)
            {
                //松开鼠标时，停止移动
                isMouseDown = false;
                //Top高度小于0的时候，等于0
                if (this.Top < 0)
                {
                    this.Top = 0;
                }
            }
        }
        #endregion
    }
}
