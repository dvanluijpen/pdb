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

            _vm = new PlayersVM(this);
            BindingContext = _vm;

            segControl.ValueChanged += DisplayChanged;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (segControl.SelectedSegment == 0)
            {
                var p1 = e.SelectedItem as Player180s;
                if (p1 != null)
                    _vm.GoToPlayerCommand.Execute(new BasePlayer(p1.Name, p1.Team, p1.TeamUrl));
            }
            else if (segControl.SelectedSegment == 1)
            {
                var pf = e.SelectedItem as PlayerFinish;
                if (pf != null)
                    _vm.GoToPlayerCommand.Execute(new BasePlayer(pf.Name, pf.Team, pf.TeamUrl));
            }
            else if(segControl.SelectedSegment == 2)
            {
                var pr = e.SelectedItem as PlayerRanking;
                if (pr != null)
                    _vm.GoToPlayerCommand.Execute(new BasePlayer(pr.Name, pr.Team, pr.TeamUrl));
            }

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
            else if (segControl.SelectedSegment == 2)
            {
                _vm.UpdatePage(IndividualPageType.DisplaySingles);
                listView.ItemsSource = _vm.FilteredPlayerRankings;
            }

            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            if (segControl.SelectedSegment == 0)
            {
                listView.IsVisible = _vm.HasResults;
                controlNoData.IsVisible = !_vm.HasResults;
                controlUnderConstruction.IsVisible = false;
            }
            else if (segControl.SelectedSegment == 1)
            {
                listView.IsVisible = _vm.HasResults;
                controlNoData.IsVisible = !_vm.HasResults;
                controlUnderConstruction.IsVisible = false;
            }
            else if (segControl.SelectedSegment == 2)
            {
                listView.IsVisible = false;
                controlNoData.IsVisible = false;
                controlUnderConstruction.IsVisible = true;
            }
        }

        void FilterByTeam(object sender, System.EventArgs e)
        {
            _vm.FilterByTeamCommand.Execute(pickerTeam.SelectedItem);
        }
    }
}
