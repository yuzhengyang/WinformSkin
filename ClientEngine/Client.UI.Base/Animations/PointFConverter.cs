using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;

namespace Client.UI.Base.Animations
{
    public class PointFConverter : ExpandableObjectConverter
    {
        public PointFConverter()
        {
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            object obj2;
            if (!(value is string))
            {
                return base.ConvertFrom(context, culture, value);
            }
            try
            {
                string[] strArray = ((string)value).Split(new char[] { ',' });
                float x = 0f;
                float y = 0f;
                if (strArray.Length > 1)
                {
                    x = float.Parse(strArray[0].Trim().Trim(new char[] { '{', 'X', 'x', '=' }));
                    y = float.Parse(strArray[1].Trim().Trim(new char[] { '}', 'Y', 'y', '=' }));
                }
                else if (strArray.Length == 1)
                {
                    x = float.Parse(strArray[0].Trim());
                    y = 0f;
                }
                else
                {
                    x = 0f;
                    y = 0f;
                }
                obj2 = new PointF(x, y);
            }
            catch
            {
                throw new ArgumentException("Cannot convert [" + value.ToString() + "] to pointF");
            }
            return obj2;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(string)) && (value.GetType() == typeof(PointF)))
            {
                PointF tf = (PointF)value;
                return string.Format("{{X={0}, Y={1}}}", tf.X, tf.Y);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
