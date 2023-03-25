using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Animation.Train
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTStart_Click(object sender, EventArgs e)
        {
            animTrainLoadingPartial1.Display();
        }

        private void BTStop_Click(object sender, EventArgs e)
        {
            animTrainLoadingPartial1.Display(false);
        }
    }
}
