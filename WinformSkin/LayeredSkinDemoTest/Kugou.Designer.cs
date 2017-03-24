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
 * * 说明：Kugou.Designer.cs
 * *
********************************************************************/
namespace test
{
    partial class Kugou
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kugou));
            this.layeredPictureBox1 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredPanel1 = new LayeredSkin.Controls.LayeredPanel();
            this.layeredButton4 = new LayeredSkin.Controls.LayeredButton();
            this.layeredButton3 = new LayeredSkin.Controls.LayeredButton();
            this.layeredButton2 = new LayeredSkin.Controls.LayeredButton();
            this.layeredButton1 = new LayeredSkin.Controls.LayeredButton();
            this.layeredPictureBox5 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredPictureBox4 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredPictureBox3 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredPictureBox2 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredCheckButton1 = new LayeredSkin.Controls.LayeredCheckButton();
            this.layeredCheckButton2 = new LayeredSkin.Controls.LayeredCheckButton();
            this.layeredTrackBar1 = new LayeredSkin.Controls.LayeredTrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.layeredPanel1.SuspendLayout();
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
            this.layeredPictureBox1.Location = new System.Drawing.Point(54, 50);
            this.layeredPictureBox1.MultiImageAnimation = false;
            this.layeredPictureBox1.Name = "layeredPictureBox1";
            this.layeredPictureBox1.Size = new System.Drawing.Size(100, 100);
            this.layeredPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.layeredPictureBox1.TabIndex = 0;
            this.layeredPictureBox1.Text = "layeredPictureBox1";
            this.layeredPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFormMove);
            // 
            // layeredPanel1
            // 
            this.layeredPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.BottomWidth = 1;
            this.layeredPanel1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.LeftWidth = 1;
            this.layeredPanel1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.RightWidth = 1;
            this.layeredPanel1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.TopWidth = 1;
            this.layeredPanel1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel1.Canvas")));
            this.layeredPanel1.Controls.Add(this.layeredButton4);
            this.layeredPanel1.Controls.Add(this.layeredButton3);
            this.layeredPanel1.Controls.Add(this.layeredButton2);
            this.layeredPanel1.Controls.Add(this.layeredButton1);
            this.layeredPanel1.Controls.Add(this.layeredPictureBox5);
            this.layeredPanel1.Controls.Add(this.layeredPictureBox4);
            this.layeredPanel1.Controls.Add(this.layeredPictureBox3);
            this.layeredPanel1.Controls.Add(this.layeredPictureBox2);
            this.layeredPanel1.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel1.Name = "layeredPanel1";
            this.layeredPanel1.Size = new System.Drawing.Size(208, 203);
            this.layeredPanel1.TabIndex = 1;
            // 
            // layeredButton4
            // 
            this.layeredButton4.AdaptImage = true;
            this.layeredButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredButton4.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton4.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredButton4.Borders.BottomWidth = 1;
            this.layeredButton4.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredButton4.Borders.LeftWidth = 1;
            this.layeredButton4.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredButton4.Borders.RightWidth = 1;
            this.layeredButton4.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredButton4.Borders.TopWidth = 1;
            this.layeredButton4.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton4.Canvas")));
            this.layeredButton4.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton4.HaloColor = System.Drawing.Color.White;
            this.layeredButton4.HaloSize = 5;
            this.layeredButton4.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton4.HoverImage")));
            this.layeredButton4.IsPureColor = false;
            this.layeredButton4.Location = new System.Drawing.Point(148, 82);
            this.layeredButton4.Name = "layeredButton4";
            this.layeredButton4.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton4.NormalImage")));
            this.layeredButton4.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredButton4.PressedImage")));
            this.layeredButton4.Radius = 10;
            this.layeredButton4.ShowBorder = true;
            this.layeredButton4.Size = new System.Drawing.Size(34, 34);
            this.layeredButton4.TabIndex = 7;
            this.layeredButton4.Text = "layeredButton4";
            this.layeredButton4.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton4.TextShowMode = LayeredSkin.TextShowModes.None;
            // 
            // layeredButton3
            // 
            this.layeredButton3.AdaptImage = true;
            this.layeredButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredButton3.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton3.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredButton3.Borders.BottomWidth = 1;
            this.layeredButton3.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredButton3.Borders.LeftWidth = 1;
            this.layeredButton3.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredButton3.Borders.RightWidth = 1;
            this.layeredButton3.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredButton3.Borders.TopWidth = 1;
            this.layeredButton3.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton3.Canvas")));
            this.layeredButton3.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton3.HaloColor = System.Drawing.Color.White;
            this.layeredButton3.HaloSize = 5;
            this.layeredButton3.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton3.HoverImage")));
            this.layeredButton3.IsPureColor = false;
            this.layeredButton3.Location = new System.Drawing.Point(88, 145);
            this.layeredButton3.Name = "layeredButton3";
            this.layeredButton3.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton3.NormalImage")));
            this.layeredButton3.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredButton3.PressedImage")));
            this.layeredButton3.Radius = 10;
            this.layeredButton3.ShowBorder = true;
            this.layeredButton3.Size = new System.Drawing.Size(34, 34);
            this.layeredButton3.TabIndex = 6;
            this.layeredButton3.Text = "layeredButton3";
            this.layeredButton3.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton3.TextShowMode = LayeredSkin.TextShowModes.None;
            // 
            // layeredButton2
            // 
            this.layeredButton2.AdaptImage = true;
            this.layeredButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredButton2.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredButton2.Borders.BottomWidth = 1;
            this.layeredButton2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredButton2.Borders.LeftWidth = 1;
            this.layeredButton2.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredButton2.Borders.RightWidth = 1;
            this.layeredButton2.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredButton2.Borders.TopWidth = 1;
            this.layeredButton2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton2.Canvas")));
            this.layeredButton2.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton2.HaloColor = System.Drawing.Color.White;
            this.layeredButton2.HaloSize = 5;
            this.layeredButton2.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton2.HoverImage")));
            this.layeredButton2.IsPureColor = false;
            this.layeredButton2.Location = new System.Drawing.Point(27, 82);
            this.layeredButton2.Name = "layeredButton2";
            this.layeredButton2.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton2.NormalImage")));
            this.layeredButton2.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredButton2.PressedImage")));
            this.layeredButton2.Radius = 10;
            this.layeredButton2.ShowBorder = true;
            this.layeredButton2.Size = new System.Drawing.Size(34, 34);
            this.layeredButton2.TabIndex = 5;
            this.layeredButton2.Text = "layeredButton2";
            this.layeredButton2.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton2.TextShowMode = LayeredSkin.TextShowModes.None;
            // 
            // layeredButton1
            // 
            this.layeredButton1.AdaptImage = true;
            this.layeredButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredButton1.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.BottomWidth = 1;
            this.layeredButton1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.LeftWidth = 1;
            this.layeredButton1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.RightWidth = 1;
            this.layeredButton1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.TopWidth = 1;
            this.layeredButton1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton1.Canvas")));
            this.layeredButton1.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton1.HaloColor = System.Drawing.Color.White;
            this.layeredButton1.HaloSize = 5;
            this.layeredButton1.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.HoverImage")));
            this.layeredButton1.IsPureColor = false;
            this.layeredButton1.Location = new System.Drawing.Point(87, 21);
            this.layeredButton1.Name = "layeredButton1";
            this.layeredButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.NormalImage")));
            this.layeredButton1.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.PressedImage")));
            this.layeredButton1.Radius = 10;
            this.layeredButton1.ShowBorder = true;
            this.layeredButton1.Size = new System.Drawing.Size(34, 34);
            this.layeredButton1.TabIndex = 4;
            this.layeredButton1.Text = "layeredButton1";
            this.layeredButton1.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton1.TextShowMode = LayeredSkin.TextShowModes.None;
            // 
            // layeredPictureBox5
            // 
            this.layeredPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPictureBox5.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox5.Borders.BottomWidth = 1;
            this.layeredPictureBox5.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox5.Borders.LeftWidth = 1;
            this.layeredPictureBox5.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox5.Borders.RightWidth = 1;
            this.layeredPictureBox5.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox5.Borders.TopWidth = 1;
            this.layeredPictureBox5.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox5.Canvas")));
            this.layeredPictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("layeredPictureBox5.Image")));
            this.layeredPictureBox5.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("layeredPictureBox5.Images")))))};
            this.layeredPictureBox5.Interval = 100;
            this.layeredPictureBox5.Location = new System.Drawing.Point(106, 48);
            this.layeredPictureBox5.MultiImageAnimation = false;
            this.layeredPictureBox5.Name = "layeredPictureBox5";
            this.layeredPictureBox5.Size = new System.Drawing.Size(99, 106);
            this.layeredPictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.layeredPictureBox5.TabIndex = 3;
            this.layeredPictureBox5.Text = "layeredPictureBox5";
            this.layeredPictureBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFormMove);
            // 
            // layeredPictureBox4
            // 
            this.layeredPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPictureBox4.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox4.Borders.BottomWidth = 1;
            this.layeredPictureBox4.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox4.Borders.LeftWidth = 1;
            this.layeredPictureBox4.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox4.Borders.RightWidth = 1;
            this.layeredPictureBox4.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox4.Borders.TopWidth = 1;
            this.layeredPictureBox4.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox4.Canvas")));
            this.layeredPictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("layeredPictureBox4.Image")));
            this.layeredPictureBox4.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("layeredPictureBox4.Images")))))};
            this.layeredPictureBox4.Interval = 100;
            this.layeredPictureBox4.Location = new System.Drawing.Point(2, 47);
            this.layeredPictureBox4.MultiImageAnimation = false;
            this.layeredPictureBox4.Name = "layeredPictureBox4";
            this.layeredPictureBox4.Size = new System.Drawing.Size(99, 106);
            this.layeredPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.layeredPictureBox4.TabIndex = 2;
            this.layeredPictureBox4.Text = "layeredPictureBox4";
            this.layeredPictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFormMove);
            // 
            // layeredPictureBox3
            // 
            this.layeredPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPictureBox3.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox3.Borders.BottomWidth = 1;
            this.layeredPictureBox3.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox3.Borders.LeftWidth = 1;
            this.layeredPictureBox3.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox3.Borders.RightWidth = 1;
            this.layeredPictureBox3.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox3.Borders.TopWidth = 1;
            this.layeredPictureBox3.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox3.Canvas")));
            this.layeredPictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("layeredPictureBox3.Image")));
            this.layeredPictureBox3.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("layeredPictureBox3.Images")))))};
            this.layeredPictureBox3.Interval = 100;
            this.layeredPictureBox3.Location = new System.Drawing.Point(54, 99);
            this.layeredPictureBox3.MultiImageAnimation = false;
            this.layeredPictureBox3.Name = "layeredPictureBox3";
            this.layeredPictureBox3.Size = new System.Drawing.Size(99, 106);
            this.layeredPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.layeredPictureBox3.TabIndex = 1;
            this.layeredPictureBox3.Text = "layeredPictureBox3";
            this.layeredPictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFormMove);
            // 
            // layeredPictureBox2
            // 
            this.layeredPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPictureBox2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.BottomWidth = 1;
            this.layeredPictureBox2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.LeftWidth = 1;
            this.layeredPictureBox2.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.RightWidth = 1;
            this.layeredPictureBox2.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.TopWidth = 1;
            this.layeredPictureBox2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox2.Canvas")));
            this.layeredPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("layeredPictureBox2.Image")));
            this.layeredPictureBox2.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(((System.Drawing.Image)(resources.GetObject("layeredPictureBox2.Images")))))};
            this.layeredPictureBox2.Interval = 100;
            this.layeredPictureBox2.Location = new System.Drawing.Point(54, -5);
            this.layeredPictureBox2.MultiImageAnimation = false;
            this.layeredPictureBox2.Name = "layeredPictureBox2";
            this.layeredPictureBox2.Size = new System.Drawing.Size(99, 106);
            this.layeredPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.layeredPictureBox2.TabIndex = 0;
            this.layeredPictureBox2.Text = "layeredPictureBox2";
            this.layeredPictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFormMove);
            // 
            // layeredCheckButton1
            // 
            this.layeredCheckButton1.AdaptImage = true;
            this.layeredCheckButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredCheckButton1.BaseColor = System.Drawing.Color.Wheat;
            this.layeredCheckButton1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredCheckButton1.Borders.BottomWidth = 1;
            this.layeredCheckButton1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredCheckButton1.Borders.LeftWidth = 1;
            this.layeredCheckButton1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredCheckButton1.Borders.RightWidth = 1;
            this.layeredCheckButton1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredCheckButton1.Borders.TopWidth = 1;
            this.layeredCheckButton1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredCheckButton1.Canvas")));
            this.layeredCheckButton1.Checked = true;
            this.layeredCheckButton1.CheckedHover = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.CheckedHover")));
            this.layeredCheckButton1.CheckedNormal = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.CheckedNormal")));
            this.layeredCheckButton1.CheckedPressed = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.CheckedPressed")));
            this.layeredCheckButton1.CheckOnClick = true;
            this.layeredCheckButton1.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredCheckButton1.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.HoverImage")));
            this.layeredCheckButton1.IsPureColor = false;
            this.layeredCheckButton1.Location = new System.Drawing.Point(80, 75);
            this.layeredCheckButton1.Name = "layeredCheckButton1";
            this.layeredCheckButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.NormalImage")));
            this.layeredCheckButton1.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.PressedImage")));
            this.layeredCheckButton1.Radius = 10;
            this.layeredCheckButton1.ShowBorder = true;
            this.layeredCheckButton1.Size = new System.Drawing.Size(49, 49);
            this.layeredCheckButton1.TabIndex = 2;
            this.layeredCheckButton1.UncheckedHover = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.UncheckedHover")));
            this.layeredCheckButton1.UncheckedNormal = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.UncheckedNormal")));
            this.layeredCheckButton1.UncheckedPressed = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton1.UncheckedPressed")));
            // 
            // layeredCheckButton2
            // 
            this.layeredCheckButton2.AdaptImage = true;
            this.layeredCheckButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredCheckButton2.BaseColor = System.Drawing.Color.Wheat;
            this.layeredCheckButton2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredCheckButton2.Borders.BottomWidth = 1;
            this.layeredCheckButton2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredCheckButton2.Borders.LeftWidth = 1;
            this.layeredCheckButton2.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredCheckButton2.Borders.RightWidth = 1;
            this.layeredCheckButton2.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredCheckButton2.Borders.TopWidth = 1;
            this.layeredCheckButton2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredCheckButton2.Canvas")));
            this.layeredCheckButton2.Checked = false;
            this.layeredCheckButton2.CheckedHover = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.CheckedHover")));
            this.layeredCheckButton2.CheckedNormal = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.CheckedNormal")));
            this.layeredCheckButton2.CheckedPressed = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.CheckedPressed")));
            this.layeredCheckButton2.CheckOnClick = true;
            this.layeredCheckButton2.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredCheckButton2.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.HoverImage")));
            this.layeredCheckButton2.IsPureColor = false;
            this.layeredCheckButton2.Location = new System.Drawing.Point(69, 114);
            this.layeredCheckButton2.Name = "layeredCheckButton2";
            this.layeredCheckButton2.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.NormalImage")));
            this.layeredCheckButton2.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.PressedImage")));
            this.layeredCheckButton2.Radius = 10;
            this.layeredCheckButton2.ShowBorder = true;
            this.layeredCheckButton2.Size = new System.Drawing.Size(28, 26);
            this.layeredCheckButton2.TabIndex = 3;
            this.layeredCheckButton2.UncheckedHover = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.UncheckedHover")));
            this.layeredCheckButton2.UncheckedNormal = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.UncheckedNormal")));
            this.layeredCheckButton2.UncheckedPressed = ((System.Drawing.Image)(resources.GetObject("layeredCheckButton2.UncheckedPressed")));
            // 
            // layeredTrackBar1
            // 
            this.layeredTrackBar1.AdaptImage = true;
            this.layeredTrackBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredTrackBar1.BackImage = null;
            this.layeredTrackBar1.BackLineColor = System.Drawing.Color.Gray;
            this.layeredTrackBar1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredTrackBar1.Borders.BottomWidth = 1;
            this.layeredTrackBar1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredTrackBar1.Borders.LeftWidth = 1;
            this.layeredTrackBar1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredTrackBar1.Borders.RightWidth = 1;
            this.layeredTrackBar1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredTrackBar1.Borders.TopWidth = 1;
            this.layeredTrackBar1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredTrackBar1.Canvas")));
            this.layeredTrackBar1.ControlRectangle = new System.Drawing.Rectangle(5, 5, 40, 2);
            this.layeredTrackBar1.LineWidth = 2;
            this.layeredTrackBar1.Location = new System.Drawing.Point(94, 121);
            this.layeredTrackBar1.MouseCanControl = true;
            this.layeredTrackBar1.Name = "layeredTrackBar1";
            this.layeredTrackBar1.Orientation = LayeredSkin.Controls.Orientations.Horizontal;
            this.layeredTrackBar1.PointImage = ((System.Drawing.Image)(resources.GetObject("layeredTrackBar1.PointImage")));
            this.layeredTrackBar1.PointImageHover = null;
            this.layeredTrackBar1.PointImagePressed = null;
            this.layeredTrackBar1.PointState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredTrackBar1.Size = new System.Drawing.Size(50, 12);
            this.layeredTrackBar1.SurfaceImage = null;
            this.layeredTrackBar1.SurfaceLineColor = System.Drawing.Color.White;
            this.layeredTrackBar1.TabIndex = 4;
            this.layeredTrackBar1.Text = "layeredTrackBar1";
            this.layeredTrackBar1.Value = 0.5D;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 20;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1500;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Kugou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.CaptionShowMode = LayeredSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(208, 215);
            this.Controls.Add(this.layeredTrackBar1);
            this.Controls.Add(this.layeredCheckButton2);
            this.Controls.Add(this.layeredCheckButton1);
            this.Controls.Add(this.layeredPictureBox1);
            this.Controls.Add(this.layeredPanel1);
            this.DrawIcon = false;
            this.Name = "Kugou";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TopMost = true;
            this.layeredPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox1;
        private LayeredSkin.Controls.LayeredPanel layeredPanel1;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox2;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox5;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox4;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox3;
        private LayeredSkin.Controls.LayeredCheckButton layeredCheckButton1;
        private LayeredSkin.Controls.LayeredButton layeredButton1;
        private LayeredSkin.Controls.LayeredButton layeredButton3;
        private LayeredSkin.Controls.LayeredButton layeredButton2;
        private LayeredSkin.Controls.LayeredButton layeredButton4;
        private LayeredSkin.Controls.LayeredCheckButton layeredCheckButton2;
        private LayeredSkin.Controls.LayeredTrackBar layeredTrackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}