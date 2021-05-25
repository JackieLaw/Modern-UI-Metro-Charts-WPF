﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;


namespace Test.WPF4Net
{
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return InternalConvert(value, targetType, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return InternalConvertBack(value, targetType, parameter);
        }


        private object InternalConvert(object value, Type targetType, object parameter)
        {
            try
            {
                var flag = false;
                if (value is bool)
                {
                    flag = (bool)value;
                }
                else if (value is bool?)
                {
                    var nullable = (bool?)value;
                    flag = nullable.GetValueOrDefault();
                }
                if (parameter != null)
                {
                    if (bool.Parse((string)parameter))
                    {
                        flag = !flag;
                    }
                }
                if (flag)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
            }
            return Visibility.Collapsed;
        }

        public object InternalConvertBack(object value, Type targetType, object parameter)
        {
            var back = ((value is Visibility) && (((Visibility)value) == Visibility.Visible));
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    back = !back;
                }
            }
            return back;
        }
    }
}