using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class PlayerFinishesPage : ContentPage
    {
        PlayerFinishesVM _vm;

        public PlayerFinishesPage()
        {
            InitializeComponent();

            _vm = new PlayerFinishesVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PlayerFinish;
            if (item != null)
            {
                //_vm.ChangeSelection(item);
                listView.SelectedItem = null;
            }
        }
    }
}
