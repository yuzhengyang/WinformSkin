using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Client.UI.Base.Animations
{
    public static class TransfromHelper
    {
        private const int bytesPerPixel = 4;
        private static Random rnd;

        static TransfromHelper()
        {
            rnd = new Random();
        }

        public static void CalcDifference(Bitmap bmp1, Bitmap bmp2)
        {
            Rectangle rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
            BitmapData bitmapdata = bmp1.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr source = bitmapdata.Scan0;
            BitmapData data2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr ptr2 = data2.Scan0;
            int length = (bmp1.Width * bmp1.Height) * 4;
            byte[] destination = new byte[length];
            byte[] buffer2 = new byte[length];
            Marshal.Copy(source, destination, 0, length);
            Marshal.Copy(ptr2, buffer2, 0, length);
            for (int i = 0; i < length; i += 4)
            {
                if (((destination[i] == buffer2[i]) && (destination[i + 1] == buffer2[i + 1])) && (destination[i + 2] == buffer2[i + 2]))
                {
                    destination[i] = 0xff;
                    destination[i + 1] = 0xff;
                    destination[i + 2] = 0xff;
                    destination[i + 3] = 0;
                }
            }
            Marshal.Copy(destination, 0, source, length);
            bmp1.UnlockBits(bitmapdata);
            bmp2.UnlockBits(data2);
        }

        public static void DoBlind(NonLinearTransfromNeededEventArg e, Animation animation)
        {
            if (animation.BlindCoeff != PointF.Empty)
            {
                byte[] pixels = e.Pixels;
                int width = e.ClientRectangle.Width;
                int height = e.ClientRectangle.Height;
                int stride = e.Stride;
                float x = animation.BlindCoeff.X;
                float y = animation.BlindCoeff.Y;
                int num8 = (int)(((width * x) + (height * y)) * (1f - e.CurrentTime));
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        int num5 = (j * stride) + (i * 4);
                        float num9 = ((i * x) + (j * y)) - num8;
                        if (num9 >= 0f)
                        {
                            pixels[num5 + 3] = 0;
                        }
                    }
                }
            }
        }

        public static void DoBlur(NonLinearTransfromNeededEventArg e, int r)
        {
            byte[] pixels = e.Pixels;
            byte[] sourcePixels = e.SourcePixels;
            int stride = e.Stride;
            int height = e.ClientRectangle.Height;
            int width = e.ClientRectangle.Width;
            int num4 = sourcePixels.Length - 4;
            for (int i = r; i < (width - r); i++)
            {
                for (int j = r; j < (height - r); j++)
                {
                    int index = (j * stride) + (i * 4);
                    int num14 = 0;
                    int num13 = 0;
                    int num11 = 0;
                    int num15 = 0;
                    int num12 = 0;
                    for (int k = i - r; k < (i + r); k++)
                    {
                        for (int m = j - r; m < (j + r); m++)
                        {
                            int num8 = (m * stride) + (k * 4);
                            if (((num8 >= 0) && (num8 < num4)) && (sourcePixels[num8 + 3] > 0))
                            {
                                num11 += sourcePixels[num8];
                                num13 += sourcePixels[num8 + 1];
                                num14 += sourcePixels[num8 + 2];
                                num15 += sourcePixels[num8 + 3];
                                num12++;
                            }
                        }
                    }
                    if ((index < num4) && (num12 > 5))
                    {
                        pixels[index] = (byte)(num11 / num12);
                        pixels[index + 1] = (byte)(num13 / num12);
                        pixels[index + 2] = (byte)(num14 / num12);
                        pixels[index + 3] = (byte)(num15 / num12);
                    }
                }
            }
        }

        public static void DoBottomMirror(NonLinearTransfromNeededEventArg e)
        {
            byte[] sourcePixels = e.SourcePixels;
            byte[] pixels = e.Pixels;
            int stride = e.Stride;
            int num2 = 1;
            int num3 = e.SourceClientRectangle.Bottom + 1;
            int height = e.ClientRectangle.Height;
            int left = e.SourceClientRectangle.Left;
            int right = e.SourceClientRectangle.Right;
            int num7 = height - num3;
            for (int i = left; i < right; i++)
            {
                for (int j = num3; j < height; j++)
                {
                    int num10 = ((num3 - 1) - num2) - (j - num3);
                    if (num10 < 0)
                    {
                        break;
                    }
                    int num11 = i;
                    int index = (num10 * stride) + (num11 * 4);
                    int num13 = (j * stride) + (i * 4);
                    pixels[num13] = sourcePixels[index];
                    pixels[num13 + 1] = sourcePixels[index + 1];
                    pixels[num13 + 2] = sourcePixels[index + 2];
                    pixels[num13 + 3] = (byte)((1f - ((1f * (j - num3)) / ((float)num7))) * 90f);
                }
            }
        }

        public static void DoLeaf(NonLinearTransfromNeededEventArg e, Animation animation)
        {
            if (animation.LeafCoeff != 0f)
            {
                byte[] pixels = e.Pixels;
                int width = e.ClientRectangle.Width;
                int height = e.ClientRectangle.Height;
                int stride = e.Stride;
                int num7 = (int)((width + height) * (1f - (e.CurrentTime * e.CurrentTime)));
                int length = pixels.Length;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        int index = (j * stride) + (i * 4);
                        if ((i + j) >= num7)
                        {
                            int num9 = num7 - j;
                            int num8 = num7 - i;
                            int num2 = (num7 - i) - j;
                            if (num2 < -20)
                            {
                                num2 = -20;
                            }
                            int num = (num8 * stride) + (num9 * 4);
                            if ((((num9 >= 0) && (num8 >= 0)) && ((num >= 0) && (num < length))) && (pixels[index + 3] > 0))
                            {
                                pixels[num] = (byte)Math.Min(0xff, (num2 + 250) + (pixels[index] / 10));
                                pixels[num + 1] = (byte)Math.Min(0xff, (num2 + 250) + (pixels[index + 1] / 10));
                                pixels[num + 2] = (byte)Math.Min(0xff, (num2 + 250) + (pixels[index + 2] / 10));
                                pixels[num + 3] = 230;
                            }
                            pixels[index + 3] = 0;
                        }
                    }
                }
            }
        }

        public static void DoMosaic(NonLinearTransfromNeededEventArg e, Animation animation, ref Point[] buffer, ref byte[] pixelsBuffer)
        {
            if ((animation.MosaicCoeff != PointF.Empty) && (animation.MosaicSize != 0))
            {
                byte[] pixels = e.Pixels;
                int width = e.ClientRectangle.Width;
                int height = e.ClientRectangle.Height;
                int stride = e.Stride;
                float currentTime = e.CurrentTime;
                int length = pixels.Length;
                float num7 = 1f - e.CurrentTime;
                if (num7 < 0f)
                {
                    num7 = 0f;
                }
                if (num7 > 1f)
                {
                    num7 = 1f;
                }
                float x = animation.MosaicCoeff.X;
                float y = animation.MosaicCoeff.Y;
                if (buffer == null)
                {
                    buffer = new Point[pixels.Length];
                    for (int k = 0; k < pixels.Length; k++)
                    {
                        buffer[k] = new Point((int)(x * (rnd.NextDouble() - 0.5)), (int)(y * (rnd.NextDouble() - 0.5)));
                    }
                }
                if (pixelsBuffer == null)
                {
                    pixelsBuffer = (byte[])pixels.Clone();
                }
                for (int i = 0; i < length; i += 4)
                {
                    pixels[i] = 0xff;
                    pixels[i + 1] = 0xff;
                    pixels[i + 2] = 0xff;
                    pixels[i + 3] = 0;
                }
                int mosaicSize = animation.MosaicSize;
                float num16 = animation.MosaicShift.X;
                float num17 = animation.MosaicShift.Y;
                for (int j = 0; j < height; j++)
                {
                    for (int m = 0; m < width; m++)
                    {
                        int num12 = j / mosaicSize;
                        int num13 = m / mosaicSize;
                        int index = (j * stride) + (m * 4);
                        int num14 = (num12 * stride) + (num13 * 4);
                        int num = m + ((int)(currentTime * (buffer[num14].X + (num13 * num16))));
                        int num3 = j + ((int)(currentTime * (buffer[num14].Y + (num12 * num17))));
                        if (((num >= 0) && (num < width)) && ((num3 >= 0) && (num3 < height)))
                        {
                            int num5 = (num3 * stride) + (num * 4);
                            pixels[num5] = pixelsBuffer[index];
                            pixels[num5 + 1] = pixelsBuffer[index + 1];
                            pixels[num5 + 2] = pixelsBuffer[index + 2];
                            pixels[num5 + 3] = (byte)(pixelsBuffer[index + 3] * num7);
                        }
                    }
                }
            }
        }

        public static void DoRotate(TransfromNeededEventArg e, Animation animation)
        {
            Rectangle clientRectangle = e.ClientRectangle;
            PointF tf = new PointF((float)(clientRectangle.Width / 2), (float)(clientRectangle.Height / 2));
            e.Matrix.Translate(tf.X, tf.Y);
            if (e.CurrentTime > animation.RotateLimit)
            {
                e.Matrix.Rotate((360f * (e.CurrentTime - animation.RotateLimit)) * animation.RotateCoeff);
            }
            e.Matrix.Translate(-tf.X, -tf.Y);
        }

        public static void DoScale(TransfromNeededEventArg e, Animation animation)
        {
            Rectangle clientRectangle = e.ClientRectangle;
            PointF tf = new PointF((float)(clientRectangle.Width / 2), (float)(clientRectangle.Height / 2));
            e.Matrix.Translate(tf.X, tf.Y);
            float num = 1f - (animation.ScaleCoeff.X * e.CurrentTime);
            float num2 = 1f - (animation.ScaleCoeff.X * e.CurrentTime);
            if (Math.Abs(num) <= 0.001f)
            {
                num = 0.001f;
            }
            if (Math.Abs(num2) <= 0.001f)
            {
                num2 = 0.001f;
            }
            e.Matrix.Scale(num, num2);
            e.Matrix.Translate(-tf.X, -tf.Y);
        }

        public static void DoSlide(TransfromNeededEventArg e, Animation animation)
        {
            float currentTime = e.CurrentTime;
            e.Matrix.Translate((-e.ClientRectangle.Width * currentTime) * animation.SlideCoeff.X, (-e.ClientRectangle.Height * currentTime) * animation.SlideCoeff.Y);
        }

        public static void DoTransparent(NonLinearTransfromNeededEventArg e, Animation animation)
        {
            if (animation.TransparencyCoeff != 0f)
            {
                float num2 = 1f - (animation.TransparencyCoeff * e.CurrentTime);
                if (num2 < 0f)
                {
                    num2 = 0f;
                }
                if (num2 > 1f)
                {
                    num2 = 1f;
                }
                byte[] pixels = e.Pixels;
                for (int i = 0; i < pixels.Length; i += 4)
                {
                    pixels[i + 3] = (byte)(pixels[i + 3] * num2);
                }
            }
        }
    }
}
