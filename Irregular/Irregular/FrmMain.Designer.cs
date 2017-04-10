namespace Irregular
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnNewTwo = new System.Windows.Forms.Button();
            this.lblts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewTwo
            // 
            this.btnNewTwo.Location = new System.Drawing.Point(31, 72);
            this.btnNewTwo.Name = "btnNewTwo";
            this.btnNewTwo.Size = new System.Drawing.Size(75, 23);
            this.btnNewTwo.TabIndex = 0;
            this.btnNewTwo.Text = "测试窗体2";
            this.btnNewTwo.UseVisualStyleBackColor = true;
            this.btnNewTwo.Click += new System.EventHandler(this.btnNewTwo_Click);
            // 
            // lblts
            // 
            this.lblts.AutoSize = true;
            this.lblts.BackColor = System.Drawing.Color.Transparent;
            this.lblts.Location = new System.Drawing.Point(4, 5);
            this.lblts.Name = "lblts";
            this.lblts.Size = new System.Drawing.Size(77, 12);
            this.lblts.TabIndex = 1;
            this.lblts.Text = "测试窗体：QQ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(282, 564);
            this.Controls.Add(this.lblts);
            this.Controls.Add(this.btnNewTwo);
            this.MainPosition = new System.Drawing.Point(10, 10);
            this.Name = "FrmMain";
            this.SkinBack = global::Irregular.Properties.Resources.bj;
            this.SkinSize = new System.Drawing.Size(302, 586);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试窗体：QQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewTwo;
        private System.Windows.Forms.Label lblts;
    }
}

