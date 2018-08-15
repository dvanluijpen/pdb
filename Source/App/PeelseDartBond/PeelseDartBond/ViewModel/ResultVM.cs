using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class ResultVM : BaseViewModel
    {
        Result _result;
        string _url;

        public ResultVM(string url)
        {
            _url = url;

            Task.Run(async () => await Load());
        }

        public ICommand CloseCommand { get { return new Command(OnClose); } }

        public event EventHandler CloseRequested;

        public Result Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        private void OnClose() => CloseRequested?.Invoke(this, null);

        public async Task Load()
        {
            var result = await PdbService.GetResultAsync(Url);
            Result = result;
        }
    }
}
