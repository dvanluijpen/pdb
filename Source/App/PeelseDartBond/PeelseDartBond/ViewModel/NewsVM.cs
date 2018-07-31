using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using PeelseDartBond.Utilities;

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
            if (PdbService.News.IsNullOrEmpty())
                await PdbService.GetNews();
            else
                News = PdbService.News;
        }

        public async Task GoToDetailPage(News news)
        {
            await NavigationService.GoToPage(new NewsDetailPage(news));
        }
    }
}
