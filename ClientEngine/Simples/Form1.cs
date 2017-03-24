using Client.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.UI.Base.Render;

namespace Simples
{
    public partial class Form1 :CustomForm
    {
        public Form1():base()
        {
            InitializeComponent();
            this.tabControl2.Region = new Region(new RectangleF(this.tabPage1.Left, this.tabPage1.Top, this.tabPage1.Width, this.tabPage1.Height));
            //this.TitleButtonOnClick += new Client.UI.Base.Render.TitleRender.TitleButtonOnClickHandler(Form1_TitleButtonOnClick);
        }

        void Form1_TitleButtonOnClick(object sender, Point mousePoint)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QQ.QQForm qf = new QQ.QQForm();
            qf.Show();
            //Youdao.YoudaoForm yf = new Youdao.YoudaoForm();
            //yf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void uiToolBar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab =tabControl1.TabPages[uiToolBar1.SelectedIndex]; 
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.tabControl2.Region = new Region(new RectangleF(this.tabPage1.Left, this.tabPage1.Top, this.tabPage1.Width, this.tabPage1.Height));
            //this.tabControl1.Invalidate();
            //this.tabControl2.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
