using System;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class MenuContainerVM : BaseViewModel
    {
        string _selectedYear = "Competities";

        public MenuContainerVM() : base()
        {
            PdbService.SelectedCompetitionYearChanged += OnCompetitionYearChanged;
        }

        private void OnCompetitionYearChanged(object sender, CompetitionYearEventArgs e) => SelectedYear = e.CompetitionYear.Title;

        public string SelectedYear
        {
            get { return _selectedYear; }
            set { SetProperty(ref _selectedYear, value); }
        }
    }
}
