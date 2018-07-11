using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class NewsDetailPage : ContentPage
    {
        NewsDetailVM _vm;

        public NewsDetailPage(News news)
        {
            InitializeComponent();

            _vm = new NewsDetailVM(news);
            BindingContext = _vm;
        }
    }
}
