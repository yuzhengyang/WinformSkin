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
    public partial class ListBox : LayeredForm
    {
        public ListBox()
        {
            InitializeComponent();
        }
        Image close = Image.FromFile("Images/itemClose.png");
        Image open = Image.FromFile("Images/itemOpen.png");
        Image qq = Image.FromFile("Images/1_100.gif");

        private void ListBox_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {//往LayeredListBox里面添加项目
                if (i % 100 != 0)
                {
                    DuiLabel lbl = new DuiLabel();
                    lbl.Size = new System.Drawing.Size(40, 20);
                    lbl.Text = (i + 1).ToString();
                    lbl.Location = new Point(60, 8);

                    DuiLabel info = new DuiLabel();
                    info.Size = new System.Drawing.Size(70, 20);
                    info.Text = "信息。。。";
                    info.Location = new Point(59, 30);
                    info.ForeColor = Color.FromArgb(60, 60, 60);

                    DuiBaseControl pic = new DuiBaseControl();
                    pic.Size = new System.Drawing.Size(45, 45);
                    pic.Location = new Point(5, 5);
                    pic.BackColor = Color.BurlyWood;
                    pic.BackgroundImage = qq;
                    pic.BackgroundImageLayout = ImageLayout.Stretch;

                    DuiBaseControl item = new DuiBaseControl();
                    item.BackColor = Color.FromArgb(100, Color.White);
                    item.Width = layeredListBox1.Width;
                    item.Height = 55;
                    item.MouseEnter += dui_MouseEnter;
                    item.MouseLeave += dui_MouseLeave;
                    item.Controls.Add(lbl);
                    item.Controls.Add(info);
                    item.Controls.Add(pic);
                    item.Name = (i + 1).ToString();
                    layeredListBox1.Items.Add(item);
                }
                else
                {
                    DuiLabel dui = new DuiLabel();
                    dui.Text = "    收起或打开";
                    dui.TextAlign = ContentAlignment.MiddleLeft;
                    //dui.TextRenderMode=System.Drawing.Text.TextRenderingHint.AntiAlias;
                    dui.BackgroundImageLayout = ImageLayout.None;
                    dui.BackColor = Color.FromArgb(150, Color.White);
                    dui.BackgroundImage = open;
                    dui.Width = layeredListBox1.Width;
                    dui.Height = 25;
                    dui.Name = i.ToString();
                    dui.Tag = "open";
                    dui.MouseClick += dui_MouseClick;
                    dui.MouseEnter += title_MouseEnter;
                    dui.MouseLeave += title_MouseLeave;
                    layeredListBox1.Items.Add(dui);
                }
            }

            layeredListBox1.RefreshList();

            for (int i = 0; i < 99; i++)
            {
                DuiLabel lbl = new DuiLabel();
                lbl.Size = new System.Drawing.Size(90, 90);
                lbl.Text = (i + 1).ToString();
                lbl.Location = new Point(5, 5);
                lbl.BackColor = Color.FromArgb(23, 149, 75);
                lbl.ForeColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.MouseEnter += lbl_MouseEnter;
                lbl.MouseLeave += lbl_MouseLeave;

                DuiBaseControl item = new DuiBaseControl();
                item.BackColor = Color.FromArgb(14, 109, 56);
                item.Size = new System.Drawing.Size(100, 100);
                item.Controls.Add(lbl);
                MetroList.Items.Add(item);
            }
            MetroList.RefreshList();
            layeredListBox2.RefreshList();
            layeredListBox2.InnerDuiControl.BorderRender = new FilletBorderRender(10, 1, Color.Black);
            this.Animation.Effect = new LayeredSkin.Animations.RandomCurtainEffect();//设置启动特效
        }

        void lbl_MouseLeave(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).Borders.BottomColor = Color.Empty;
            ((DuiBaseControl)sender).Borders.LeftColor = Color.Empty;
            ((DuiBaseControl)sender).Borders.RightColor = Color.Empty;
            ((DuiBaseControl)sender).Borders.TopColor = Color.Empty;
        }

        void lbl_MouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).Borders.BottomColor = Color.White;
            ((DuiBaseControl)sender).Borders.LeftColor = Color.White;
            ((DuiBaseControl)sender).Borders.RightColor = Color.White;
            ((DuiBaseControl)sender).Borders.TopColor = Color.White;
        }

        void dui_MouseClick(object sender, MouseEventArgs e)
        {
            int id = Convert.ToInt32(((DuiBaseControl)sender).Name);

            if (((DuiBaseControl)sender).Tag.ToString() == "open")
            {
                ((DuiBaseControl)sender).Tag = "close";
                for (int i = id + 1; i < 100 + id; i++)
                {
                    this.layeredListBox1.Items[i].Visible = false;
                }
                ((DuiBaseControl)sender).BackgroundImage = close;
                layeredListBox1.RefreshList();
            }
            else
            {
                ((DuiBaseControl)sender).Tag = "open";

                for (int i = id + 1; i < 100 + id; i++)
                {
                    this.layeredListBox1.Items[i].Visible = true;
                }
                ((DuiBaseControl)sender).BackgroundImage = open;
                layeredListBox1.RefreshList();
            }

        }

        void dui_MouseLeave(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = Color.FromArgb(100, Color.White);
        }

        void dui_MouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = Color.FromArgb(200, Color.White);
        }


        void title_MouseLeave(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = Color.FromArgb(150, Color.White);
        }

        void title_MouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = Color.FromArgb(200, Color.White);
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.Animation.Effect = new LayeredSkin.Animations.FadeinFadeoutEffect();//设置关闭特效
            this.Close();
        }

        private void MetroList_ItemClick(object sender, LayeredSkin.Controls.ItemClickEventArgs e)
        {
            MessageBox.Show((e.Index + 1).ToString());
        }

    }
}
