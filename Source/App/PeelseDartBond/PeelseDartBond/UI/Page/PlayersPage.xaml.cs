using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.Types;
using PeelseDartBond.UI.Cell;
using PeelseDartBond.Utilities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class PlayersPage : ContentPage
    {
        PlayersVM _vm;

        public PlayersPage()
        {
            InitializeComponent();

            _vm = new PlayersVM();
            BindingContext = _vm;

            segControl.ValueChanged += DisplayChanged;
        }

        protected override async void OnAppearing()
        {
            await _vm.Load();
            DisplayChanged(null, null);
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var player = e.SelectedItem as BasePlayer;
            _vm.GoToPlayerCommand.Execute(player);

            listView.SelectedItem = null;
        }

        public void DisplayChanged(object o, EventArgs e)
        {
            if (segControl.SelectedSegment == 0)
            {
                _vm.UpdatePage(IndividualPageType.Display180s);
                listView.ItemsSource = _vm.FilteredPlayer180s;
            }
            else if (segControl.SelectedSegment == 1)
            {
                _vm.UpdatePage(IndividualPageType.DisplayFinishes);
                listView.ItemsSource = _vm.FilteredPlayerFinishes;
            }
            else
            {
                _vm.UpdatePage(IndividualPageType.DisplaySingles);
                listView.ItemsSource = _vm.FilteredPlayerRankings;
            }
        }

        void FilterByTeam(object sender, System.EventArgs e)
        {
            _vm.FilterByTeamCommand.Execute(pickerTeam.SelectedItem);
        }
    }
}
