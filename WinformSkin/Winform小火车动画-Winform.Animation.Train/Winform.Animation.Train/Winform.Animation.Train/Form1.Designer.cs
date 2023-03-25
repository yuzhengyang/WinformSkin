namespace Winform.Animation.Train
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BTStart = new System.Windows.Forms.Button();
            this.BTStop = new System.Windows.Forms.Button();
            this.animTrainLoadingPartial1 = new Winform.Animation.Train.Animation.AnimTrainLoadingPartial();
            this.SuspendLayout();
            // 
            // BTStart
            // 
            this.BTStart.Location = new System.Drawing.Point(251, 285);
            this.BTStart.Name = "BTStart";
            this.BTStart.Size = new System.Drawing.Size(100, 23);
            this.BTStart.TabIndex = 1;
            this.BTStart.Text = "开始动画";
            this.BTStart.UseVisualStyleBackColor = true;
            this.BTStart.Click += new System.EventHandler(this.BTStart_Click);
            // 
            // BTStop
            // 
            this.BTStop.Location = new System.Drawing.Point(366, 285);
            this.BTStop.Name = "BTStop";
            this.BTStop.Size = new System.Drawing.Size(100, 23);
            this.BTStop.TabIndex = 2;
            this.BTStop.Text = "停止动画";
            this.BTStop.UseVisualStyleBackColor = true;
            this.BTStop.Click += new System.EventHandler(this.BTStop_Click);
            // 
            // animTrainLoadingPartial1
            // 
            this.animTrainLoadingPartial1.BackColor = System.Drawing.Color.White;
            this.animTrainLoadingPartial1.Location = new System.Drawing.Point(12, 12);
            this.animTrainLoadingPartial1.Name = "animTrainLoadingPartial1";
            this.animTrainLoadingPartial1.Size = new System.Drawing.Size(451, 261);
            this.animTrainLoadingPartial1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 320);
            this.Controls.Add(this.BTStop);
            this.Controls.Add(this.BTStart);
            this.Controls.Add(this.animTrainLoadingPartial1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Animation.AnimTrainLoadingPartial animTrainLoadingPartial1;
        private System.Windows.Forms.Button BTStart;
        private System.Windows.Forms.Button BTStop;
    }
}

