using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class ResultsVM : BaseRefreshViewModel
    {
        List<WeekResult> _filteredResults;
        List<WeekResult> _results;
        List<string> _teams;
        List<string> _weeks;
        string _selectedTeam;
        string _selectedWeek;
        ICommand _filterByTeamCommand;
        ICommand _filterByWeekCommand;

        public ResultsVM() : base()
        {
            FilteredResults = new List<WeekResult>();
            Results = new List<WeekResult>();
            Teams = new List<string>();
            Weeks = new List<string>();
            _filterByTeamCommand = new Command(OnFilterByTeam);
            _filterByWeekCommand = new Command(OnFilterByWeek);

            PdbService.ResultsLoaded += ResultsLoaded;
            PdbService.RankingsLoaded += RankingsLoaded;
        }

        public ICommand FilterByTeamCommand { get { return _filterByTeamCommand; } }
        public ICommand FilterByWeekCommand { get { return _filterByWeekCommand; } }

        public List<WeekResult> FilteredResults
        {
            get { return _filteredResults; }
            set { SetProperty(ref _filteredResults, value); }
        }

        public List<WeekResult> Results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
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
            FilteredResults = e.Results;
            FillWeeks(e.Results);
        }

        void RankingsLoaded(object sender, RankingEventArgs e)
        {
            FillTeams(e.Teams);
        }

        public async override Task Load()
        {
            if (PdbService.Results == null)
            {
                await PdbService.GetResults();
            }
            else
            {
                Results = PdbService.Results;
                FilteredResults = PdbService.Results;
                FillWeeks(PdbService.Results);
            }
            
            if (PdbService.Rankings == null)
            {
                await PdbService.GetRankings();
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
                var filteredResults = Results;

                if(SelectedTeam != "Alle")
                    filteredResults = filteredResults.Where(r => r.TeamHome == SelectedTeam || r.TeamAway == SelectedTeam).ToList();

                if (SelectedWeek != "Alle")
                    filteredResults = filteredResults.Where(r => r.Week.ToString() == SelectedWeek).ToList();

                FilteredResults = filteredResults;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }
    }
}
