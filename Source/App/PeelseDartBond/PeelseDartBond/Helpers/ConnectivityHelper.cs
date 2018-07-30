using System;
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
                throw new ConnectivityException("U bent niet met het internet verbonden. Controleer uw verbinding, mogelijk moet u eerst via uw browser inloggen.");
            }
        }
    }
}
