using System;
using System.Globalization;
using System.Windows.Data;

namespace Clock.clock.Converters
{
    internal class TruncateFractionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double) || targetType != typeof(string))
            {
                return null;
            }

            var valueAsDouble = (double)value;

            return Math.Truncate(valueAsDouble).ToString("00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
