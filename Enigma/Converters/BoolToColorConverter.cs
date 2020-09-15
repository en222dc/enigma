﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Enigma.Converters
{
    class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           

            if ((bool)value)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
              var s = parameter as String;
                if (string.IsNullOrEmpty(s))
                {
                    return new SolidColorBrush(Colors.White);
                }
              else return new SolidColorBrush(Colors.Red);

            }
            
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else return new SolidColorBrush(Colors.Green);

        }
    }
}