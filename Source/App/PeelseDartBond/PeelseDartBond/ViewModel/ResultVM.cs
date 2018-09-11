using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class ResultVM : BaseViewModel
    {
        Result _result;
        string _title;
        string _url;
        Color _homeResultColor;
        Color _awayResultColor;

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

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public Color HomeResultColor
        {
            get { return _homeResultColor; }
            set { SetProperty(ref _homeResultColor, value); }
        }

        public Color AwayResultColor
        {
            get { return _awayResultColor; }
            set { SetProperty(ref _awayResultColor, value); }
        }

        private void OnClose() => CloseRequested?.Invoke(this, null);

        public async Task Load()
        {
            var result = await PdbService.GetResultAsync(Url);
            Result = result;
            Title = $"{result.TeamHome} - {result.TeamAway} ({result.Score})";
            HomeResultColor = result.TeamHomeResult.ToColor();
            AwayResultColor = result.TeamAwayResult.ToColor();
            var ff = "";
        }
    }
}
