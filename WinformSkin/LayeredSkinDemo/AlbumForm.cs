using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.DirectUI;

namespace test
{
    public partial class AlbumForm : LayeredForm
    {
        public AlbumForm()
        {
            InitializeComponent();
        }

        Image pic = Image.FromFile("Images\\1.gif");

        private void AlbumForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)//添加列表项目
            {
                DuiPictureBox picBox = new DuiPictureBox();//图片容器
                picBox.Size = new Size(120, 120);
                //picBox.BackColor = Color.Red;
                picBox.Location = new Point(5, 5);
                picBox.MouseEnter += picBox_MouseEnter;//绑定事件实现鼠标移入移出的边框变化效果
                picBox.MouseLeave += picBox_MouseLeave;
                picBox.Borders.BottomWidth = 3;
                picBox.Borders.LeftWidth = 3;
                picBox.Borders.RightWidth = 3;
                picBox.Borders.TopWidth = 3;
                picBox.Image = pic;//设置图片
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                DuiBaseControl item = new DuiBaseControl();//列表项目
                item.Size = new Size(130, 130);
                item.Top = 10;
                item.Controls.Add(picBox);

                layeredListBox1.Items.Add(item);
            }
        }

        void picBox_MouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl control = (DuiBaseControl)sender;
            control.Borders.BottomColor = Color.Empty;
            control.Borders.LeftColor = Color.Empty;
            control.Borders.RightColor = Color.Empty;
            control.Borders.TopColor = Color.Empty;
        }

        void picBox_MouseEnter(object sender, EventArgs e)
        {
            DuiBaseControl control = (DuiBaseControl)sender;
            control.Borders.BottomColor = Color.Blue;
            control.Borders.LeftColor = Color.Blue;
            control.Borders.RightColor = Color.Blue;
            control.Borders.TopColor = Color.Blue;
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            layeredListBox1.DoSmoothScroll(-40);
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            layeredListBox1.DoSmoothScroll(40);
        }

        private void layeredButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void layeredListBox1_ItemClick(object sender, LayeredSkin.Controls.ItemClickEventArgs e)
        {
            MessageBox.Show("项目索引为：" + e.Index.ToString() + "的项目被点击");
        }
    }
}
