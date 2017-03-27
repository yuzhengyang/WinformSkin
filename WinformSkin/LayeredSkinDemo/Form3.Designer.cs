namespace test
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            LayeredSkin.Forms.ShadowBackgroundRender shadowBackgroundRender1 = new LayeredSkin.Forms.ShadowBackgroundRender();
            this.label1 = new System.Windows.Forms.Label();
            this.layeredLabel1 = new LayeredSkin.Controls.LayeredLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.layeredButton1 = new LayeredSkin.Controls.LayeredButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(109, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // layeredLabel1
            // 
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
            this.layeredLabel1.HaloSize = 5;
            this.layeredLabel1.Location = new System.Drawing.Point(183, 81);
            this.layeredLabel1.Name = "layeredLabel1";
            this.layeredLabel1.Size = new System.Drawing.Size(91, 24);
            this.layeredLabel1.TabIndex = 1;
            this.layeredLabel1.Text = "layeredLabel1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.layeredButton1.HoverImage = null;
            this.layeredButton1.IsPureColor = false;
            this.layeredButton1.Location = new System.Drawing.Point(136, 38);
            this.layeredButton1.Name = "layeredButton1";
            this.layeredButton1.NormalImage = null;
            this.layeredButton1.PressedImage = null;
            this.layeredButton1.Radius = 10;
            this.layeredButton1.ShowBorder = true;
            this.layeredButton1.Size = new System.Drawing.Size(109, 37);
            this.layeredButton1.TabIndex = 3;
            this.layeredButton1.Text = "layeredButton1";
            this.layeredButton1.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton1.TextShowMode = LayeredSkin.TextShowModes.Halo;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackgroundRender = shadowBackgroundRender1;
            this.ClientSize = new System.Drawing.Size(358, 307);
            this.Controls.Add(this.layeredButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.layeredLabel1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LayeredSkin.Controls.LayeredLabel layeredLabel1;
        private System.Windows.Forms.Button button1;
        private LayeredSkin.Controls.LayeredButton layeredButton1;
    }
}