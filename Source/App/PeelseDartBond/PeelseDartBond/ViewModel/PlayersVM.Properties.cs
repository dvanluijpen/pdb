using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.Types;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public partial class PlayersVM
    {
        ICommand _filterByTeamCommand;
        public ICommand FilterByTeamCommand { get { return _filterByTeamCommand; } }
        public ICommand GoToPlayerCommand { get { return new Command(async basePlayer => await OpenPlayerPage(basePlayer)); } }

        bool _hasResults;
        public bool HasResults
        {
            get { return _hasResults; }
            set { SetProperty(ref _hasResults, value); }
        }

        IndividualPageType _selectedPageType;
        public IndividualPageType SelectedPageType
        {
            get { return _selectedPageType; }
            set { SetProperty(ref _selectedPageType, value); }
        }

        List<Player180s> _player180s;
        public List<Player180s> Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }

        ObservableCollection<Player180s> _filteredPlayer180s;
        public ObservableCollection<Player180s> FilteredPlayer180s
        {
            get { return _filteredPlayer180s; }
            set { SetProperty(ref _filteredPlayer180s, value); }
        }

        List<PlayerFinish> _playerFinishes;
        public List<PlayerFinish> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
        }

        ObservableCollection<PlayerFinish> _filteredPlayerFinishes;
        public ObservableCollection<PlayerFinish> FilteredPlayerFinishes
        {
            get { return _filteredPlayerFinishes; }
            set { SetProperty(ref _filteredPlayerFinishes, value); }
        }

        List<PlayerRanking> _playerRankings;
        public List<PlayerRanking> PlayerRankings
        {
            get { return _playerRankings; }
            set { SetProperty(ref _playerRankings, value); }
        }

        ObservableCollection<PlayerRanking> _filteredPlayerRankings;
        public ObservableCollection<PlayerRanking> FilteredPlayerRankings
        {
            get { return _filteredPlayerRankings; }
            set { SetProperty(ref _filteredPlayerRankings, value); }
        }

        List<string> _teams;
        public List<string> Teams
        {
            get { return _teams; }
            set { SetProperty(ref _teams, value); }
        }

        string _selectedTeam;
        public string SelectedTeam
        {
            get { return _selectedTeam; }
            set { SetProperty(ref _selectedTeam, value); }
        }
    }
}
