using System;
using System.Globalization;
using System.Windows.Data;

namespace Clock.clock.Converters
{
    internal class MinutesOrSecondsToAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double) || targetType != typeof(double))
            {
                return null;
            }

            var valueAsDouble = (double)value;

            return valueAsDouble / 60.0 * 360;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
