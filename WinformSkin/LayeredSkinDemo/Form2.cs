/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-2014 LayeredSkin Corporation All rights reserved.
 * * 作者： 小红帽  QQ:761716178
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2014-04-13
 * * 说明：Form2.cs
 * *
********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.DirectUI;
using LayeredSkin;

namespace test
{
    public partial class Form2 : LayeredForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(100, Color.Black);//背景色设为半透明的
            //this.BackgroundRender = new ShadowBackgroundRender();
            //this.BackColor = Color.Black;
            this.Animation.Effect = new LayeredSkin.Animations.GradualCurtainEffect();

            layeredTextBox1.DUIControls[0].MouseClick += Form2_MouseClick;
        }

        void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
        }


        private void layeredButton3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }

        private void layeredButton4_Click(object sender, EventArgs e)
        {
            Kugou kg = new Kugou();
            kg.Show();
        }


        private void layeredButton5_Click(object sender, EventArgs e)
        {
            SuperMario s = new SuperMario();
            s.Show();
        }

        private void layeredTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            ((LayeredSkin.DirectUI.DuiLabel)layeredTrackBar2.DUIControls[0]).Text = (int)(layeredTrackBar2.Value * 100) + "%";
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            DirectUI d = new DirectUI();
            d.Show();
        }

        QQ q;
        private void layeredButton6_Click(object sender, EventArgs e)
        {
            if (q == null)
            {
                q = new QQ();
            }
            else
            {
                q.Dispose();
                q = null;
                GC.Collect();
                q = new QQ();
            }
            q.Show();
        }

        private void layeredButton7_Click(object sender, EventArgs e)
        {
            ListBox l = new ListBox();
            l.Show();
        }

        private void layeredCheckButton1_Click(object sender, EventArgs e)
        {
            if (layeredCheckButton1.Checked)
            {
                this.EnabledDWM = true;
            }
            else
            {
                this.EnabledDWM = false;
            }
        }

        private void layeredButton10_Click(object sender, EventArgs e)
        {
            Metro m = new Metro();
            m.Show();
        }

        private void layeredButton11_Click(object sender, EventArgs e)
        {
            AlbumForm f = new AlbumForm();
            f.Show();
        }

        private void layeredButton12_Click(object sender, EventArgs e)
        {
            Chuyin f = new Chuyin();
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
            {
                timer1.Stop();
            }
            if (this.Opacity < 1)
            {
                this.Opacity += 0.1;
            }
        }

        private void layeredButton13_Click(object sender, EventArgs e)
        {
            DuiTextBoxTest f = new DuiTextBoxTest();
            f.Show();
        }


    }
}
