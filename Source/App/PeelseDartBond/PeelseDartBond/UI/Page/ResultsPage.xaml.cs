using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class ResultsPage : ContentPage
    {
        ResultsVM _vm;

        public ResultsPage()
        {
            InitializeComponent();

            _vm = new ResultsVM();
            BindingContext = _vm;
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as WeekResult;
            if (item != null)
            {
                _vm.GoToResultCommand.Execute(item.MatchUrl);
                listView.SelectedItem = null;
            }
        }

        void FilterByTeam(object sender, System.EventArgs e)
        {
            _vm.FilterByTeamCommand.Execute(pickerTeam.SelectedItem);
        }

        void FilterByWeek(object sender, System.EventArgs e)
        {
            _vm.FilterByWeekCommand.Execute(pickerWeek.SelectedItem);
        }
    }
}
