using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public abstract class BaseRefreshViewModel : BaseViewModel
    {
        bool _isBusy;
        ICommand _refreshCommand;

        protected BaseRefreshViewModel() : base()
        {
            _refreshCommand = new Command(async () => await OnRefreshing());
        }

        public ICommand RefreshCommand { get { return _refreshCommand; } }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        async Task OnRefreshing()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await Load();
            }
            catch /*(Exception ex)*/
            {
                //Logger.Error("Refreshing went into an error.", ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public abstract Task Load();
    }
}
