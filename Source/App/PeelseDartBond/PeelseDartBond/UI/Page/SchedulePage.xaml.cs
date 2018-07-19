using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class SchedulePage : ContentPage
    {
        ScheduleVM _vm;

        public SchedulePage()
        {
            InitializeComponent();

            _vm = new ScheduleVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Schedule;
            if (item != null)
            {
                //_vm.ChangeSelection(item);
                listView.SelectedItem = null;
            }
        }
    }
}
