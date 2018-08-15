using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class PlayerPage : ContentPage
    {
        PlayerVM _vm;

        public PlayerPage(Player player)
        {
            InitializeComponent();

            _vm = new PlayerVM(player);
            BindingContext = _vm;
        }

        public PlayerVM ViewModel { get { return _vm; }}
    }
}
