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
 * * 说明：SuperMario.Designer.cs
 * *
********************************************************************/
namespace test
{
    partial class SuperMario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperMario));
            this.layeredPictureBox1 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredLabel1 = new LayeredSkin.Controls.LayeredLabel();
            this.layeredLabel2 = new LayeredSkin.Controls.LayeredLabel();
            this.layeredLabel3 = new LayeredSkin.Controls.LayeredLabel();
            this.layeredLabelTime = new LayeredSkin.Controls.LayeredLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layeredPictureBox1
            // 
            this.layeredPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPictureBox1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.BottomWidth = 1;
            this.layeredPictureBox1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.LeftWidth = 1;
            this.layeredPictureBox1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.RightWidth = 1;
            this.layeredPictureBox1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.TopWidth = 1;
            this.layeredPictureBox1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox1.Canvas")));
            this.layeredPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("layeredPictureBox1.Image")));
            this.layeredPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("layeredPictureBox1.Images")))))};
            this.layeredPictureBox1.Interval = 100;
            this.layeredPictureBox1.Location = new System.Drawing.Point(354, -3);
            this.layeredPictureBox1.MultiImageAnimation = false;
            this.layeredPictureBox1.Name = "layeredPictureBox1";
            this.layeredPictureBox1.Size = new System.Drawing.Size(200, 200);
            this.layeredPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.layeredPictureBox1.TabIndex = 0;
            this.layeredPictureBox1.Text = "layeredPictureBox1";
            // 
            // layeredLabel1
            // 
            this.layeredLabel1.AutoSize = true;
            this.layeredLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredLabel1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.BottomWidth = 1;
            this.layeredLabel1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.LeftWidth = 1;
            this.layeredLabel1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.RightWidth = 1;
            this.layeredLabel1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredLabel1.Borders.TopWidth = 1;
            this.layeredLabel1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredLabel1.Canvas")));
            this.layeredLabel1.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layeredLabel1.ForeColor = System.Drawing.Color.White;
            this.layeredLabel1.HaloColor = System.Drawing.Color.Gray;
            this.layeredLabel1.HaloSize = 5;
            this.layeredLabel1.Location = new System.Drawing.Point(153, 250);
            this.layeredLabel1.Name = "layeredLabel1";
            this.layeredLabel1.Size = new System.Drawing.Size(120, 34);
            this.layeredLabel1.TabIndex = 1;
            this.layeredLabel1.Text = "星期日";
            this.layeredLabel1.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // layeredLabel2
            // 
            this.layeredLabel2.AutoSize = true;
            this.layeredLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredLabel2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.BottomWidth = 1;
            this.layeredLabel2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.LeftWidth = 1;
            this.layeredLabel2.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.RightWidth = 1;
            this.layeredLabel2.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredLabel2.Borders.TopWidth = 1;
            this.layeredLabel2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredLabel2.Canvas")));
            this.layeredLabel2.Font = new System.Drawing.Font("隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layeredLabel2.ForeColor = System.Drawing.Color.White;
            this.layeredLabel2.HaloColor = System.Drawing.Color.Gray;
            this.layeredLabel2.HaloSize = 5;
            this.layeredLabel2.Location = new System.Drawing.Point(153, 286);
            this.layeredLabel2.Name = "layeredLabel2";
            this.layeredLabel2.Size = new System.Drawing.Size(87, 34);
            this.layeredLabel2.TabIndex = 1;
            this.layeredLabel2.Text = "晴天";
            this.layeredLabel2.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // layeredLabel3
            // 
            this.layeredLabel3.AutoSize = true;
            this.layeredLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredLabel3.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredLabel3.Borders.BottomWidth = 1;
            this.layeredLabel3.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredLabel3.Borders.LeftWidth = 1;
            this.layeredLabel3.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredLabel3.Borders.RightWidth = 1;
            this.layeredLabel3.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredLabel3.Borders.TopWidth = 1;
            this.layeredLabel3.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredLabel3.Canvas")));
            this.layeredLabel3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layeredLabel3.ForeColor = System.Drawing.Color.White;
            this.layeredLabel3.HaloColor = System.Drawing.Color.Gray;
            this.layeredLabel3.HaloSize = 5;
            this.layeredLabel3.Location = new System.Drawing.Point(300, 277);
            this.layeredLabel3.Name = "layeredLabel3";
            this.layeredLabel3.Size = new System.Drawing.Size(161, 30);
            this.layeredLabel3.TabIndex = 1;
            this.layeredLabel3.Text = "20°C-25°C";
            this.layeredLabel3.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // layeredLabelTime
            // 
            this.layeredLabelTime.AutoSize = true;
            this.layeredLabelTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredLabelTime.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredLabelTime.Borders.BottomWidth = 1;
            this.layeredLabelTime.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredLabelTime.Borders.LeftWidth = 1;
            this.layeredLabelTime.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredLabelTime.Borders.RightWidth = 1;
            this.layeredLabelTime.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredLabelTime.Borders.TopWidth = 1;
            this.layeredLabelTime.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredLabelTime.Canvas")));
            this.layeredLabelTime.Font = new System.Drawing.Font("华文琥珀", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.layeredLabelTime.ForeColor = System.Drawing.Color.Gold;
            this.layeredLabelTime.HaloColor = System.Drawing.Color.Gray;
            this.layeredLabelTime.HaloSize = 5;
            this.layeredLabelTime.Location = new System.Drawing.Point(97, 113);
            this.layeredLabelTime.Name = "layeredLabelTime";
            this.layeredLabelTime.Size = new System.Drawing.Size(251, 84);
            this.layeredLabelTime.TabIndex = 2;
            this.layeredLabelTime.Text = "12:00";
            this.layeredLabelTime.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SuperMario
            // 
            this.AnimationType = LayeredSkin.Forms.AnimationTypes.RotateZoomEffect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CaptionShowMode = LayeredSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(666, 389);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.layeredLabelTime);
            this.Controls.Add(this.layeredLabel3);
            this.Controls.Add(this.layeredLabel2);
            this.Controls.Add(this.layeredLabel1);
            this.Controls.Add(this.layeredPictureBox1);
            this.DrawIcon = false;
            this.Name = "SuperMario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperMario";
            this.Load += new System.EventHandler(this.SuperMario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox1;
        private LayeredSkin.Controls.LayeredLabel layeredLabel1;
        private LayeredSkin.Controls.LayeredLabel layeredLabel2;
        private LayeredSkin.Controls.LayeredLabel layeredLabel3;
        private LayeredSkin.Controls.LayeredLabel layeredLabelTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}