namespace test
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layeredTrackBar1 = new LayeredSkin.Controls.LayeredTrackBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(55, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(331, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(115, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 179);
            this.panel1.TabIndex = 2;
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
            this.layeredTrackBar1.ControlRectangle = new System.Drawing.Rectangle(5, 5, 261, 24);
            this.layeredTrackBar1.LineWidth = 1;
            this.layeredTrackBar1.Location = new System.Drawing.Point(45, 41);
            this.layeredTrackBar1.MouseCanControl = true;
            this.layeredTrackBar1.Name = "layeredTrackBar1";
            this.layeredTrackBar1.Orientation = LayeredSkin.Controls.Orientations.Horizontal;
            this.layeredTrackBar1.PointImage = null;
            this.layeredTrackBar1.PointImageHover = null;
            this.layeredTrackBar1.PointImagePressed = null;
            this.layeredTrackBar1.PointState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredTrackBar1.Size = new System.Drawing.Size(271, 34);
            this.layeredTrackBar1.SurfaceImage = null;
            this.layeredTrackBar1.SurfaceLineColor = System.Drawing.Color.White;
            this.layeredTrackBar1.TabIndex = 3;
            this.layeredTrackBar1.Text = "layeredTrackBar1";
            this.layeredTrackBar1.Value = 0.5D;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(22, 103);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(25, 160);
            this.vScrollBar1.TabIndex = 4;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(420, 304);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.layeredTrackBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private LayeredSkin.Controls.LayeredTrackBar layeredTrackBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;


    }
}