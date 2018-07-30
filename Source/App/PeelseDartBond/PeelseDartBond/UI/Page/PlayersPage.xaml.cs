using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.Types;
using PeelseDartBond.UI.Cell;
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

            InitializeSegment();

            segControl.ValueChanged += DisplayChanged;
        }

        public void InitializeSegment()
        {
            segControl.SelectedSegment = 0;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var item = e.SelectedItem as Ranking;
            //if (item != null)
            //{
            //    //_vm.ChangeSelection(item);
            //    listView.SelectedItem = null;
            //}
            listView.SelectedItem = null;
        }

        public void DisplayChanged(object o, EventArgs e)
        {
            switch (segControl.SelectedSegment)
            {
                case 1:
                    _vm.UpdatePage(IndividualPageType.DisplayFinishes);
                    listView.ItemsSource = _vm.PlayerFinishes;
                    listView.ItemTemplate = new DataTemplate(() =>
                    {
                        var nativeCell = new PlayerFinishesCell();
                        nativeCell.SetBinding(PlayerFinishesCell.PlayerProperty, ".");
                        return nativeCell;
                    });
                    break;
                case 2:
                    _vm.UpdatePage(IndividualPageType.DisplaySingles);
                    listView.ItemsSource = _vm.PlayerRankings;
                    listView.ItemTemplate = new DataTemplate(() =>
                    {
                        var nativeCell = new PlayerRankingsCell();
                        nativeCell.SetBinding(PlayerRankingsCell.PlayerProperty, ".");
                        return nativeCell;
                    });
                    break;
                default:
                case 0:
                    _vm.UpdatePage(IndividualPageType.Display180s);
                    listView.ItemsSource = _vm.Player180s;
                    listView.ItemTemplate = new DataTemplate(() =>
                    {
                        var nativeCell = new Player180sCell();
                        nativeCell.SetBinding(Player180sCell.PlayerProperty, ".");
                        return nativeCell;
                    });
                    break;
            }
        }
    }
}
