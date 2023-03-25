using System;
using System.Drawing;
using System.Windows.Forms;
using Winform.Animation.Train.Properties;

namespace Winform.Animation.Train.Animation
{
    public partial class AnimTrainLoadingPartial : UserControl
    {
        bool IsInit = false;
        Graphics G = null;
        Bitmap Bmp = null;
        Graphics BmpG = null;
        int W = 451, H = 261;//画布默认尺寸
        int Itv = 0;
        int TrainY = 0, TrainStep = 1, TrainMax = 3, TrainItv = 250;
        int WindX = 451, WindStep = 30, WindMin = -451, WindItv = 50;
        int CloudX = 0, CloudStep = 1, CloudMin = -451, CloudItv = 50;
        int BackX = 0, BackStep = 1, BackMin = -451, BackItv = 100;
        public AnimTrainLoadingPartial()
        {
            InitializeComponent();
        }
        private void AnimTrainLoadingPartial_Load(object sender, EventArgs e)
        {
        }
        private void Init()
        {
            if (!IsInit)
            {
                IsInit = true;
                try
                {
                    InitAnimParams();//初始化动作参数
                    G = CreateGraphics();
                    Bmp = new Bitmap(W, H);
                    BmpG = Graphics.FromImage(Bmp);
                }
                catch { }
            }
        }
        private void InitAnimParams()
        {
        }
        private void SetAnimParams()
        {
            Itv += TMAction.Interval;
            //计算火车位置
            if (Itv % TrainItv == 0)
                if ((TrainY = TrainY + TrainStep) >= TrainMax || TrainY <= 0) TrainStep *= -1;
            //计算风的位置
            if (Itv % WindItv == 0)
                if ((WindX = WindX - WindStep) <= WindMin) WindX = W;
            //计算云的位置
            if (Itv % CloudItv == 0)
                if ((CloudX = CloudX - CloudStep) <= CloudMin) CloudX = W;
            //计算背景建筑位置
            if (Itv % BackItv == 0)
                if ((BackX = BackX - BackStep) <= BackMin) BackX = W;
        }
        private void DrawElement(Bitmap bitmap, int x, int y)
        {
            Bitmap bp = bitmap;
            BmpG.DrawImage(bp, x, y, W, H);//绘制背景
            bp.Dispose();
        }
        private void TMAction_Tick(object sender, EventArgs e)
        {
            SetAnimParams();
            BmpG.FillRectangle(Brushes.White, 0, 0, W, H);
            DrawElement(Resources.train_back, BackX, 0);//绘制背景
            DrawElement(Resources.train_back, BackX > 0 ? BackX - W : BackX + W, 0);//绘制背景（补充）
            DrawElement(Resources.train_wheel, 0, 0);//绘制轮子
            DrawElement(Resources.train_body, 0, TrainY);//绘制车体
            DrawElement(Resources.train_cloud, CloudX, 0);//绘制云彩
            DrawElement(Resources.train_cloud, CloudX > 0 ? CloudX - W : CloudX + W, 0);//绘制云彩（补充）
            DrawElement(Resources.train_wind, WindX, 0);//绘制风
            G.DrawImage(Bmp, 0, 0, Width, Height);
        }
        public void Display(bool enable = true)
        {
            Init();
            TMAction.Enabled = enable;
            Visible = enable;
        }
        ~AnimTrainLoadingPartial()
        {
            BmpG?.Dispose();
            Bmp?.Dispose();
            G?.Dispose();
        }
    }
}
