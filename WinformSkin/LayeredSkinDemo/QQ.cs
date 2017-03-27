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
 * * 说明：QQ.cs
 * *
********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace test
{
    public partial class QQ : LayeredForm
    {
        public QQ()
        {
            InitializeComponent();
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void QQ_Load(object sender, EventArgs e)
        {
            this.Animation.Effect = new LayeredSkin.Animations.GradualCurtainEffect() { ChangeHeight = 25 };

            yezi = new Bitmap(90, 80);//先把叶子画在稍微大一点的画布上，这样叶子旋转的时候才不会被裁掉一部分
            using (Graphics g = Graphics.FromImage(yezi))
            {
                g.DrawImage(Image.FromFile("Images\\yezi3.png"), 10, 0);
            }
            timer1.Start();
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Animation.Effect = new LayeredSkin.Animations.GradualCurtainEffect();
            this.Animation.Asc = true;
            this.Close();
        }

        private void FormMoveMouseDown(object sender, MouseEventArgs e)
        {
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
        }

        Image Cloud = Image.FromFile("Images\\cloud.png");
        float cloudX = 0;
        Image yezi;
        float angle = 10;
        bool RotationDirection = true;//是否为顺时针

        protected override void OnLayeredPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (cloudX > this.Width - Cloud.Width)
            {//云的飘动
                cloudX = 0;
            }
            else
            {
                cloudX += 0.5f;
            }
            g.DrawImage(Cloud, cloudX, 0);//把云绘制上去

            if (angle > 10)
            {//控制旋转方向
                RotationDirection = false;
            }
            if (angle < -10)
            {
                RotationDirection = true;
            }
            if (RotationDirection)
            {
                angle += 1;
            }
            else
            {
                angle -= 1;
            }
            using (Image temp = LayeredSkin.ImageEffects.RotateImage(yezi, angle, new Point(25, 3)))
            {
                g.DrawImage(temp, 140, 70);//绘制叶子
            }
            base.OnLayeredPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LayeredPaint();
            GC.Collect();
        }

        public bool isShow = false;
        bool isFirst = true;
        private void layeredButton3_Click(object sender, EventArgs e)
        {
            isShow = false;
            if (isFirst)
            {
                this.Animation.Effect = new LayeredSkin.Animations.ThreeDTurn();
                this.Animation.AnimationEnd += Animation_AnimationEnd;
            }
            isFirst = false;

            this.Animation.Asc = false;
            this.Animation.Start();
        }
        //QQConfig config;
        void Animation_AnimationEnd(object sender, LayeredSkin.Animations.AnimationEventArgs e)
        {
            if (!isShow)
            {
                this.Hide();
                QQConfig config = new QQConfig(this);
                config.Location = this.Location;
                config.Show();
            }
        }

    }
}
