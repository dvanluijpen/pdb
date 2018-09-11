using System;
namespace PeelseDartBond.Utilities
{
    public static class StringExtensions
    {
        private static char _space = ' '; 

        public static int GetResultHomeTeam(this string result)
        {
            var spaceIndex = result.IndexOf(_space);
            var startIndex = 0;
            var length = spaceIndex;
            var numberAsString = result.Substring(startIndex, length);

            bool isNumber = int.TryParse(numberAsString, out int resultHomeTeam);
            return isNumber ? resultHomeTeam : 0;
        }

        public static int GetResultAwayTeam(this string result)
        {
            var spaceIndex = result.LastIndexOf(_space);
            var startIndex = spaceIndex + 1;
            var length = result.Length - startIndex;
            var numberAsString = result.Substring(startIndex, length);

            bool isNumber = int.TryParse(numberAsString, out int resultAwayTeam);
            return isNumber ? resultAwayTeam : 0;
        }

        public static int ToInt(this string score)
        {
            if(int.TryParse(score, out int result))
                return result;

            return 0;
        }
    }
}
