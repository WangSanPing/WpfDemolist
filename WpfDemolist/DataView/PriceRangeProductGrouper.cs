using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfDemolist.DataView
{
    public class PriceRangeProductGrouper : IValueConverter
    {
        public int GroupInterval { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price < GroupInterval)
            {
                return String.Format(culture, "小于 {0:C}", GroupInterval);
            }
            else
            {
                // 间隔
                int interval = (int)price / GroupInterval;
                int lowerLimit = interval * GroupInterval;
                int upperLimit = (interval + 1) * GroupInterval;
                return String.Format(culture, "{0:C} to {1:C}", lowerLimit, upperLimit);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
