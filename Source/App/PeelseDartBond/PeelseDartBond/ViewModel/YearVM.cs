using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class YearVM : BaseRefreshViewModel
    {
        ObservableCollection<CompetitionYear> _competitionYears;
        CompetitionYear _selectedCompetitionYear;

        public YearVM() : base()
        {
            _competitionYears = new List<CompetitionYear>().ToObservableCollection();
            SelectedCompetitionYear = PdbService.SelectedCompetitionYear;

            Task.Run(async () => await Load());

            PdbService.CompetitionYearsLoaded += CompetitionYearsLoaded;
        }

        public ICommand CloseCommand { get { return new Command(OnClose); } }
        public ICommand SelectCommand { get { return new Command(competitionYear => OnSelect(competitionYear)); } }

        public event EventHandler<CompetitionYearEventArgs> CompetitionYearChanged;

        public ObservableCollection<CompetitionYear> CompetitionYears
        {
            get { return _competitionYears; }
            set { SetProperty(ref _competitionYears, value); }
        }

        public CompetitionYear SelectedCompetitionYear
        {
            get { return _selectedCompetitionYear; }
            set { if (value != null && value != _selectedCompetitionYear) SetProperty(ref _selectedCompetitionYear, value); }
        }

        private void CompetitionYearsLoaded(object sender, CompetitionYearsEventArgs e) => AssembleYears(e.CompetitionYears);
        private void AssembleYears(List<CompetitionYear> competitionYears) => CompetitionYears = competitionYears.ToObservableCollection();
        private void OnClose() => CompetitionYearChanged?.Invoke(this, null);
        private void OnSelect(object competitionYear) => CompetitionYearChanged?.Invoke(this, new CompetitionYearEventArgs((CompetitionYear)competitionYear));

        public async override Task Load()
        {
            if (PdbService.CompetitionYears.IsNullOrEmpty())
            {
                if (HasInternetAccess())
                    await PdbService.GetCompetitionYearsAsync();
                else
                    await ShowNoConnectionError();
            }
            else
            {
                AssembleYears(PdbService.CompetitionYears);
            }
        }

    }
}
