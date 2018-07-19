using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;

using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class MatrixPage : ContentPage
    {
		MatrixVM _vm;

		public MatrixPage()
        {
            InitializeComponent();

			_vm = new MatrixVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			var item = e.SelectedItem as MatrixRow;
            if (item != null)
            {
                //_vm.ChangeSelection(item);
                listView.SelectedItem = null;
            }
        }
    }
}
