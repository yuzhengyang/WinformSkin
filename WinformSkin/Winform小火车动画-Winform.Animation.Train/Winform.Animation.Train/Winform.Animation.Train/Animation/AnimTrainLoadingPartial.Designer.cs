namespace Winform.Animation.Train.Animation
{
    partial class AnimTrainLoadingPartial
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TMAction = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TMAction
            // 
            this.TMAction.Interval = 50;
            this.TMAction.Tick += new System.EventHandler(this.TMAction_Tick);
            // 
            // AnimTrainLoadingPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.DoubleBuffered = true;
            this.Name = "AnimTrainLoadingPartial";
            this.Size = new System.Drawing.Size(451, 261);
            this.Load += new System.EventHandler(this.AnimTrainLoadingPartial_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TMAction;
    }
}
