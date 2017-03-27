namespace test
{
    partial class Chuyin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chuyin));
            LayeredSkin.DirectUI.DuiPictureBox duiPictureBox1 = new LayeredSkin.DirectUI.DuiPictureBox();
            this.layeredBaseControl1 = new LayeredSkin.Controls.LayeredBaseControl();
            this.SuspendLayout();
            // 
            // layeredBaseControl1
            // 
            this.layeredBaseControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredBaseControl1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.BottomWidth = 1;
            this.layeredBaseControl1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.LeftWidth = 1;
            this.layeredBaseControl1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.RightWidth = 1;
            this.layeredBaseControl1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.TopWidth = 1;
            this.layeredBaseControl1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredBaseControl1.Canvas")));
            duiPictureBox1.AutoPlay = true;
            duiPictureBox1.AutoSize = false;
            duiPictureBox1.BackColor = System.Drawing.Color.Transparent;
            duiPictureBox1.BackgroundImage = null;
            duiPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiPictureBox1.BackgroundRender = null;
            duiPictureBox1.BitmapCache = false;
            duiPictureBox1.BorderPath = null;
            duiPictureBox1.BorderRender = null;
            duiPictureBox1.Borders.BottomColor = System.Drawing.Color.Empty;
            duiPictureBox1.Borders.BottomWidth = 1;
            duiPictureBox1.Borders.LeftColor = System.Drawing.Color.Empty;
            duiPictureBox1.Borders.LeftWidth = 1;
            duiPictureBox1.Borders.RightColor = System.Drawing.Color.Empty;
            duiPictureBox1.Borders.RightWidth = 1;
            duiPictureBox1.Borders.TopColor = System.Drawing.Color.Empty;
            duiPictureBox1.Borders.TopWidth = 1;
            duiPictureBox1.CanFocus = true;
            duiPictureBox1.ClientRectangle = new System.Drawing.Rectangle(0, 0, 100, 100);
            duiPictureBox1.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiPictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            duiPictureBox1.Dock = System.Windows.Forms.DockStyle.None;
            duiPictureBox1.Enabled = true;
            duiPictureBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            duiPictureBox1.Height = 100;
            duiPictureBox1.Image = null;
            duiPictureBox1.Images = null;
            duiPictureBox1.Interval = 100;
            duiPictureBox1.IsMoveParentPaint = true;
            duiPictureBox1.Left = 0;
            duiPictureBox1.Location = new System.Drawing.Point(0, 0);
            duiPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            duiPictureBox1.MultiImageAnimation = false;
            duiPictureBox1.Name = "chuyin";
            duiPictureBox1.ParentInvalidate = true;
            duiPictureBox1.ShowBorder = true;
            duiPictureBox1.Size = new System.Drawing.Size(100, 100);
            duiPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            duiPictureBox1.SuspendInvalidate = false;
            duiPictureBox1.Tag = null;
            duiPictureBox1.Top = 0;
            duiPictureBox1.Visible = true;
            duiPictureBox1.Width = 100;
            this.layeredBaseControl1.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiPictureBox1});
            this.layeredBaseControl1.Location = new System.Drawing.Point(12, 6);
            this.layeredBaseControl1.Name = "layeredBaseControl1";
            this.layeredBaseControl1.Size = new System.Drawing.Size(279, 283);
            this.layeredBaseControl1.TabIndex = 0;
            this.layeredBaseControl1.Text = "layeredBaseControl1";
            this.layeredBaseControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layeredBaseControl1_MouseDown);
            // 
            // Chuyin
            // 
            this.AnimationType = LayeredSkin.Forms.AnimationTypes.RotateZoomEffect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.CaptionShowMode = LayeredSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.layeredBaseControl1);
            this.DrawIcon = false;
            this.Name = "Chuyin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyin";
            this.Load += new System.EventHandler(this.Chuyin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredBaseControl layeredBaseControl1;
    }
}