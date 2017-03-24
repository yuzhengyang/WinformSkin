using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisSkin4
{
    public partial class Form1 : Form
    {
        Sunisoft.IrisSkin.SkinEngine SkinEngine = new Sunisoft.IrisSkin.SkinEngine();
        List<string> Skins;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载所有皮肤列表
            Skins = Directory.GetFiles(Application.StartupPath + @"\IrisSkin4\Skins\", "*.ssk").ToList();
            Skins.ForEach(x =>
            {
                dataGridView1.Rows.Add(Path.GetFileNameWithoutExtension(x));
            });
        }

        //选择皮肤并使用
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                //加载皮肤
                SkinEngine.SkinFile = Skins[dataGridView1.CurrentRow.Index];
                SkinEngine.Active = true;
            }
        }

        //打开 MessageBox 对话框
        private void BtMessageBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MessageBoxMessageBoxMessageBoxMessageBox");
        }

        //打开测试窗口
        private void BtForm2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void BtNormal_Click(object sender, EventArgs e)
        {
            SkinEngine.Active = false;
        }
    }
}
