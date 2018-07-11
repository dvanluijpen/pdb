using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class NewsPage : ContentPage
    {
        NewsVM _vm;

        public NewsPage()
        {
            InitializeComponent();

            _vm = new NewsVM();
            BindingContext = _vm;
        }

        protected async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as News;
            if (item != null)
            {
                await _vm.GoToDetailPage(item);
                listView.SelectedItem = null;
            }
        }
    }
}
