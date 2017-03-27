namespace test
{
    partial class DuiTextBoxTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuiTextBoxTest));
            LayeredSkin.DirectUI.DuiTextBox duiTextBox2 = new LayeredSkin.DirectUI.DuiTextBox();
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
            duiTextBox2.AutoHeight = false;
            duiTextBox2.AutoSize = false;
            duiTextBox2.BackColor = System.Drawing.Color.Transparent;
            duiTextBox2.BackgroundImage = null;
            duiTextBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiTextBox2.BackgroundRender = null;
            duiTextBox2.BitmapCache = false;
            duiTextBox2.BorderPath = null;
            duiTextBox2.BorderRender = null;
            duiTextBox2.Borders.BottomColor = System.Drawing.Color.Empty;
            duiTextBox2.Borders.BottomWidth = 1;
            duiTextBox2.Borders.LeftColor = System.Drawing.Color.Empty;
            duiTextBox2.Borders.LeftWidth = 1;
            duiTextBox2.Borders.RightColor = System.Drawing.Color.Empty;
            duiTextBox2.Borders.RightWidth = 1;
            duiTextBox2.Borders.TopColor = System.Drawing.Color.Empty;
            duiTextBox2.Borders.TopWidth = 1;
            duiTextBox2.CanFocus = true;
            duiTextBox2.CaretColor = System.Drawing.SystemColors.ControlText;
            duiTextBox2.CaretIndex = 0;
            duiTextBox2.ClientRectangle = new System.Drawing.Rectangle(0, 0, 485, 388);
            duiTextBox2.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            duiTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            duiTextBox2.Enabled = true;
            duiTextBox2.Font = new System.Drawing.Font("方正舒体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiTextBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            duiTextBox2.Height = 388;
            duiTextBox2.IsInsert = true;
            duiTextBox2.IsMoveParentPaint = true;
            duiTextBox2.Left = 0;
            duiTextBox2.Location = new System.Drawing.Point(0, 0);
            duiTextBox2.Margin = new System.Windows.Forms.Padding(0);
            duiTextBox2.Multiline = true;
            duiTextBox2.Name = null;
            duiTextBox2.ParentInvalidate = true;
            duiTextBox2.ReadOnly = false;
            duiTextBox2.RollSize = 20;
            duiTextBox2.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            duiTextBox2.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            duiTextBox2.ScrollBarNormalColor = System.Drawing.Color.Gray;
            duiTextBox2.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            duiTextBox2.SelectionBackColor = System.Drawing.Color.Gray;
            duiTextBox2.SelectionColor = System.Drawing.Color.White;
            duiTextBox2.SelectionLength = 0;
            duiTextBox2.SelectionStart = 0;
            duiTextBox2.ShowBorder = true;
            duiTextBox2.ShowScrollBar = true;
            duiTextBox2.Size = new System.Drawing.Size(485, 388);
            duiTextBox2.SuspendInvalidate = false;
            duiTextBox2.Tag = null;
            duiTextBox2.Text = "123Abc测试";
            duiTextBox2.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAlias;
            duiTextBox2.Top = 0;
            duiTextBox2.Visible = true;
            duiTextBox2.Width = 485;
            this.layeredBaseControl1.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiTextBox2});
            this.layeredBaseControl1.Location = new System.Drawing.Point(12, 32);
            this.layeredBaseControl1.Name = "layeredBaseControl1";
            this.layeredBaseControl1.Size = new System.Drawing.Size(485, 388);
            this.layeredBaseControl1.TabIndex = 0;
            this.layeredBaseControl1.Text = "layeredBaseControl1";
            // 
            // DuiTextBoxTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(511, 433);
            this.Controls.Add(this.layeredBaseControl1);
            this.Name = "DuiTextBoxTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DuiTextBoxTest";
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredBaseControl layeredBaseControl1;
    }
}