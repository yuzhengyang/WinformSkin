namespace Irregular
{
    partial class FrmCF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCF));
            this.btnNewTree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNewTree
            // 
            this.btnNewTree.Location = new System.Drawing.Point(335, 209);
            this.btnNewTree.Name = "btnNewTree";
            this.btnNewTree.Size = new System.Drawing.Size(75, 23);
            this.btnNewTree.TabIndex = 0;
            this.btnNewTree.Text = "测试窗体3";
            this.btnNewTree.UseVisualStyleBackColor = true;
            this.btnNewTree.Click += new System.EventHandler(this.btnNewTree_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(200, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "CF登录测试窗体";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(308, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 21);
            this.textBox1.TabIndex = 2;
            // 
            // FrmCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(744, 617);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewTree);
            this.MainPosition = new System.Drawing.Point(18, 35);
            this.Name = "FrmCF";
            this.SkinBack = global::Irregular.Properties.Resources.DL;
            this.SkinSize = new System.Drawing.Size(780, 659);
            this.SkinTrankColor = System.Drawing.Color.Fuchsia;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试窗体：CF登录";
            this.Load += new System.EventHandler(this.FrmCF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}