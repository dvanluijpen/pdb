using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class RankingsPage : ContentPage
    {
        RankingsVM _vm;

        public RankingsPage()
        {
            InitializeComponent();

            _vm = new RankingsVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Ranking;
            if (item != null)
            {
                _vm.GoToTeamCommand.Execute(item);
                listView.SelectedItem = null;
            }
        }
    }
}
