using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class ResultsVM : BaseRefreshViewModel
    {
        bool _hasResults;
        List<WeekResult> _results;
        ObservableCollection<Group<WeekResult>> _groups;
        ObservableCollection<Group<WeekResult>> _filteredGroups;
        List<string> _teams;
        List<string> _weeks;
        string _selectedTeam;
        string _selectedWeek;
        ICommand _filterByTeamCommand;
        ICommand _filterByWeekCommand;

        public ResultsVM() : base()
        {
            Results = new List<WeekResult>();
            Groups = new ObservableCollection<Group<WeekResult>>();
            FilteredGroups = new ObservableCollection<Group<WeekResult>>();
            Teams = new List<string>();
            Weeks = new List<string>();
            _filterByTeamCommand = new Command(OnFilterByTeam);
            _filterByWeekCommand = new Command(OnFilterByWeek);

            PdbService.ResultsLoaded += ResultsLoaded;
            PdbService.RankingsLoaded += RankingsLoaded;
        }

        public ICommand FilterByTeamCommand { get { return _filterByTeamCommand; } }
        public ICommand FilterByWeekCommand { get { return _filterByWeekCommand; } }

        public bool HasResults
        {
            get { return _hasResults; }
            set { SetProperty(ref _hasResults, value); }
        }

        public List<WeekResult> Results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); HasResults = !value.IsNullOrEmpty(); }
        }

        public ObservableCollection<Group<WeekResult>> Groups
        {
            get { return _groups; }
            set { SetProperty(ref _groups, value); }
        }

        public ObservableCollection<Group<WeekResult>> FilteredGroups
        {
            get { return _filteredGroups; }
            set { SetProperty(ref _filteredGroups, value); }
        }

        public List<string> Teams
        {
            get { return _teams; }
            set { SetProperty(ref _teams, value); }
        }

        public List<string> Weeks
        {
            get { return _weeks; }
            set { SetProperty(ref _weeks, value); }
        }

        public string SelectedTeam
        {
            get { return _selectedTeam; }
            set { SetProperty(ref _selectedTeam, value); }
        }

        public string SelectedWeek
        {
            get { return _selectedWeek; }
            set { SetProperty(ref _selectedWeek, value); }
        }

        void ResultsLoaded(object sender, ResultsEventArgs e)
        {
            Results = e.Results;
            FillWeeks(e.Results);

            AssembleGroups();
        }

        void RankingsLoaded(object sender, RankingEventArgs e)
        {
            FillTeams(e.Teams);
        }

        public async override Task Load()
        {
            if (PdbService.Results == null)
            {
                await PdbService.GetResultsAsync();
            }
            else
            {
                Results = PdbService.Results;
                FillWeeks(PdbService.Results);
            }
            
            if (PdbService.Rankings == null)
            {
                await PdbService.GetRankingsAsync();
            }
            else
            {
                FillTeams(PdbService.Rankings);
            }
        }

        void FillTeams(List<Ranking> rankings)
        {
            var teams = new List<string>();
            rankings.ForEach(t => teams.Add(t.Team));

            Teams = new List<string> { "Alle" };
            Teams.AddRange(teams.OrderBy(t => t));

            SelectedTeam = Teams.FirstOrDefault();
        }

        void FillWeeks(List<WeekResult> results)
        {
            var weeks = new List<string>();
            results.ForEach(t => weeks.Add(t.Week.ToString()));

            Weeks = new List<string> { "Alle" };
            Weeks.AddRange(weeks.Distinct());

            SelectedWeek = Weeks.FirstOrDefault();
        }

        void OnFilterByTeam(object parameter)
        {
            SelectedTeam = parameter.ToString();
            UpdateFilter();
        }

        void OnFilterByWeek(object parameter)
        {
            SelectedWeek = parameter.ToString();
            UpdateFilter();
        }

        public void UpdateFilter()
        {
            try
            {
                var filteredGroups = Groups;

                if (SelectedTeam != "Alle")
                {
                    var subGroups = new ObservableCollection<Group<WeekResult>>();
                    foreach (var group in filteredGroups)
                    {
                        subGroups.Add(new Group<WeekResult>(group.LongName, group.ShortName,
                                                            group.Where(g => g.TeamHome == SelectedTeam || g.TeamAway == SelectedTeam)));
                    }
                    filteredGroups = subGroups;
                }

                if (SelectedWeek != "Alle")
                    filteredGroups = filteredGroups.Where(r => r.ShortName == SelectedWeek).ToObservableCollection();

                FilteredGroups = filteredGroups;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        public void AssembleGroups()
        {
            var weeks = Results.Select(r => r.Week).Distinct();
            var groups = new ObservableCollection<Group<WeekResult>>();

            foreach (var week in weeks)
            {
                groups.Add(new Group<WeekResult>($"Week {week}", week.ToString(), Results.Where(r => r.Week == week)));
            }

            Groups = groups;
            FilteredGroups = groups;
        }
    }
}
