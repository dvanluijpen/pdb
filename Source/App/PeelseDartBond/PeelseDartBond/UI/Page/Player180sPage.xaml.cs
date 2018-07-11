using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class Player180sPage : ContentPage
    {
        Player180sVM _vm;

        public Player180sPage()
        {
            InitializeComponent();

            _vm = new Player180sVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Player180s;
            if (item != null)
            {
                //_vm.ChangeSelection(item);
                listView.SelectedItem = null;
            }
        }
    }
}
