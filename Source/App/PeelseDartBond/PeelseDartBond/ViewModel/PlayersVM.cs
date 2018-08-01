using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.ViewModel
{
    public class PlayersVM : BaseRefreshViewModel
    {
        IndividualPageType _selectedPageType;
        ObservableCollection<Player180s> _player180s;
        ObservableCollection<PlayerFinish> _playerFinishes;
        ObservableCollection<PlayerRanking> _playerRankings;

        public PlayersVM() : base()
        {
            SelectedPageType = IndividualPageType.Display180s;
            
            Player180s = new List<Player180s>().ToObservableCollection();
            PlayerFinishes = new List<PlayerFinish>().ToObservableCollection();
            PlayerRankings = new List<PlayerRanking>().ToObservableCollection();

            PdbService.Player180sLoaded += Player180sLoaded;
            PdbService.PlayerFinishesLoaded += PlayerFinishesLoaded;
            PdbService.PlayerRankingsLoaded += PlayerRankingsLoaded;
        }

        public IndividualPageType SelectedPageType
        {
            get { return _selectedPageType; }
            set { SetProperty(ref _selectedPageType, value); }
        }

        public ObservableCollection<Player180s> Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }

        public ObservableCollection<PlayerFinish> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
        }

        public ObservableCollection<PlayerRanking> PlayerRankings
        {
            get { return _playerRankings; }
            set { SetProperty(ref _playerRankings, value); }
        }

        void Player180sLoaded(object sender, Player180sEventArgs e) => Player180s = e.Players.ToObservableCollection();
        void PlayerFinishesLoaded(object sender, PlayerFinishesEventArgs e) => PlayerFinishes = e.Players.ToObservableCollection();
        void PlayerRankingsLoaded(object sender, PlayerRankingsEventArgs e) => PlayerRankings = e.Players.ToObservableCollection();

        public async override Task Load()
        {
            if (PdbService.Player180s == null)
            {
                await PdbService.GetPlayer180s();
            }
            else
            {
                Player180s = PdbService.Player180s.ToObservableCollection();
            }
            if (PdbService.PlayerFinishes == null)
            {
                await PdbService.GetPlayerFinishes();
            }
            else
            {
                PlayerFinishes = PdbService.PlayerFinishes.ToObservableCollection();
            }
            if (PdbService.PlayerRankings == null)
            {
                await PdbService.GetPlayerRankings();
            }
            else
            {
                PlayerRankings = PdbService.PlayerRankings.ToObservableCollection();
            }
        }

        public void UpdatePage(IndividualPageType type)
        {
            SelectedPageType = type;
        }
    }
}
