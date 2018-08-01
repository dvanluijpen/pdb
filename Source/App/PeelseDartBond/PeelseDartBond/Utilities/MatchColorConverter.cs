using System;
using System.Globalization;
using PeelseDartBond.Constants;
using Xamarin.Forms;

namespace PeelseDartBond.Utilities
{
    public class MatchColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var match = (int)value;
            var isHomeTeam = bool.Parse(parameter.ToString());

            if (match == 0)
                return Colors.TeamDrawFill;

            if (match == 1)
                return isHomeTeam ? Colors.TeamWinFill : Colors.TeamLoseFill; 

            if (match == 2)
                return isHomeTeam ? Colors.TeamLoseFill : Colors.TeamWinFill; 
            
            return Colors.Gray1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
