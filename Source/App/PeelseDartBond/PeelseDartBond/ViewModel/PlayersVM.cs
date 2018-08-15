using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class PlayersVM : BaseRefreshViewModel
    {
        bool _hasResults;
        IndividualPageType _selectedPageType;
        ObservableCollection<Player180s> _player180s;
        ObservableCollection<Player180s> _filteredPlayer180s;
        ObservableCollection<PlayerFinish> _playerFinishes;
        ObservableCollection<PlayerFinish> _filteredPlayerFinishes;
        ObservableCollection<PlayerRanking> _playerRankings;
        ObservableCollection<PlayerRanking> _filteredPlayerRankings;
        List<string> _teams;
        string _selectedTeam;
        ICommand _filterByTeamCommand;
        PlayersPage _page;

        public PlayersVM(PlayersPage page) : base()
        {
            _page = page;

            SelectedPageType = IndividualPageType.Display180s;
            
            Player180s = new List<Player180s>().ToObservableCollection();
            FilteredPlayer180s = new List<Player180s>().ToObservableCollection();
            PlayerFinishes = new List<PlayerFinish>().ToObservableCollection();
            FilteredPlayerFinishes = new List<PlayerFinish>().ToObservableCollection();
            PlayerRankings = new List<PlayerRanking>().ToObservableCollection();
            FilteredPlayerRankings = new List<PlayerRanking>().ToObservableCollection();

            Teams = new List<string>();
            _filterByTeamCommand = new Command(OnFilterByTeam);

            PdbService.Player180sLoaded += Player180sLoaded;
            PdbService.PlayerFinishesLoaded += PlayerFinishesLoaded;
            PdbService.PlayerRankingsLoaded += PlayerRankingsLoaded;
            PdbService.RankingsLoaded += RankingsLoaded;
        }

        public ICommand FilterByTeamCommand { get { return _filterByTeamCommand; } }
        public ICommand GoToPlayerCommand { get { return new Command(async basePlayer => await OpenPlayerPage(basePlayer)); } }

        public IndividualPageType SelectedPageType
        {
            get { return _selectedPageType; }
            set { SetProperty(ref _selectedPageType, value); }
        }

        public bool HasResults
        {
            get { return _hasResults; }
            set { SetProperty(ref _hasResults, value); }
        }

        public ObservableCollection<Player180s> Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }

        public ObservableCollection<Player180s> FilteredPlayer180s
        {
            get { return _filteredPlayer180s; }
            set { SetProperty(ref _filteredPlayer180s, value); }
        }

        public ObservableCollection<PlayerFinish> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
        }

        public ObservableCollection<PlayerFinish> FilteredPlayerFinishes
        {
            get { return _filteredPlayerFinishes; }
            set { SetProperty(ref _filteredPlayerFinishes, value); }
        }

        public ObservableCollection<PlayerRanking> PlayerRankings
        {
            get { return _playerRankings; }
            set { SetProperty(ref _playerRankings, value); }
        }

        public ObservableCollection<PlayerRanking> FilteredPlayerRankings
        {
            get { return _filteredPlayerRankings; }
            set { SetProperty(ref _filteredPlayerRankings, value); }
        }

        public List<string> Teams
        {
            get { return _teams; }
            set { SetProperty(ref _teams, value); }
        }

        public string SelectedTeam
        {
            get { return _selectedTeam; }
            set { SetProperty(ref _selectedTeam, value); }
        }

        void Player180sLoaded(object sender, Player180sEventArgs e)
        {
            Player180s = e.Players.ToObservableCollection();

            if (SelectedPageType == IndividualPageType.Display180s)
                HasResults = !Player180s.IsNullOrEmpty();

            UpdateFilter();
            _page.UpdateDisplay();
        }
        void PlayerFinishesLoaded(object sender, PlayerFinishesEventArgs e)
        {
            PlayerFinishes = e.Players.ToObservableCollection();

            if (SelectedPageType == IndividualPageType.DisplayFinishes)
                HasResults = !PlayerFinishes.IsNullOrEmpty();

            UpdateFilter();
            _page.UpdateDisplay();
        }
        void PlayerRankingsLoaded(object sender, PlayerRankingsEventArgs e)
        {
            PlayerRankings = e.Players.ToObservableCollection();

            if (SelectedPageType == IndividualPageType.DisplaySingles)
                HasResults = !PlayerRankings.IsNullOrEmpty();

            UpdateFilter();
            _page.UpdateDisplay();
        }

        void RankingsLoaded(object sender, RankingEventArgs e)
        {
            FillTeams(e.Teams);
        }

        public async override Task Load()
        {
            await Load180s();
            await LoadFinishes();
            await LoadRankings();

            if (PdbService.Rankings == null)
            {
                await PdbService.GetRankingsAsync();
            }
            else
            {
                FillTeams(PdbService.Rankings);
            }
        }

        public async Task Load180s()
        {
            if (PdbService.Player180s == null)
            {
                await PdbService.GetPlayer180sAsync();
            }
            else
            {
                Player180s = PdbService.Player180s.ToObservableCollection();

                if (SelectedPageType == IndividualPageType.Display180s)
                    HasResults = true;

                UpdateFilter();
                _page.UpdateDisplay();
            }
        }

        public async Task LoadFinishes()
        {
            if (PdbService.PlayerFinishes == null)
            {
                await PdbService.GetPlayerFinishesAsync();
            }
            else
            {
                PlayerFinishes = PdbService.PlayerFinishes.ToObservableCollection();

                if (SelectedPageType == IndividualPageType.DisplayFinishes)
                    HasResults = true;

                UpdateFilter();
                _page.UpdateDisplay();
            }
        }

        public async Task LoadRankings()
        {
            if (PdbService.PlayerRankings == null)
            {
                await PdbService.GetPlayerRankingsAsync();
            }
            else
            {
                PlayerRankings = PdbService.PlayerRankings.ToObservableCollection();

                if (SelectedPageType == IndividualPageType.DisplaySingles)
                    HasResults = true;

                UpdateFilter();
                _page.UpdateDisplay();
            }
        }

        public void UpdatePage(IndividualPageType type)
        {
            SelectedPageType = type;

            if (SelectedPageType == IndividualPageType.Display180s)
                HasResults = !Player180s.IsNullOrEmpty();

            if (SelectedPageType == IndividualPageType.DisplayFinishes)
                HasResults = !PlayerFinishes.IsNullOrEmpty();

            if (SelectedPageType == IndividualPageType.DisplaySingles)
                HasResults = !PlayerRankings.IsNullOrEmpty();
        }

        async Task OpenPlayerPage(object basePlayer)
        {
            //var player = new Player
            //{
            //    Name = "Danny van Luijpen",
            //    Team = "De Molen 2",
            //    TeamUrl = "...",
            //    Position180s = 7,
            //    PositionFinishes = 4,
            //    PositionRanking = 15,
            //    Player180s = 2,
            //    PlayerFinishes = new List<int> { 170, 161, 146, 126, 119 },
            //    Played = 18,
            //    Won = 9,
            //    Percentage = 50,
            //};
            var bp = (BasePlayer)basePlayer;
            var player = PdbService.GetPlayerData(bp.Name, bp.Team, bp.TeamUrl);
            var contentPage = new PlayerPage(player);
            contentPage.ViewModel.CloseRequested += async (s ,e) => await OnClose(s, e);
            var navigationPage = new NavigationPage(contentPage);
            await NavigationService.GoToModalPage(navigationPage);
        }

        async Task OnClose(object sender, EventArgs e)
        {
            await NavigationService.PopCurrentModalPage();
        }

        void FillTeams(List<Ranking> rankings)
        {
            var teams = new List<string>();
            rankings.ForEach(t => teams.Add(t.Team));

            Teams = new List<string> { "Alle" };
            Teams.AddRange(teams.OrderBy(t => t));

            SelectedTeam = Teams.FirstOrDefault();
        }

        void OnFilterByTeam(object parameter)
        {
            SelectedTeam = parameter.ToString();
            UpdateFilter();
        }

        public void UpdateFilter()
        {
            try
            {
                FilteredPlayer180s = SelectedTeam == "Alle"
                    ? Player180s
                    : Player180s.Where(p => p.Team == SelectedTeam).ToObservableCollection();

                FilteredPlayerFinishes = SelectedTeam == "Alle"
                    ? PlayerFinishes
                    : PlayerFinishes.Where(p => p.Team == SelectedTeam).ToObservableCollection();

                FilteredPlayerRankings = SelectedTeam == "Alle"
                    ? PlayerRankings
                    : PlayerRankings.Where(p => p.Team == SelectedTeam).ToObservableCollection();

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }
    }
}
