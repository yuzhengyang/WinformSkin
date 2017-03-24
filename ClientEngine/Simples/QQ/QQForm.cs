using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Simples.QQ
{
    public partial class QQForm : QQCustomForm
    {
        public QQForm()
        {
            InitializeComponent();
            this.BackgroundImage = Bitmap.FromFile(@".\Res\FormBkg\bkg_owl.jpg");
        }
    }
}
