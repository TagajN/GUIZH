using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Computer_app.Helper
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tipus = value.ToString();
            if (tipus == "Alaplap")
            {
                return Brushes.Red;
            }
            else if (tipus == "RAM")
            {
                return Brushes.Yellow;
            }
            else if (tipus == "CPU")
            {
                return Brushes.Blue;
            }
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
