using System;
using System.Globalization;
using PeelseDartBond.Constants;
using Xamarin.Forms;

namespace PeelseDartBond.ValueConverters
{
    public class HeaderVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
