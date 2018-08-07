using System;
using System.Collections.Generic;
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
        List<CompetitionYear> _competitionYears;

        public YearVM() : base()
        {
            _competitionYears = new List<CompetitionYear>();

            Task.Run(async () => await Load());

            PdbService.CompetitionYearsLoaded += CompetitionYearsLoaded;
        }

        public ICommand CloseCommand { get { return new Command(OnClose); } }
        public ICommand SelectCommand { get { return new Command(competitionYear => OnSelect(competitionYear)); } }

        public event EventHandler<CompetitionYearEventArgs> CompetitionYearChanged;

        public List<CompetitionYear> CompetitionYears
        {
            get { return _competitionYears; }
            set { SetProperty(ref _competitionYears, value); }
        }

        private void CompetitionYearsLoaded(object sender, CompetitionYearsEventArgs e) => AssembleYears(e.CompetitionYears);
        private void AssembleYears(List<CompetitionYear> competitionYears) => CompetitionYears = competitionYears;
        private void OnClose() => CompetitionYearChanged?.Invoke(this, null);
        private void OnSelect(object competitionYear) => CompetitionYearChanged?.Invoke(this, new CompetitionYearEventArgs((CompetitionYear)competitionYear));

        public async override Task Load()
        {
            if (PdbService.CompetitionYears.IsNullOrEmpty())
            {
                if (HasInternetAccess())
                    await PdbService.GetCompetitionYears();
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
