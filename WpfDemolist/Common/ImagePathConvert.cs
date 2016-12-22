using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace WpfDemolist.Common
{
    public class ImagePathConvert : IValueConverter
    {
        private string imageDirectory = Directory.GetCurrentDirectory();

        public string ImageDirectory
        {
            get
            {
                return imageDirectory + "\\Images\\";
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                }

                imageDirectory = value;
            }


        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = Path.Combine(ImageDirectory, (string)value);
            return new BitmapImage(new Uri(imagePath));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
