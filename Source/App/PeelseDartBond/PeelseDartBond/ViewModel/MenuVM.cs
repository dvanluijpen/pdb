using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Constants;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class MenuVM : BaseRefreshViewModel
    {
        List<Competition> _competitions;

        public MenuVM() : base()
        {
            _competitions = new List<Competition> { new Competition { Name = "Bezig met laden..." } };

            Task.Run(async () => await Load());

            PdbService.CompetitionsLoaded += CompetitionsLoaded;
        }

        public List<Competition> Competitions
        {
            get { return _competitions; }
            set { SetProperty(ref _competitions, value); }
        }

        void CompetitionsLoaded(object sender, EventArgs e) => AssembleMenu();

        public async override Task Load()
        {
            if (PdbService.Competitions.IsNullOrEmpty())
                await PdbService.GetCompetitions();
            else
                AssembleMenu();
        }

        public void ChangeSelection(Competition competition)
        {
            if (string.IsNullOrEmpty(competition.Rankings))
                return;
            
            PdbService.SelectedCompetition = competition;
        }

        private void AssembleMenu()
        {
            var competitions = new List<Competition> { new Competition { Name = Strings.News } };
            competitions.AddRange(PdbService.Competitions);
            Competitions = competitions;
        }
    }
}
