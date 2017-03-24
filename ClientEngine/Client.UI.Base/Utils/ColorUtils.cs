using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Client.UI.Base.Utils
{
    public class ColorUtils
    {
        /// <summary>
        /// 获取近似颜色（比原色淡）
        /// </summary>
        /// <param name="colorBase"></param>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color GetLightColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            a = (a + a0 > 255) ? 255 : Math.Max(a + a0, 0);
            r = (r + r0 > 255) ? 255 : Math.Max(r + r0, 0);
            g = (g + g0 > 255) ? 255 : Math.Max(g + g0, 0);
            b = (b + b0 > 255) ? 255 : Math.Max(b + b0, 0);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
