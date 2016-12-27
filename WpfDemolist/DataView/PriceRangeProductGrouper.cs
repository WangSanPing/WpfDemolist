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
        //static int i = 0;

        /// <summary>
        /// 返回的值中带数字就会当作分组条件
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price < GroupInterval)
            {
                //culture = new CultureInfo("zh-CN");
                return String.Format("小于 {0:C}", GroupInterval);
                //return "40";
            }
            else
            {
                // 间隔
                int interval = (int)price / GroupInterval;
                int lowerLimit = interval * GroupInterval;
                int upperLimit = (interval + 1) * GroupInterval;
                return String.Format("{0:C} to {1:C}", lowerLimit, upperLimit);

                //return String.Format("{0} {1}", "100", "200");
            }
            //if (i++ < 20)
            //    return "40";
            //else if(i ++ < 40)
            //    return "100 200";
            //return "else";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
