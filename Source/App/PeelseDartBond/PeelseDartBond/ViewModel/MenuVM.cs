using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        ObservableCollection<GroupedCompetition> _groupedCompetitions;

        public MenuVM() : base()
        {
            _competitions = new List<Competition> { new Competition { Name = Strings.Loading } };

            Task.Run(async () => await Load());

            PdbService.CompetitionsLoaded += CompetitionsLoaded;
        }

        public List<Competition> Competitions
        {
            get { return _competitions; }
            set { SetProperty(ref _competitions, value); }
        }

        public ObservableCollection<GroupedCompetition> GroupedCompetitions
        {
            get { return _groupedCompetitions; }
            set { SetProperty(ref _groupedCompetitions, value); }
        }

        void CompetitionsLoaded(object sender, EventArgs e) => AssembleMenu();

        public async override Task Load()
        {
            if (PdbService.Competitions.IsNullOrEmpty())
            {
                if(HasInternetAccess())
                    await PdbService.GetCompetitions();
                else
                    await ShowNoConnectionError();
            }
            else
            {
                AssembleMenu();
            }
        }

        public async Task ChangeSelection(Competition competition)
        {
            if (string.IsNullOrEmpty(competition.Rankings))
                return;

            if(HasInternetAccess())
                PdbService.SelectedCompetition = competition;
            else
                await ShowNoConnectionError();
        }

        private void AssembleMenu()
        {
            var competitions = new List<Competition> { new Competition { Name = Strings.News } };
            competitions.AddRange(PdbService.Competitions);
            Competitions = competitions;

            var CGA = new GroupedCompetition(Strings.CompetitionGroupA, "A");
            var CGE = new GroupedCompetition(Strings.CompetitionGroupE, "E");
            var CG1 = new GroupedCompetition(Strings.CompetitionGroup1, "1");
            var CG2 = new GroupedCompetition(Strings.CompetitionGroup2, "2");
            var CG3 = new GroupedCompetition(Strings.CompetitionGroup3, "3");
            var CG4 = new GroupedCompetition(Strings.CompetitionGroup4, "4");

            foreach (var competition in competitions)
            {
                if (competition.Name.Equals(Strings.News)) CGA.Add(competition);
                else if (competition.Name.Contains("Ere")) CGE.Add(competition);
                else if (competition.Name.Contains("1")) CG1.Add(competition);
                else if (competition.Name.Contains("2")) CG2.Add(competition);
                else if (competition.Name.Contains("3")) CG3.Add(competition);
                else if (competition.Name.Contains("4")) CG4.Add(competition);
            }

            var groupedCompetitions = new ObservableCollection<GroupedCompetition>();
            groupedCompetitions.Add(CGA);
            groupedCompetitions.Add(CGE);
            groupedCompetitions.Add(CG1);
            groupedCompetitions.Add(CG2);
            groupedCompetitions.Add(CG3);
            groupedCompetitions.Add(CG4);

            GroupedCompetitions = groupedCompetitions;
        }
    }
}
