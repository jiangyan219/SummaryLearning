using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Tool.ParamConfig.View
{
    [ValueConversion(typeof(string), typeof(string))]
    public class ColorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //根据文字显示颜色
            //string strValue = value.ToString();
            //if (strValue == "红色警报")
            //{
            //    return "Red";
            //}
            //if (strValue == "注意")
            //{
            //    return "Yellow";
            //}

            //return "White";

            int iRow = int.Parse(value.ToString());
            if (iRow==2)
            {
                return "Red";
            }

            return "White";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return "";
        }
    }
}
