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
    public class NewsDetailVM : BaseViewModel
    {
        News _news;

        public NewsDetailVM(News news) : base()
        {
            News = news;
        }

        public News News
        {
            get { return _news; }
            set { SetProperty(ref _news, value); }
        }
    }
}
