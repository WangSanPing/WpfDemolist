using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfDemolist.Common
{
    public class decimalConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currencyText = "";
            if (value != null)
            {
                currencyText = ((decimal)value).ToString("C");
            }

            return currencyText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string price = ((decimal)value).ToString(culture);

            decimal result;
            if (Decimal.TryParse(price, NumberStyles.Any, culture, out result))
            {
                return result;
            }

            return value;
        }
    }
}
