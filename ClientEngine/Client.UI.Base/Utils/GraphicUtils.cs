using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using Client.UI.Base.Enums;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Client.UI.Base.Utils
{
    public class GraphicUtils
    {
        internal static void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
        {
            Point point = new Point(dropDownRect.Left + (dropDownRect.Width / 2), dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { new Point(point.X + 2, point.Y - 3), new Point(point.X + 2, point.Y + 3), new Point(point.X - 1, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { new Point(point.X - 3, point.Y + 2), new Point(point.X + 3, point.Y + 2), new Point(point.X, point.Y - 2) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] { new Point(point.X - 2, point.Y - 3), new Point(point.X - 2, point.Y + 3), new Point(point.X + 1, point.Y) };
                    break;

                default:
                    points = new Point[] { new Point(point.X - 3, point.Y - 1), new Point(point.X + 3, point.Y - 1), new Point(point.X, point.Y + 2) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, bool drawBorder, bool drawGlass, LinearGradientMode mode)
        {
            RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, style, 8, drawBorder, drawGlass, mode);
        }

        internal static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, bool drawBorder, bool drawGlass, LinearGradientMode mode)
        {
            RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, style, roundWidth, 0.45f, drawBorder, drawGlass, mode);
        }

        public static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, float basePosition, bool drawBorder, bool drawGlass, LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colorArray = new Color[] { ColorUtils.GetLightColor(baseColor, 0, 0x23, 0x18, 9), ColorUtils.GetLightColor(baseColor, 0, 13, 8, 3), baseColor, ColorUtils.GetLightColor(baseColor, 0, 0x23, 0x18, 9) };
                ColorBlend blend = new ColorBlend();
                float[] numArray = new float[4];
                numArray[1] = basePosition;
                numArray[2] = basePosition + 0.05f;
                numArray[3] = 1f;
                blend.Positions = numArray;
                blend.Colors = colorArray;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path = CreatePath(rect, roundWidth, style, false))
                    {
                        g.FillPath(brush, path);
                    }
                    if (drawGlass)
                    {
                        if (baseColor.A > 80)
                        {
                            Rectangle rectangle = rect;
                            if (mode == LinearGradientMode.Vertical)
                            {
                                rectangle.Height = (int)(rectangle.Height * basePosition);
                            }
                            else
                            {
                                rectangle.Width = (int)(rect.Width * basePosition);
                            }
                            using (GraphicsPath path2 = CreatePath(rectangle, roundWidth, RoundStyle.Top, false))
                            {
                                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0xff)))
                                {
                                    g.FillPath(brush2, path2);
                                }
                            }
                        }
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + (rect.Height * basePosition);
                            glassRect.Height = (rect.Height - (rect.Height * basePosition)) * 2f;
                        }
                        else
                        {
                            glassRect.X = rect.X + (rect.Width * basePosition);
                            glassRect.Width = (rect.Width - (rect.Width * basePosition)) * 2f;
                        }
                        DrawGlass(g, glassRect, Color.White, 170, 0);
                    }
                    if (!drawBorder)
                    {
                        return;
                    }
                    using (GraphicsPath path3 = CreatePath(rect, roundWidth, style, false))
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawPath(pen, path3);
                        }
                    }
                    rect.Inflate(-1, -1);
                    using (GraphicsPath path4 = CreatePath(rect, roundWidth, style, false))
                    {
                        using (Pen pen2 = new Pen(innerBorderColor))
                        {
                            g.DrawPath(pen2, path4);
                        }
                        return;
                    }
                }
                g.FillRectangle(brush, rect);
                if (drawGlass)
                {
                    if (baseColor.A > 80)
                    {
                        Rectangle rectangle2 = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectangle2.Height = (int)(rectangle2.Height * basePosition);
                        }
                        else
                        {
                            rectangle2.Width = (int)(rect.Width * basePosition);
                        }
                        using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0xff)))
                        {
                            g.FillRectangle(brush3, rectangle2);
                        }
                    }
                    RectangleF ef2 = rect;
                    if (mode == LinearGradientMode.Vertical)
                    {
                        ef2.Y = rect.Y + (rect.Height * basePosition);
                        ef2.Height = (rect.Height - (rect.Height * basePosition)) * 2f;
                    }
                    else
                    {
                        ef2.X = rect.X + (rect.Width * basePosition);
                        ef2.Width = (rect.Width - (rect.Width * basePosition)) * 2f;
                    }
                    DrawGlass(g, ef2, Color.White, 200, 0);
                }
                if (drawBorder)
                {
                    using (Pen pen3 = new Pen(borderColor))
                    {
                        g.DrawRectangle(pen3, rect);
                    }
                    rect.Inflate(-1, -1);
                    using (Pen pen4 = new Pen(innerBorderColor))
                    {
                        g.DrawRectangle(pen4, rect);
                    }
                }
            }
        }

        public static void DrawCheckedFlag(Graphics g, Rectangle rect, Color color)
        {
            PointF[] points = new PointF[] { new PointF(rect.X + (((float)rect.Width) / 4.5f), rect.Y + (((float)rect.Height) / 2.5f)), new PointF(rect.X + (((float)rect.Width) / 2.5f), rect.Bottom - (((float)rect.Height) / 3f)), new PointF(rect.Right - (((float)rect.Width) / 4f), rect.Y + (((float)rect.Height) / 4.5f)) };
            using (Pen pen = new Pen(color, 2f))
            {
                g.DrawLines(pen, points);
            }
        }

        public static void DrawGlass(Graphics g, RectangleF glassRect, Color glassColor, int alphaCenter, int alphaSurround)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glassRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
                    brush.SurroundColors = new Color[] { Color.FromArgb(alphaSurround, glassColor) };
                    brush.CenterPoint = new PointF(glassRect.X + (glassRect.Width / 2f), glassRect.Y + (glassRect.Height / 2f));
                    g.FillPath(brush, path);
                }
            }
        }

        public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect)
        {
            DrawBackgroundImage(g, backgroundImage, backColor, backgroundImageLayout, bounds, clipRect, Point.Empty, RightToLeft.No);
        }

        public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset)
        {
            DrawBackgroundImage(g, backgroundImage, backColor, backgroundImageLayout, bounds, clipRect, scrollOffset, RightToLeft.No);
        }

        public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset, RightToLeft rightToLeft)
        {
            if (g == null)
            {
                throw new ArgumentNullException("g");
            }
            if (backgroundImageLayout == ImageLayout.Tile)
            {
                using (TextureBrush brush = new TextureBrush(backgroundImage, WrapMode.Tile))
                {
                    if (scrollOffset != Point.Empty)
                    {
                        Matrix transform = brush.Transform;
                        transform.Translate((float)scrollOffset.X, (float)scrollOffset.Y);
                        brush.Transform = transform;
                    }
                    g.FillRectangle(brush, clipRect);
                    return;
                }
            }
            Rectangle rect = CalculateBackgroundImageRectangle(bounds, backgroundImage, backgroundImageLayout);
            if ((rightToLeft == RightToLeft.Yes) && (backgroundImageLayout == ImageLayout.None))
            {
                rect.X += clipRect.Width - rect.Width;
            }
            using (SolidBrush brush2 = new SolidBrush(backColor))
            {
                g.FillRectangle(brush2, clipRect);
            }
            if (!clipRect.Contains(rect))
            {
                if ((backgroundImageLayout == ImageLayout.Stretch) || (backgroundImageLayout == ImageLayout.Zoom))
                {
                    rect.Intersect(clipRect);
                    g.DrawImage(backgroundImage, rect);
                }
                else if (backgroundImageLayout == ImageLayout.None)
                {
                    rect.Offset(clipRect.Location);
                    Rectangle destRect = rect;
                    destRect.Intersect(clipRect);
                    Rectangle rectangle3 = new Rectangle(Point.Empty, destRect.Size);
                    g.DrawImage(backgroundImage, destRect, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle rectangle4 = rect;
                    rectangle4.Intersect(clipRect);
                    Rectangle rectangle5 = new Rectangle(new Point(rectangle4.X - rect.X, rectangle4.Y - rect.Y), rectangle4.Size);
                    g.DrawImage(backgroundImage, rectangle4, rectangle5.X, rectangle5.Y, rectangle5.Width, rectangle5.Height, GraphicsUnit.Pixel);
                }
            }
            else
            {
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                g.DrawImage(backgroundImage, rect, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttr);
                imageAttr.Dispose();
            }
        }

        internal static Rectangle CalculateBackgroundImageRectangle(Rectangle bounds, Image backgroundImage, ImageLayout imageLayout)
        {
            Rectangle rectangle = bounds;
            if (backgroundImage != null)
            {
                switch (imageLayout)
                {
                    case ImageLayout.None:
                        rectangle.Size = backgroundImage.Size;
                        return rectangle;

                    case ImageLayout.Tile:
                        return rectangle;

                    case ImageLayout.Center:
                        {
                            rectangle.Size = backgroundImage.Size;
                            Size size = bounds.Size;
                            if (size.Width > rectangle.Width)
                            {
                                rectangle.X = (size.Width - rectangle.Width) / 2;
                            }
                            if (size.Height > rectangle.Height)
                            {
                                rectangle.Y = (size.Height - rectangle.Height) / 2;
                            }
                            return rectangle;
                        }
                    case ImageLayout.Stretch:
                        rectangle.Size = bounds.Size;
                        return rectangle;

                    case ImageLayout.Zoom:
                        {
                            Size size2 = backgroundImage.Size;
                            float num = ((float)bounds.Width) / ((float)size2.Width);
                            float num2 = ((float)bounds.Height) / ((float)size2.Height);
                            if (num >= num2)
                            {
                                rectangle.Height = bounds.Height;
                                rectangle.Width = (int)((size2.Width * num2) + 0.5);
                                if (bounds.X >= 0)
                                {
                                    rectangle.X = (bounds.Width - rectangle.Width) / 2;
                                }
                                return rectangle;
                            }
                            rectangle.Width = bounds.Width;
                            rectangle.Height = (int)((size2.Height * num) + 0.5);
                            if (bounds.Y >= 0)
                            {
                                rectangle.Y = (bounds.Height - rectangle.Height) / 2;
                            }
                            return rectangle;
                        }
                }
            }
            return rectangle;
        }

        public static GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int num = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;

                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    break;

                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    break;

                case RoundStyle.Right:
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
                    break;

                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
                    path.AddArc((rect.Right - radius) - num, rect.Y, radius, radius, 270f, 90f);
                    path.AddLine(rect.Right - num, rect.Bottom - num, rect.X, rect.Bottom - num);
                    break;

                case RoundStyle.Bottom:
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    path.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
                    break;

                case RoundStyle.BottomLeft:
                    path.AddArc(rect.X, (rect.Bottom - radius) - num, radius, radius, 90f, 90f);
                    path.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
                    path.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
                    break;

                case RoundStyle.BottomRight:
                    path.AddArc((rect.Right - radius) - num, (rect.Bottom - radius) - num, radius, radius, 0f, 90f);
                    path.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
                    path.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        public static void CreateRegion(Control control, Rectangle bounds, int radius, RoundStyle roundStyle)
        {
            using (GraphicsPath path = CreatePath(bounds, radius, roundStyle, true))
            {
                Region region = new Region(path);
                path.Widen(Pens.White);
                region.Union(path);
                control.Region = region;
            }
        }

        public static void DrawRect(Graphics g, Bitmap img, Rectangle r, int index, int Totalindex)
        {
            if (img != null)
            {
                int width = img.Width / Totalindex;
                int height = img.Height;
                int x = (index - 1) * width;
                int y = 0;
                int left = r.Left;
                int top = r.Top;
                Rectangle srcRect = new Rectangle(x, y, width, height);
                Rectangle destRect = new Rectangle(left, top, r.Width, r.Height);
                g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }

        public static void DrawRect(Graphics g, Bitmap img, Rectangle r, Rectangle lr, int index, int Totalindex)
        {
            if (img != null)
            {
                Rectangle rectangle;
                Rectangle rectangle2;
                int x = ((index - 1) * img.Width) / Totalindex;
                int y = 0;
                int left = r.Left;
                int top = r.Top;
                if ((r.Height > img.Height) && (r.Width <= (img.Width / Totalindex)))
                {
                    rectangle = new Rectangle(x, y, img.Width / Totalindex, lr.Top);
                    rectangle2 = new Rectangle(left, top, r.Width, lr.Top);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x, y + lr.Top, img.Width / Totalindex, (img.Height - lr.Top) - lr.Bottom);
                    rectangle2 = new Rectangle(left, top + lr.Top, r.Width, (r.Height - lr.Top) - lr.Bottom);
                    if ((lr.Top + lr.Bottom) == 0)
                    {
                        rectangle.Height--;
                    }
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x, (y + img.Height) - lr.Bottom, img.Width / Totalindex, lr.Bottom);
                    rectangle2 = new Rectangle(left, (top + r.Height) - lr.Bottom, r.Width, lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                }
                else if ((r.Height <= img.Height) && (r.Width > (img.Width / Totalindex)))
                {
                    rectangle = new Rectangle(x, y, lr.Left, img.Height);
                    rectangle2 = new Rectangle(left, top, lr.Left, r.Height);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x + lr.Left, y, ((img.Width / Totalindex) - lr.Left) - lr.Right, img.Height);
                    rectangle2 = new Rectangle(left + lr.Left, top, (r.Width - lr.Left) - lr.Right, r.Height);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle((x + (img.Width / Totalindex)) - lr.Right, y, lr.Right, img.Height);
                    rectangle2 = new Rectangle((left + r.Width) - lr.Right, top, lr.Right, r.Height);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                }
                else if ((r.Height <= img.Height) && (r.Width <= (img.Width / Totalindex)))
                {
                    rectangle = new Rectangle(((index - 1) * img.Width) / Totalindex, 0, img.Width / Totalindex, img.Height - 1);
                    g.DrawImage(img, new Rectangle(left, top, r.Width, r.Height), rectangle, GraphicsUnit.Pixel);
                }
                else if ((r.Height > img.Height) && (r.Width > (img.Width / Totalindex)))
                {
                    rectangle = new Rectangle(x, y, lr.Left, lr.Top);
                    rectangle2 = new Rectangle(left, top, lr.Left, lr.Top);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x, (y + img.Height) - lr.Bottom, lr.Left, lr.Bottom);
                    rectangle2 = new Rectangle(left, (top + r.Height) - lr.Bottom, lr.Left, lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x, y + lr.Top, lr.Left, (img.Height - lr.Top) - lr.Bottom);
                    rectangle2 = new Rectangle(left, top + lr.Top, lr.Left, (r.Height - lr.Top) - lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x + lr.Left, y, ((img.Width / Totalindex) - lr.Left) - lr.Right, lr.Top);
                    rectangle2 = new Rectangle(left + lr.Left, top, (r.Width - lr.Left) - lr.Right, lr.Top);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle((x + (img.Width / Totalindex)) - lr.Right, y, lr.Right, lr.Top);
                    rectangle2 = new Rectangle((left + r.Width) - lr.Right, top, lr.Right, lr.Top);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle((x + (img.Width / Totalindex)) - lr.Right, y + lr.Top, lr.Right, (img.Height - lr.Top) - lr.Bottom);
                    rectangle2 = new Rectangle((left + r.Width) - lr.Right, top + lr.Top, lr.Right, (r.Height - lr.Top) - lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle((x + (img.Width / Totalindex)) - lr.Right, (y + img.Height) - lr.Bottom, lr.Right, lr.Bottom);
                    rectangle2 = new Rectangle((left + r.Width) - lr.Right, (top + r.Height) - lr.Bottom, lr.Right, lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x + lr.Left, (y + img.Height) - lr.Bottom, ((img.Width / Totalindex) - lr.Left) - lr.Right, lr.Bottom);
                    rectangle2 = new Rectangle(left + lr.Left, (top + r.Height) - lr.Bottom, (r.Width - lr.Left) - lr.Right, lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                    rectangle = new Rectangle(x + lr.Left, y + lr.Top, ((img.Width / Totalindex) - lr.Left) - lr.Right, (img.Height - lr.Top) - lr.Bottom);
                    rectangle2 = new Rectangle(left + lr.Left, top + lr.Top, (r.Width - lr.Left) - lr.Right, (r.Height - lr.Top) - lr.Bottom);
                    g.DrawImage(img, rectangle2, rectangle, GraphicsUnit.Pixel);
                }
            }
        }


    }
}
