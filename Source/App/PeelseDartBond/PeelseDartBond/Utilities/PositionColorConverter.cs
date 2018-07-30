using System;
using System.Globalization;
using PeelseDartBond.Constants;
using Xamarin.Forms;

namespace PeelseDartBond.Utilities
{
    public class PositionColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 1)
                return Colors.Position1;
            if ((int)value == 2)
                return Colors.Position2;
            if ((int)value == 3)
                return Colors.Position3;
            
            return Colors.PositionX;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
