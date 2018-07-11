using System;
using System.Collections.Generic;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class DivisionPage : TabbedPage
    {
		DivisionVM _vm;

        public DivisionPage()
        {
            InitializeComponent();

			_vm = new DivisionVM();
			BindingContext = _vm;
        }
    }
}
