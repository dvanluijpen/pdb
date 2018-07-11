using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class PlayerRankingsPage : ContentPage
    {
        PlayerRankingsVM _vm;

        public PlayerRankingsPage()
        {
            InitializeComponent();

            _vm = new PlayerRankingsVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PlayerRanking;
            if (item != null)
            {
                //_vm.ChangeSelection(item);
                //listView.SelectedItem = null;
            }
        }
    }
}
