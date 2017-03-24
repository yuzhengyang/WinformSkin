using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin;
using LayeredSkin.DirectUI;

namespace test
{
    public partial class Metro : LayeredSkin.Forms.LayeredForm
    {
        public Metro()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Color[] colors = new Color[] {
                Color.FromArgb(23, 149, 75),
                Color.FromArgb(1, 187, 225), 
                Color.FromArgb(176, 226, 64),
                Color.FromArgb(160, 0, 168), 
                Color.FromArgb(190, 30, 74),
                Color.FromArgb(10, 89, 196),
                Color.FromArgb(218, 84, 46),
            };

            Random r = new Random();

            MetroList.Width = this.Width - 100;
            MetroList.Height = this.Height - 100;

            for (int i = 0; i < 1000; i++)
            {
                DuiLabel lbl = new DuiLabel();
                lbl.Size = new System.Drawing.Size(190, 140);
                lbl.Text = (i + 1).ToString();
                lbl.Location = new Point(5, 0);
                lbl.BackColor = colors[r.Next(0, colors.Length)];
                lbl.ForeColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.MouseEnter += lbl_MouseEnter;
                lbl.MouseLeave += lbl_MouseLeave;

                DuiBaseControl item = new DuiBaseControl();
                //item.BackColor = Color.FromArgb(14, 109, 56);
                item.Size = new System.Drawing.Size(200, 150);
                item.Controls.Add(lbl);
                MetroList.Items.Add(item);
            }
            MetroList.RefreshList();
        }



        void lbl_MouseLeave(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).Borders.BottomColor = Color.Empty;
            ((DuiBaseControl)sender).Borders.LeftColor = Color.Empty;
            ((DuiBaseControl)sender).Borders.RightColor = Color.Empty;
            ((DuiBaseControl)sender).Borders.TopColor = Color.Empty;
        }

        void lbl_MouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).Borders.BottomWidth = 4;
            ((DuiBaseControl)sender).Borders.LeftWidth = 4;
            ((DuiBaseControl)sender).Borders.RightWidth = 4;
            ((DuiBaseControl)sender).Borders.TopWidth = 4;

            ((DuiBaseControl)sender).Borders.BottomColor = Color.White;
            ((DuiBaseControl)sender).Borders.LeftColor = Color.White;
            ((DuiBaseControl)sender).Borders.RightColor = Color.White;
            ((DuiBaseControl)sender).Borders.TopColor = Color.White;
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
