using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransparentForm
{
    public partial class GraphicsPathForm : Form
    {
        public GraphicsPathForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void GraphicsPathForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Bitmap bitmap = new Bitmap(BackgroundImage);//背景图资源
            this.Region = new Region(GetWindowRegion(bitmap));
        }
        private GraphicsPath GetWindowRegion(Bitmap bitmap)
        {
            Color TempColor;
            GraphicsPath gp = new GraphicsPath();
            if (bitmap == null) return null;

            for (int nX = 0; nX < bitmap.Width; nX++)
            {
                for (int nY = 0; nY < bitmap.Height; nY++)
                {
                    TempColor = bitmap.GetPixel(nX, nY);
                    if (TempColor.A != 0)//Color.Transparent
                    {
                        gp.AddRectangle(new Rectangle(nX, nY, 1, 1));
                    }
                }
            }
            return gp;
        }
    }
}
