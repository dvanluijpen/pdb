using System;
using System.Globalization;
using PeelseDartBond.Constants;
using PeelseDartBond.Model.Types;
using Xamarin.Forms;

namespace PeelseDartBond.ValueConverters
{
    public class MatchResultColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var matchResult = (MatchResultType)value;
            var isBackgroundColor = bool.Parse(parameter.ToString());

            if (isBackgroundColor)
            {
                return matchResult == MatchResultType.Win
                    ? Colors.TeamWinFill
                    : matchResult == MatchResultType.Lose
                        ? Colors.TeamLoseFill
                        : Colors.TeamDrawFill;
            }

            return matchResult == MatchResultType.Win
                ? Colors.TeamWinBorder
                : matchResult == MatchResultType.Lose
                    ? Colors.TeamLoseBorder
                    : Colors.TeamDrawBorder;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
