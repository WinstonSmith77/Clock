﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Clock.clock.Converters
{
    class IsEvenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double) )
            {
                return null;
            }

            var valueAsDouble = (double)value;

            return Math.Truncate(valueAsDouble)%2 == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
