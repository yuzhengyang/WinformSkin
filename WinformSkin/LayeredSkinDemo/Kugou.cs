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
 * * 说明：Kugou.cs
 * *
********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin;
using LayeredSkin.Forms;
using System.Drawing.Drawing2D;

namespace test
{
    public partial class Kugou : LayeredForm
    {
        public Kugou()
        {
            InitializeComponent();
            path.AddLine(new Point(105, 0), new Point(205, 102));
            path.AddLine(new Point(205, 102), new Point(105, 200));
            path.AddLine(new Point(105, 200), new Point(0, 102));
            path.AddLine(new Point(0, 102), new Point(105, 0));
            path.CloseFigure();
        }

        private void MouseDownFormMove(object sender, MouseEventArgs e)
        {
            NativeMethods.MouseToMoveControl(this.Handle);
        }

        float opacity = 1;
        GraphicsPath path = new GraphicsPath();
        bool isFadeIn = false;

        /// <summary>
        /// 用于检测鼠标是否移入界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point mousePoint = Control.MousePosition;
            mousePoint.Offset(-this.Location.X, -this.Location.Y);
            if (path.IsVisible(mousePoint) != isFadeIn)
            {
                isFadeIn = !isFadeIn;
                if (isFadeIn)
                {
                    timer2.Start();
                }
                else
                {
                    timer3.Start();
                }
            }
        }

        /// <summary>
        /// 实现淡入淡出效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isFadeIn)
            {
                if (opacity <= 1)
                {
                    opacity += 0.06f;
                }
                if (opacity > 1)
                {
                    opacity = 1;
                    timer2.Stop();
                }
            }
            else
            {
                if (opacity >= 0)
                {
                    opacity -= 0.06f;
                }
                if (opacity < 0)
                {
                    opacity = 0;
                    timer2.Stop();
                }
            }
            layeredPanel1.ImageAttribute = ImageEffects.ChangeOpacity(opacity);
            LayeredPaint();
        }

        /// <summary>
        /// 用于鼠标移出后延迟执行淡出效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            timer2.Start();
        }


    }
}
