using LayeredSkinDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredSkinDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            BitmapRegion BitmapRegion = new BitmapRegion();//此为生成不规则窗体和控件的类 
            BitmapRegion.CreateControlRegion(this, new Bitmap(Resources.planet_univearse_telestial_space_mars));

        }



    }
}
