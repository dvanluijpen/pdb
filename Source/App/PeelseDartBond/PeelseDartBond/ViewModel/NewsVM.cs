using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Exceptions;
using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class NewsVM : BaseRefreshViewModel
    {
        List<News> _news;

        public NewsVM() : base()
        {
            Task.Run(async () => await Load());
            PdbService.NewsLoaded += NewsLoaded;
        }

        public List<News> News
        {
            get { return _news; }
            set { SetProperty(ref _news, value); }
        }

        void NewsLoaded(object sender, NewsEventArgs e) => News = PdbService.News;

        public async override Task Load()
        {
            //if (PdbService.CompetitionYears.IsNullOrEmpty())
            //    await PdbService.GetCompetitionYearsAsync();

            //if (PdbService.News.IsNullOrEmpty())
            //    await PdbService.GetNewsAsync();
            //else
                //News = PdbService.News;

            try
            {
                Device.BeginInvokeOnMainThread(() =>  DialogService.ShowProgressDialog("Bezig met laden..."));
                if (PdbService.CompetitionYears.IsNullOrEmpty())
                    await PdbService.GetCompetitionYearsAsync();

                if (PdbService.News.IsNullOrEmpty())
                    await PdbService.GetNewsAsync();
                else
                    News = PdbService.News;
            }
            catch (ConnectivityException ex)
            {
                Logger.Error("Connectivity Issue", ex);
                await ShowNoConnectionError();
            }
            catch (Exception ex)
            {
                Logger.Error("Other Exception", ex);
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() => DialogService.HideProgressDialog());
            }
        }

        public async Task GoToDetailPage(News news)
        {
            await NavigationService.GoToPage(new NewsDetailPage(news));
        }
    }
}
