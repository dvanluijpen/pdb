using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class YearPage : ContentPage
    {
        YearVM _vm;

        public YearPage()
        {
            InitializeComponent();

            _vm = new YearVM();
            BindingContext = _vm;
        }

        public YearVM ViewModel { get { return _vm; } }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as CompetitionYear;
            if (item != null)
            {
                _vm.SelectCommand.Execute(item);
                listView.SelectedItem = null;
            }
        }
    }
}
