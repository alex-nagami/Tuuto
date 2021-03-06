﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Tuuto.Common.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isInverted = false;

            if (parameter is string)
            {
                bool.TryParse(parameter.ToString(), out isInverted);
            }

            var boolValue = (bool)value;

            boolValue = isInverted ? !boolValue : boolValue;

            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var isInverted = false;

            if (parameter is string)
            {
                bool.TryParse(parameter.ToString(), out isInverted);
            }
            var visibility = (Visibility)value;
            return isInverted ? visibility == Visibility.Collapsed : visibility == Visibility.Visible;
        }
    }
}
