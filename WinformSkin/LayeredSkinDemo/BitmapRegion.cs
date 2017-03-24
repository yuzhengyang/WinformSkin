using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredSkinDemo
{
    class BitmapRegion
    {
        public BitmapRegion()
        { }


        /// <summary> 
        /// Create and apply the region on the supplied control
        /// 创建支持位图区域的控件（目前有button和form）
        /// </summary> 
        /// <param name="control">The Control object to apply the region to控件</param> 
        /// <param name="bitmap">The Bitmap object to create the region from位图</param> 
        public static void CreateControlRegion(Control control, Bitmap bitmap)
        {
            // Return if control and bitmap are null
            //判断是否存在控件和位图
            if (control == null || bitmap == null)
                return;

            // Set our control''s size to be the same as the bitmap
            //设置控件大小为位图大小
            control.Width = bitmap.Width;
            control.Height = bitmap.Height;
            // Check if we are dealing with Form here 
            //当控件是form时
            if (control is System.Windows.Forms.Form)
            {
                // Cast to a Form object
                //强制转换为FORM
                Form form = (Form)control;
                // Set our form''s size to be a little larger that the  bitmap just 
                // in case the form''s border style is not set to none in the first place 
                //当FORM的边界FormBorderStyle不为NONE时，应将FORM的大小设置成比位图大小稍大一点
                form.Width = control.Width;
                form.Height = control.Height;
                // No border 
                //没有边界
                form.FormBorderStyle = FormBorderStyle.None;
                // Set bitmap as the background image 
                //将位图设置成窗体背景图片
                form.BackgroundImage = bitmap;
                // Calculate the graphics path based on the bitmap supplied 
                //计算位图中不透明部分的边界
                GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);
                // Apply new region 
                //应用新的区域
                form.Region = new Region(graphicsPath);
            }
            // Check if we are dealing with Button here 
            //当控件是button时
            else if (control is System.Windows.Forms.Button)
            {
                // Cast to a button object 
                //强制转换为 button
                Button button = (Button)control;
                // Do not show button text 
                //不显示button text
                button.Text = "";

                // Change cursor to hand when over button 
                //改变 cursor的style
                button.Cursor = Cursors.Hand;
                // Set background image of button 
                //设置button的背景图片
                button.BackgroundImage = bitmap;

                // Calculate the graphics path based on the bitmap supplied 
                //计算位图中不透明部分的边界
                GraphicsPath graphicsPath = CalculateControlGraphicsPath(bitmap);
                // Apply new region 
                //应用新的区域
                button.Region = new Region(graphicsPath);
            }
        }
        /// <summary> 
        /// Calculate the graphics path that representing the figure in the bitmap 
        /// excluding the transparent color which is the top left pixel. 
        /// //计算位图中不透明部分的边界
        /// </summary> 
        /// <param name="bitmap">The Bitmap object to calculate our graphics path from</param> 
        /// <returns>Calculated graphics path</returns> 
        private static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap)
        {
            // Create GraphicsPath for our bitmap calculation 
            //创建 GraphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();
            // Use the top left pixel as our transparent color 
            //使用左上角的一点的颜色作为我们透明色
            Color colorTransparent = bitmap.GetPixel(0, 0);
            // This is to store the column value where an opaque pixel is first found. 
            // This value will determine where we start scanning for trailing opaque pixels.
            //第一个找到点的X
            int colOpaquePixel = 0;
            // Go through all rows (Y axis) 
            // 偏历所有行（Y方向）
            for (int row = 0; row < bitmap.Height; row++)
            {
                // Reset value 
                //重设
                colOpaquePixel = 0;
                // Go through all columns (X axis) 
                //偏历所有列（X方向）
                for (int col = 0; col < bitmap.Width; col++)
                {
                    // If this is an opaque pixel, mark it and search for anymore trailing behind 
                    //如果是不需要透明处理的点则标记，然后继续偏历
                    if (bitmap.GetPixel(col, row) != colorTransparent)
                    {
                        // Opaque pixel found, mark current position
                        //记录当前
                        colOpaquePixel = col;
                        // Create another variable to set the current pixel position 
                        //建立新变量来记录当前点
                        int colNext = col;
                        // Starting from current found opaque pixel, search for anymore opaque pixels 
                        // trailing behind, until a transparent   pixel is found or minimum width is reached 
                        ///从找到的不透明点开始，继续寻找不透明点,一直到找到或则达到图片宽度 
                        for (colNext = colOpaquePixel; colNext < bitmap.Width; colNext++)
                            if (bitmap.GetPixel(colNext, row) == colorTransparent)
                                break;
                        // Form a rectangle for line of opaque   pixels found and add it to our graphics path 
                        //将不透明点加到graphics path
                        graphicsPath.AddRectangle(new Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1));
                        // No need to scan the line of opaque pixels just found 
                        col = colNext;
                    }
                }
            }
            // Return calculated graphics path 
            return graphicsPath;
        }
    }
}
