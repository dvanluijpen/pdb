using System;
using PeelseDartBond.Constants;
using PeelseDartBond.Model.Exceptions;
using Xamarin.Essentials;

namespace PeelseDartBond.Helpers
{
    public static class ConnectivityHelper
    {
        public static void CheckForInternetAccess()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                throw new ConnectivityException(Strings.ConnectionErrorText);
            }
        }
    }
}
