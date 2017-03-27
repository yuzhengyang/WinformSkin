using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //double[] xcorner = new double[] { 200, 400, 454, 0 };
            //double[] ycorner = new double[] { 0, 340, 300, 344 };

        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //List<double> xcorner = new List<double>();
                    //xcorner.Add(0);
                    //xcorner.Add(350);
                    //xcorner.Add(350);
                    //xcorner.Add(0);
                    //List<double> ycorner = new List<double>();
                    //ycorner.Add(0);
                    //ycorner.Add(140);
                    //ycorner.Add(300);
                    //ycorner.Add(344);

                    //Bitmap result = null;
                    //Aaform aaform = new Aaform();
                    //aaform.CreateTransform(new Bitmap(Image.FromFile(ofd.FileName)), ref result, xcorner, ycorner, null);
                    //pictureBox1.Image = result;




                    //pictureBox1.Image = Transformation(new Bitmap(Image.FromFile(ofd.FileName)), new Point(50, 0), new Point(300, 0), new Point(0, 400), new Point(400, 400));

                    //LayeredSkin.Quadrilateral q = new LayeredSkin.Quadrilateral();
                    //pictureBox1.Image = q.Transform(new Bitmap(Image.FromFile(ofd.FileName)), new double[] { 0, 350, 350, 0 }, new double[] { 0, 140, 300, 344 }, Color.Transparent);



                    //Bitmap bmp = new Bitmap(Image.FromFile(ofd.FileName));
                    //LayeredSkin.ImageEffects.ChangeOpacity(bmp, 0.5, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    //pictureBox1.Image = bmp;



                    Bitmap bmp = new Bitmap(Image.FromFile(ofd.FileName));
                    this.BackgroundImage = LayeredSkin.ImageEffects.TrapezoidTransformation(bmp, 0.5, 0.6, true, true);
                }
            }
        }

    }

    public delegate bool Aaf_callback(double paraDouble);

    struct AafPnt
    {
        public double x, y;
        public AafPnt(double x, double y)
        {
            this.x = x < 0 ? 0 : x;
            this.y = y < 0 ? 0 : y;
        }
    }

    class aaf_dblrgbquad
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
        public double Alpha { get; set; }
    }

    class aaf_indll
    {
        public aaf_indll next;
        public int ind;
    }

    class Aaform
    {
        private AafPnt[] pixelgrid;
        private AafPnt[] polyoverlap;
        private AafPnt[] polysorted;
        private AafPnt[] corners;

        private int outstartx;
        private int outstarty;
        private int outwidth;
        private int outheight;

        int polyoverlapsize;
        int polysortedsize;

        int[] ja = new int[] { 1, 2, 3, 0 };

        public void CreateTransform(Bitmap src, ref Bitmap dst, List<double> xcorner, List<double> ycorner, Aaf_callback callbackfunc)
        {
            int right = 0, bottom = 0;

            //主要是根据新图片的坐标，计算出图片的宽和高，构造目标图片的Bitmap的
            double offx = xcorner[0];
            double offy = ycorner[0];
            for (int i = 1; i < 4; i++)
            {
                if (xcorner[i] < offx) offx = xcorner[i];
                if (ycorner[i] < offy) offy = ycorner[i];
            }

            for (int i = 0; i < 4; i++)
            {
                xcorner[i] -= offx;
                ycorner[i] -= offy;
                if (roundup(xcorner[i]) > right) right = roundup(xcorner[i]);
                if (roundup(ycorner[i]) > bottom) bottom = roundup(ycorner[i]);
            }
            dst = new Bitmap(right, bottom);
            Transform(src, dst, xcorner, ycorner, null);
        }

        private void Transform(Bitmap src, Bitmap dst, List<double> xcorner, List<double> ycorner, Aaf_callback callbackfunc)
        {
            //Make sure the coordinates are valid
            if (xcorner.Count != 4 || ycorner.Count != 4)
                return;

            //Load the src bitmaps information

            //create the intial arrays
            //根据原图片生成一个比原图宽高多一个单位的图片,
            //这个矩阵就是用来记录转换后各个像素点左上角的坐标
            pixelgrid = new AafPnt[(src.Width + 1) * (src.Height + 1)];
            polyoverlap = new AafPnt[16];
            polysorted = new AafPnt[16];
            corners = new AafPnt[4];

            //Load the corners array
            double[] dx = { 0.0, 1.0, 1.0, 0.0 };
            double[] dy = { 0.0, 0.0, 1.0, 1.0 };
            for (int i = 0; i < 4; i++)
            {
                corners[i].x = dx[i];
                corners[i].y = dy[i];
            }

            //Find the rectangle of dst to draw to
            outstartx = rounddown(xcorner[0]);
            outstarty = rounddown(ycorner[0]);
            outwidth = 0;
            outheight = 0;
            //这里计算出变换后起始点的坐标
            for (int i = 1; i < 4; i++)
            {
                if (rounddown(xcorner[i]) < outstartx) outstartx = rounddown(xcorner[i]);
                if (rounddown(ycorner[i]) < outstarty) outstarty = rounddown(ycorner[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                if (roundup(xcorner[i] - outstartx) > outwidth) outwidth = roundup(xcorner[i] - outstartx);
                if (roundup(ycorner[i] - outstarty) > outheight) outheight = roundup(ycorner[i] - outstarty);
            }


            //fill out pixelgrid array
            //计算出理想目标图片中各个“像素格”中的左上角的坐标
            if (CreateGrid(src, xcorner, ycorner))
            {
                //Do the transformation
                //进行转换
                DoTransform(src, dst, callbackfunc);
            }

            //Return if the function completed properly
            return;
        }

        private bool CreateGrid(Bitmap src, List<double> xcorner, List<double> ycorner)
        {
            //mmm geometry
            double[] sideradius = new double[4];
            double[] sidecos = new double[4];
            double[] sidesin = new double[4];

            //First we find the radius, cos, and sin of each side of the polygon created by xcorner and ycorner
            int j;
            for (int i = 0; i < 4; i++)
            {
                j = ja[i];
                sideradius[i] = Math.Sqrt((xcorner[i] - xcorner[j]) * (xcorner[i] - xcorner[j]) + (ycorner[i] - ycorner[j]) * (ycorner[i] - ycorner[j]));
                sidecos[i] = (xcorner[j] - xcorner[i]) / sideradius[i];
                sidesin[i] = (ycorner[j] - ycorner[i]) / sideradius[i];
            }

            //Next we create two lines in Ax + By = C form
            for (int x = 0; x < src.Width + 1; x++)
            {
                double topdist = ((double)x / (src.Width)) * sideradius[0];//每个像素点变换后的坐标点
                double ptxtop = xcorner[0] + topdist * sidecos[0];
                double ptytop = ycorner[0] + topdist * sidesin[0];

                double botdist = (1.0 - (double)x / (src.Width)) * sideradius[2];
                double ptxbot = xcorner[2] + botdist * sidecos[2];
                double ptybot = ycorner[2] + botdist * sidesin[2];

                double Ah = ptybot - ptytop;
                double Bh = ptxtop - ptxbot;
                double Ch = Ah * ptxtop + Bh * ptytop;//叉乘

                for (int y = 0; y < src.Height + 1; y++)
                {
                    double leftdist = (1.0 - (double)y / (src.Height)) * sideradius[3];
                    double ptxleft = xcorner[3] + leftdist * sidecos[3];
                    double ptyleft = ycorner[3] + leftdist * sidesin[3];

                    double rightdist = ((double)y / (src.Height)) * sideradius[1];
                    double ptxright = xcorner[1] + rightdist * sidecos[1];
                    double ptyright = ycorner[1] + rightdist * sidesin[1];

                    double Av = ptyright - ptyleft;
                    double Bv = ptxleft - ptxright;
                    double Cv = Av * ptxleft + Bv * ptyleft;

                    //Find where the lines intersect and store that point in the pixelgrid array
                    double det = Ah * Bv - Av * Bh;
                    if (AafAbs(det) < 1e-9)
                    {
                        return false;
                    }
                    else
                    {
                        int ind = x + y * (src.Width + 1);
                        pixelgrid[ind].x = (Bv * Ch - Bh * Cv) / det;
                        pixelgrid[ind].y = (Ah * Cv - Av * Ch) / det;
                    }
                }
            }

            //Yayy we didn't fail
            return true;
        }

        private void DoTransform(Bitmap src, Bitmap dst, Aaf_callback callbackfunc)
        {

            //Get source bitmap's information
            if (src == null) return;

            //Create the source dib array and the dstdib array
            aaf_dblrgbquad[] dbldstdib = new aaf_dblrgbquad[outwidth * outheight];
            for (int i = 0; i < dbldstdib.Length; i++)
                dbldstdib[i] = new aaf_dblrgbquad();

            //Create polygon arrays
            AafPnt[] p = new AafPnt[4];
            AafPnt[] poffset = new AafPnt[4];

            //Loop through the source's pixels
            //遍历原图（实质上是pixelgrid）各个点
            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    //取当前点 下一点 右一点 斜右下角点 四点才组成一个四边形
                    //这个四边形是原图像的一个像素点
                    //Construct the source pixel's rotated polygon from pixelgrid
                    p[0] = pixelgrid[x + y * (src.Width + 1)];
                    p[1] = pixelgrid[(x + 1) + y * (src.Width + 1)];
                    p[2] = pixelgrid[(x + 1) + (y + 1) * (src.Width + 1)];
                    p[3] = pixelgrid[x + (y + 1) * (src.Width + 1)];

                    //Find the scan area on the destination's pixels
                    int mindx = int.MaxValue;
                    int mindy = int.MaxValue;
                    int maxdx = int.MinValue;
                    int maxdy = int.MinValue;
                    for (int i = 0; i < 4; i++)
                    {
                        if (rounddown(p[i].x) < mindx) mindx = rounddown(p[i].x);
                        if (roundup(p[i].x) > maxdx) maxdx = roundup(p[i].x);
                        if (rounddown(p[i].y) < mindy) mindy = rounddown(p[i].y);
                        if (roundup(p[i].y) > maxdy) maxdy = roundup(p[i].y);
                    }

                    int SrcIndex = x + y * src.Width;
                    //遍历四边形包含了目标图几个像素点
                    //按照相交面积占整个像素的的百分比，把颜色按照该比例存放一个目标像素点颜色的数组中
                    //这里计算出来的颜色只是初步颜色，还没到最终结果
                    //loop through the scan area to find where source(x, y) overlaps with the destination pixels
                    for (int xx = mindx - 1; xx <= maxdx; xx++)
                    {
                        if (xx < 0 || xx >= dst.Width)
                            continue;
                        for (int yy = mindy - 1; yy <= maxdy; yy++)
                        {
                            if (yy < 0 || yy >= dst.Height)
                                continue;

                            //offset p and by (xx,yy) and put that into poffset
                            for (int i = 0; i < 4; i++)
                            {
                                poffset[i].x = p[i].x - xx;
                                poffset[i].y = p[i].y - yy;
                            }

                            //FIND THE OVERLAP *a whole lot of code pays off here*
                            //这里则是计算出覆盖了面积占当前像素的百分比
                            double dbloverlap = PixOverlap(poffset);
                            //按照百分比来为目标像素点累加颜色
                            //因为一个目标像素点有可能有几个原来像素的覆盖了
                            if (dbloverlap > 0)
                            {
                                int dstindex = xx + yy * outwidth;
                                int srcWidth = src.Width;
                                Color srcColor;
                                if (SrcIndex == 0)
                                    srcColor = src.GetPixel(0, 0);
                                else
                                    srcColor = src.GetPixel(SrcIndex % src.Width, SrcIndex / src.Width);
                                //Add the rgb and alpha values in proportion to the overlap area
                                dbldstdib[dstindex].Red += (double)((srcColor.R) * dbloverlap);
                                dbldstdib[dstindex].Blue += (double)(srcColor.B) * dbloverlap;
                                dbldstdib[dstindex].Green += (double)(srcColor.G) * dbloverlap;
                                dbldstdib[dstindex].Alpha += dbloverlap;
                            }
                        }
                    }
                }
                if (callbackfunc != null)
                {
                    //Send the callback message
                    double percentdone = (double)(x + 1) / (double)(src.Width);
                    if (callbackfunc(percentdone))
                    {
                        dbldstdib = null;
                        p = null;
                        poffset = null;
                        return;
                    }
                }
            }

            //Free memory no longer needed


            //Create final destination bits
            RGBQUDA[] dstdib = new RGBQUDA[dst.Width * dst.Height];
            for (int i = 0; i < dstdib.Length; i++)
                dstdib[i] = new RGBQUDA() { R = 0, G = 0, B = 0, A = 1 };

            //这里是实际上真正像素点的颜色，并且填到了目标图片中去
            //Write to dstdib with the information stored in dbldstdib
            for (int x = 0; x < outwidth; x++)
            {
                if (x + outstartx >= dst.Width)
                    continue;
                for (int y = 0; y < outheight; y++)
                {
                    if (y + outstarty >= dst.Height)
                        continue;
                    int offindex = x + y * outwidth;
                    int dstindex = x + outstartx + (y + outstarty) * dst.Width;

                    int dstIndexX = dstindex / dst.Width;
                    int dstIndexY = dstindex % dst.Width;
                    if (dbldstdib[offindex].Alpha > 1)
                    {
                        //handles wrap around for non-convex transformations
                        dstdib[dstindex].R = byterange(dbldstdib[offindex].Red / dbldstdib[offindex].Alpha);
                        dstdib[dstindex].G = byterange(dbldstdib[offindex].Green / dbldstdib[offindex].Alpha);
                        dstdib[dstindex].B = byterange(dbldstdib[offindex].Blue / dbldstdib[offindex].Alpha);
                        dstdib[dstindex].A = byterange(dbldstdib[offindex].Alpha / dbldstdib[offindex].Alpha);
                    }
                    else
                    {
                        //Color dstColor = dst.GetPixel(dstIndexX, dstIndexY);
                        dstdib[dstindex].R = byterange(dbldstdib[offindex].Red + (1 - dbldstdib[offindex].Alpha) * (double)dstdib[dstindex].R);
                        dstdib[dstindex].G = byterange(dbldstdib[offindex].Green + (1 - dbldstdib[offindex].Alpha) * (double)dstdib[dstindex].G);
                        dstdib[dstindex].B = byterange(dbldstdib[offindex].Blue + (1 - dbldstdib[offindex].Alpha) * (double)dstdib[dstindex].B);
                        dstdib[dstindex].A = byterange(dbldstdib[offindex].Alpha + (1 - dbldstdib[offindex].Alpha) * (double)dstdib[dstindex].A);
                    }
                    dst.SetPixel(dstIndexY, dstIndexX, Color.FromArgb((int)(1.0 * dbldstdib[dstindex].Alpha * 255), dstdib[dstindex].R, dstdib[dstindex].G, dstdib[dstindex].B));


                    //dst.SetPixel(dstIndexY, dstIndexX, Color.FromArgb((int)dbldstdib[offindex].Red, (int)dbldstdib[offindex].Green, (int)dbldstdib[offindex].Blue, (int)dbldstdib[offindex].Alpha));
                }
            }

            //:D
            return;
        }

        double PixOverlap(AafPnt[] p)
        {
            polyoverlapsize = 0;
            polysortedsize = 0;

            double minx, maxx, miny, maxy;
            int j;

            double z;

            for (int i = 0; i < 4; i++)
            {
                //Search for source points within the destination quadrolateral
                if (p[i].x >= 0 && p[i].x <= 1 && p[i].y >= 0 && p[i].y <= 1)
                    polyoverlap[polyoverlapsize++] = p[i];

                //Search for destination points within the source quadrolateral
                if (PtinConvexPolygon(p, corners[i]))
                    polyoverlap[polyoverlapsize++] = corners[i];

                //Search for line intersections
                j = ja[i];
                minx = aaf_min(p[i].x, p[j].x);
                miny = aaf_min(p[i].y, p[j].y);
                maxx = aaf_max(p[i].x, p[j].x);
                maxy = aaf_max(p[i].y, p[j].y);

                if (minx < 0.0 && 0.0 < maxx)
                {//Cross left
                    z = p[i].y - p[i].x * (p[i].y - p[j].y) / (p[i].x - p[j].x);
                    if (z >= 0.0 && z <= 1.0)
                    {
                        polyoverlap[polyoverlapsize].x = 0.0;
                        polyoverlap[polyoverlapsize++].y = z;
                    }
                }
                if (minx < 1.0 && 1.0 < maxx)
                {//Cross right
                    z = p[i].y + (1 - p[i].x) * (p[i].y - p[j].y) / (p[i].x - p[j].x);
                    if (z >= 0.0 && z <= 1.0)
                    {
                        polyoverlap[polyoverlapsize].x = 1.0;
                        polyoverlap[polyoverlapsize++].y = z;
                    }
                }
                if (miny < 0.0 && 0.0 < maxy)
                {//Cross bottom
                    z = p[i].x - p[i].y * (p[i].x - p[j].x) / (p[i].y - p[j].y);
                    if (z >= 0.0 && z <= 1.0)
                    {
                        polyoverlap[polyoverlapsize].x = z;
                        polyoverlap[polyoverlapsize++].y = 0.0;
                    }
                }
                if (miny < 1.0 && 1.0 < maxy)
                {//Cross top
                    z = p[i].x + (1 - p[i].y) * (p[i].x - p[j].x) / (p[i].y - p[j].y);
                    if (z >= 0.0 && z <= 1.0)
                    {
                        polyoverlap[polyoverlapsize].x = z;
                        polyoverlap[polyoverlapsize++].y = 1.0;
                    }
                }
            }

            //Sort the points and return the area
            SortPoints();
            return Area();
        }

        private double Area()
        {
            double ret = 0.0;
            //Loop through each triangle with respect to (0, 0) and add the cross multiplication
            for (int i = 0; i + 1 < polysortedsize; i++)
                ret += polysorted[i].x * polysorted[i + 1].y - polysorted[i + 1].x * polysorted[i].y;
            //Take the absolute value over 2
            return AafAbs(ret) / 2.0;
        }

        private void SortPoints()
        {
            //Why even bother?
            if (polyoverlapsize < 3)
                return;

            //polyoverlap is a triangle, points cannot be out of order
            if (polyoverlapsize == 3)
            {
                polysortedsize = polyoverlapsize - 1;
                polysorted[0].x = polyoverlap[1].x - polyoverlap[0].x;
                polysorted[0].y = polyoverlap[1].y - polyoverlap[0].y;
                polysorted[1].x = polyoverlap[2].x - polyoverlap[0].x;
                polysorted[1].y = polyoverlap[2].y - polyoverlap[0].y;
                return;
            }


            aaf_indll root = new aaf_indll();
            root.next = null;

            //begin sorting the points.  Note that the first element is left out and all other elements are offset by it's values
            for (int i = 1; i < polyoverlapsize; i++)
            {
                polyoverlap[i].x = polyoverlap[i].x - polyoverlap[0].x;
                polyoverlap[i].y = polyoverlap[i].y - polyoverlap[0].y;

                aaf_indll node = root;
                //Loop until the point polyoverlap[i] is can be sorted (counter) clockwiswe (I'm not sure which way it's sorted)
                while (true)
                {
                    if (node.next != null)
                    {
                        if (polyoverlap[i].x * polyoverlap[node.next.ind].y - polyoverlap[node.next.ind].x * polyoverlap[i].y < 0)
                        {
                            //Insert point before this element
                            aaf_indll temp = node.next;
                            node.next = new aaf_indll();
                            node.next.ind = i;
                            node.next.next = temp;
                            break;
                        }
                    }
                    else
                    {
                        //Add point to the end of list
                        node.next = new aaf_indll();
                        node.next.ind = i;
                        node.next.next = null;
                        break;
                    }
                    node = node.next;
                }
            }

            //We can leave out the first point because it's offset position is going to be (0, 0)
            polysortedsize = 0;

            aaf_indll node2 = root;
            aaf_indll temp2;

            //Add the sorted points to polysorted and clean up memory
            while (node2 != null)
            {
                temp2 = node2;
                node2 = node2.next;
                if (node2 != null)
                    polysorted[polysortedsize++] = polyoverlap[node2.ind];

            }
        }

        private bool PtinConvexPolygon(AafPnt[] p, AafPnt pt)
        {
            int dir = 0;
            int j;

            //Basically what we are doing is seeing if pt is on the same side of each face of the polygon through cross multiplication
            for (int i = 0; i < 4; i++)
            {
                j = ja[i];
                double cross = (p[i].x - pt.x) * (p[j].y - pt.y) - (p[j].x - pt.x) * (p[i].y - pt.y);

                if (cross == 0)
                    continue;

                if (cross > 0)
                {
                    if (dir == -1)
                        return false;

                    dir = 1;
                }
                else
                {
                    if (dir == 1)
                        return false;

                    dir = -1;
                }
            }
            return true;
        }

        int roundup(double a) { if (AafAbs(a - round(a)) < 1e-9) return round(a); else if ((int)a > a) return (int)a; else return (int)a + 1; }
        int rounddown(double a) { if (AafAbs(a - round(a)) < 1e-9) return round(a); else if ((int)a < a) return (int)a; else return (int)a - 1; }
        int round(double a) { return (int)(a + 0.5); }
        byte byterange(double a) { int b = round(a); if (b <= 0) return 0; else if (b >= 255) return 255; else return (byte)b; }
        double AafAbs(double a) { return (((a) < 0) ? (-(a)) : (a)); }
        double aaf_min(double a, double b) { if (a < b) return a; else return b; }
        double aaf_max(double a, double b) { if (a > b) return a; else return b; }
    }

    class RGBQUDA
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }
    }


}
