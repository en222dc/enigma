using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Enigma.Converters
{
    class BoolToVisibilityConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as string;
            if (value!=null)
            {                
                if (string.IsNullOrEmpty(v))
                {
                    return Visibility.Hidden;
                }
                else 
                {
                  var booleanValue = (bool)value;
                    if ((bool)value)
                    {
                      return Visibility.Visible;

                    }
                    return Visibility.Hidden;
                }
            }
            else return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
