using System;
using System.Globalization;
using PeelseDartBond.Constants;
using Xamarin.Forms;

namespace PeelseDartBond.ValueConverters
{
    public class SelectedRowColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (bool.TryParse((string)parameter, out bool isBackgroundColor))
            {
                // true for backgroundcolor
                if (isBackgroundColor)
                {
                    return (bool)value ? Colors.GreenNormal : Colors.Gray1;
                }

                // false for textcolor
                return (bool)value ? Colors.WhiteNormal : Colors.Gray3;
            }

            return Colors.PointsYellowFill;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
