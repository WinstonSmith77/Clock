using System;
using System.Globalization;
using System.Windows.Data;

namespace Uhr.clock.Converters
{
    internal class HoursToAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double) || targetType != typeof(double))
            {
                return null;
            }

            var valueAsDouble = (double)value;

            return valueAsDouble / 12.0 *  360;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
