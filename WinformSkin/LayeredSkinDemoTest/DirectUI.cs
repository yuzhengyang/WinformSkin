using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.DirectUI;

namespace test
{
    public partial class DirectUI : LayeredForm
    {
        public DirectUI()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            this.Animation.Effect = new LayeredSkin.Animations.BlindWindowEffect();
            layeredBaseControl1.DUIControls[2].BackgroundRender = new LayeredSkin.DirectUI.GradientBackgroundRender(new Color[] { Color.Green, Color.Blue, Color.Red, Color.Gold, Color.White }, 30f);
            layeredBaseControl1.DUIControls[0].BorderRender = new LayeredSkin.DirectUI.FilletBorderRender(15, 1, Color.Red);
            this.BackgroundRender = new ShadowBackgroundRender();

            layeredBaseControl1.DUIControls.Add(new DuiScrollBar() { Location = new Point(150, 5), BackColor = Color.White, Orientation = Orientation.Horizontal });

            layeredBaseControl1.InnerDuiControl.FindControl("TextBox多行")[0].MouseMove += ((s, E) =>
            {
                ((LayeredSkin.DirectUI.DuiLabel)layeredBaseControl1.InnerDuiControl.FindControl("label")[0]).Text = E.Location.ToString();
            });
            layeredBaseControl1.InnerDuiControl.FindControl("TextBox多行")[0].MouseClick += ((s, E) =>
            {//添加右键菜单
                if (E.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            });
        }


        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Animation.Effect = new LayeredSkin.Animations.ThreeDTurn();
            this.Close();
        }

        Image smile = Image.FromFile("Images\\smile.png");
        private void layeredButton3_Click(object sender, EventArgs e)
        {
            DuiCheckBox checkbox = new DuiCheckBox();
            DuiPictureBox pic = new DuiPictureBox() { SizeMode = PictureBoxSizeMode.AutoSize, Image = smile };
            layeredBaseControl1.InnerDuiControl.FindControl("TextBox多行")[0].Controls.Add(checkbox);
            layeredBaseControl1.InnerDuiControl.FindControl("TextBox多行")[0].Controls.Add(pic);
            ((DuiTextBox)layeredBaseControl1.InnerDuiControl.FindControl("TextBox多行")[0]).LayoutContent();
        }


        private void layeredBaseControl1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Test");
        }

    }
}
