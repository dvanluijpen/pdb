using System;
using System.Collections.Generic;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class MenuContainerPage : NavigationPage
    {
        MenuContainerVM _vm;

        public MenuContainerPage()
        {
            InitializeComponent();

            _vm = new MenuContainerVM();
            BindingContext = _vm;
        }
    }
}
