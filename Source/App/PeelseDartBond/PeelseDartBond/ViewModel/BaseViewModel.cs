using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PeelseDartBond.Services;
using PeelseDartBond.Constants;
using Xamarin.Forms;
using Xamarin.Essentials;
using PeelseDartBond.Model.Exceptions;

namespace PeelseDartBond.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        PdbService _pdbService;

        public BaseViewModel()
        {
            _pdbService = PdbService.Instance;
        }

        public NavigationService NavigationService { get { return DependencyService.Get<NavigationService>(); } }
        public PdbService PdbService { get { return _pdbService; } }

        protected async Task ShowNoConnectionError() => await NavigationService.DisplayAlert(Strings.ConnectionErrorTitle, Strings.ConnectionErrorText, Strings.Ok);
        protected async Task ShowServiceErrorAsync() => await NavigationService.DisplayAlert(Strings.ServiceErrorTitle, Strings.ServiceErrorText, Strings.Ok);

        protected bool HasInternetAccess() => Connectivity.NetworkAccess == NetworkAccess.Internet;






        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        //C# 6 null-safe operator. No need to check for event listeners
        //If there are no listeners, this will be a noop
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // C# 5 - CallMemberName means we don't need to pass the property's name
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

        #endregion INotifyPropertyChanged
    }
}
