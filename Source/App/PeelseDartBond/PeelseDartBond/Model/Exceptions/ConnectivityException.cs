using System;
namespace PeelseDartBond.Model.Exceptions
{
    public class ConnectivityException : Exception
    {
        public ConnectivityException(string message) : base(message)
        {
        }
    }
}
