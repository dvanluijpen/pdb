using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ScheduleVM : BaseRefreshViewModel
    {
        List<Schedule> _schedule;
        ObservableCollection<Group<Schedule>> _groups;
        ObservableCollection<Group<Schedule>> _filteredGroups;
        List<string> _teams;
        List<string> _weeks;
        string _selectedTeam;
        string _selectedWeek;
        ICommand _filterByTeamCommand;
        ICommand _filterByWeekCommand;

        public ScheduleVM() : base()
        {
            Schedule = new List<Schedule>();
            Groups = new ObservableCollection<Group<Schedule>>();
            FilteredGroups = new ObservableCollection<Group<Schedule>>();
            Teams = new List<string>();
            Weeks = new List<string>();
            _filterByTeamCommand = new Command(OnFilterByTeam);
            _filterByWeekCommand = new Command(OnFilterByWeek);

            PdbService.RankingsLoaded += RankingsLoaded;
            PdbService.ScheduleLoaded += ScheduleLoaded;
        }

        public ICommand FilterByTeamCommand { get { return _filterByTeamCommand; } }
        public ICommand FilterByWeekCommand { get { return _filterByWeekCommand; } }

        public List<Schedule> Schedule
        {
            get { return _schedule; }
            set { SetProperty(ref _schedule, value); }
        }

        public ObservableCollection<Group<Schedule>> Groups
        {
            get { return _groups; }
            set { SetProperty(ref _groups, value); }
        }

        public ObservableCollection<Group<Schedule>> FilteredGroups
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

        void ScheduleLoaded(object sender, ScheduleEventArgs e)
        {
            Schedule = e.Schedule;   
            FillWeeks(e.Schedule);

            AssembleGroups();
        }

        void RankingsLoaded(object sender, RankingEventArgs e)
        {
            FillTeams(e.Teams);
        }

        public async override Task Load()
        {
            if(PdbService.Schedule == null)
            {
                await PdbService.GetScheduleAsync();
            }
            else
            {
                Schedule = PdbService.Schedule;
                FillWeeks(PdbService.Schedule);
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

        void FillWeeks(List<Schedule> results)
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
                    var subGroups = new ObservableCollection<Group<Schedule>>();
                    foreach (var group in filteredGroups)
                    {
                        subGroups.Add(new Group<Schedule>(group.LongName, group.ShortName,
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
            var weeks = Schedule.Select(r => r.Week).Distinct();
            var groups = new ObservableCollection<Group<Schedule>>();

            foreach (var week in weeks)
            {
                groups.Add(new Group<Schedule>($"Week {week}", week.ToString(), Schedule.Where(r => r.Week == week)));
            }

            Groups = groups;
            FilteredGroups = groups;
        }
    }
}
