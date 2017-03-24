using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Client.UI.Base.Utils
{
    public class ImageUtils
    {
        public static Image GetImageIndex(Image original, int width, int height, int index)
        {

            return GetImageByXAxis(original, width, height, -width * index);
        }

        public static Image GetImageByXAxis(Image original, int width, int height, int x_Axis)
        {

            Image targetImage = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(targetImage);
            try
            {
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.DrawImage(original, x_Axis, 0, original.Width, height);
            }
            catch
            {
                return null;
            }
            finally
            {

                graphics.Dispose();
            }
            return targetImage;
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration)
        {
            Bitmap image = null;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(Str, F);
                using (Bitmap bitmap2 = new Bitmap((int)ef.Width, (int)ef.Height))
                {
                    using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                        {
                            using (SolidBrush brush2 = new SolidBrush(ColorFore))
                            {
                                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics2.DrawString(Str, F, brush, (float)0f, (float)0f);
                                image = new Bitmap(bitmap2.Width + BlurConsideration, bitmap2.Height + BlurConsideration);
                                using (Graphics graphics3 = Graphics.FromImage(image))
                                {
                                    graphics3.SmoothingMode = SmoothingMode.HighQuality;
                                    graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                    graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                    for (int i = 0; i <= BlurConsideration; i++)
                                    {
                                        for (int j = 0; j <= BlurConsideration; j++)
                                        {
                                            graphics3.DrawImageUnscaled(bitmap2, i, j);
                                        }
                                    }
                                    graphics3.DrawString(Str, F, brush2, (float)(BlurConsideration / 2), (float)(BlurConsideration / 2));
                                }
                                return image;
                            }
                        }
                    }
                }
            }
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration, Rectangle rc, bool auto)
        {
            Bitmap image = null;
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            format.Trimming = auto ? StringTrimming.EllipsisWord : StringTrimming.None;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(Str, F);
                using (Bitmap bitmap2 = new Bitmap((int)ef.Width, (int)ef.Height))
                {
                    using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                        {
                            using (SolidBrush brush2 = new SolidBrush(ColorFore))
                            {
                                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics2.DrawString(Str, F, brush, rc, format);
                                image = new Bitmap(bitmap2.Width + BlurConsideration, bitmap2.Height + BlurConsideration);
                                using (Graphics graphics3 = Graphics.FromImage(image))
                                {
                                    if (ColorBack != Color.Transparent)
                                    {
                                        graphics3.SmoothingMode = SmoothingMode.HighQuality;
                                        graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                        graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                        for (int i = 0; i <= BlurConsideration; i++)
                                        {
                                            for (int j = 0; j <= BlurConsideration; j++)
                                            {
                                                graphics3.DrawImageUnscaled(bitmap2, i, j);
                                            }
                                        }
                                    }
                                    graphics3.DrawString(Str, F, brush2, new Rectangle(new System.Drawing.Point(Convert.ToInt32((int)(BlurConsideration / 2)), Convert.ToInt32((int)(BlurConsideration / 2))), rc.Size), format);
                                }
                                return image;
                            }
                        }
                    }
                }
            }
        }

    }
}
