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
        ObservableCollection<Group<Competition>> _groupedCompetitions;

        public MenuVM() : base()
        {
            _competitions = new List<Competition> { new Competition { Name = Strings.Loading } };
            _groupedCompetitions = new ObservableCollection<Group<Competition>>();

            Task.Run(async () => await Load());

            PdbService.CompetitionsLoaded += CompetitionsLoaded;
        }

        public List<Competition> Competitions
        {
            get { return _competitions; }
            set { SetProperty(ref _competitions, value); }
        }

        public ObservableCollection<Group<Competition>> GroupedCompetitions
        {
            get { return _groupedCompetitions; }
            set { SetProperty(ref _groupedCompetitions, value); }
        }

        void CompetitionsLoaded(object sender, EventArgs e) => AssembleGroups();

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
                AssembleGroups();
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

        private void AssembleGroups()
        {
            var competitions = new List<Competition> { new Competition { Name = Strings.News } };
            competitions.AddRange(PdbService.Competitions);
            Competitions = competitions;

            var CGA = new Group<Competition>(Strings.CompetitionGroupA, "A");
            var CGE = new Group<Competition>(Strings.CompetitionGroupE, "E");
            var CG1 = new Group<Competition>(Strings.CompetitionGroup1, "1");
            var CG2 = new Group<Competition>(Strings.CompetitionGroup2, "2");
            var CG3 = new Group<Competition>(Strings.CompetitionGroup3, "3");
            var CG4 = new Group<Competition>(Strings.CompetitionGroup4, "4");

            foreach (var competition in competitions)
            {
                if (competition.Name.Equals(Strings.News)) CGA.Add(competition);
                else if (competition.Name.Contains("Ere")) CGE.Add(competition);
                else if (competition.Name.Contains("1")) CG1.Add(competition);
                else if (competition.Name.Contains("2")) CG2.Add(competition);
                else if (competition.Name.Contains("3")) CG3.Add(competition);
                else if (competition.Name.Contains("4")) CG4.Add(competition);
            }

            var groups = new ObservableCollection<Group<Competition>>();
            groups.Add(CGA);
            groups.Add(CGE);
            groups.Add(CG1);
            groups.Add(CG2);
            groups.Add(CG3);
            groups.Add(CG4);

            GroupedCompetitions = groups;
        }
    }
}
