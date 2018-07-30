
using System;
using System.Globalization;
using PeelseDartBond.Constants;
using Xamarin.Forms;

namespace PeelseDartBond.Utilities
{
    public class StringVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return !(string.IsNullOrEmpty(value.ToString()));
            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
