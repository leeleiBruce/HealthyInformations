using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HealthyInfomation.Converter
{
    public class SexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool reuslt = false;
            if (value == null || parameter == null)
            {
                return reuslt;
            }

            if (value.ToString() == parameter.ToString())
            {
                reuslt = true;
            }
            else
            {
                reuslt = false;
            }
            return reuslt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            bool usevalue = (bool)value;
            if (usevalue)
            {
                return parameter.ToString();
            }

            return null;
        }
    }

    public class SexUIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string reuslt = string.Empty;
            if (value == null || parameter == null)
            {
                return reuslt;
            }

            if (value.ToString()=="1")
            {
                reuslt = "男";
            }
            else
            {
                reuslt = "女";
            }
            return reuslt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return null;
            }

            string usevalue = (string)value;

            if (usevalue == "男")
            {
                return "1";
            }
            else
            {
                return "2";
            }
        }
    }
}
