using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class QQConfig : LayeredSkin.Forms.LayeredForm
    {
        public QQConfig(QQ qq)
        {
            InitializeComponent();
            this.qq = qq;
        }
        QQ qq;
        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void QQConfig_Load(object sender, EventArgs e)
        {
            //layeredPictureBox1.Play();
        }

        private void layeredButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Animation.AnimationEnd += Animation_AnimationEnd;
        }

        void Animation_AnimationEnd(object sender, LayeredSkin.Animations.AnimationEventArgs e)
        {
            this.Hide();
            qq.isShow = true;
            qq.Location = this.Location;
            qq.Animation.Asc = true;
            qq.Animation.AnimationStarted += Animation_AnimationStarted;
            qq.Animation.Start();
        }

        void Animation_AnimationStarted(object sender, LayeredSkin.Animations.AnimationEventArgs e)
        {
            qq.Show();
            this.Dispose();
        }

    }
}
