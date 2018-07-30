using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class PlayersVM : BaseRefreshViewModel
    {
        IndividualPageType _selectedPageType;
        List<Player180s> _player180s;
        List<PlayerFinish> _playerFinishes;
        List<PlayerRanking> _playerRankings;

        public PlayersVM() : base()
        {
            Player180s = new List<Player180s>();
            PlayerFinishes = new List<PlayerFinish>();
            PlayerRankings = new List<PlayerRanking>();

            PdbService.Player180sLoaded += Player180sLoaded;
            PdbService.PlayerFinishesLoaded += PlayerFinishesLoaded;
            PdbService.PlayerRankingsLoaded += PlayerRankingsLoaded;
        }

        public IndividualPageType SelectedPageType
        {
            get { return _selectedPageType; }
            set { SetProperty(ref _selectedPageType, value); }
        }

        public List<Player180s> Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }

        public List<PlayerFinish> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
        }

        public List<PlayerRanking> PlayerRankings
        {
            get { return _playerRankings; }
            set { SetProperty(ref _playerRankings, value); }
        }

        void Player180sLoaded(object sender, Player180sEventArgs e) => Player180s = e.Players;
        void PlayerFinishesLoaded(object sender, PlayerFinishesEventArgs e) => PlayerFinishes = e.Players;
        void PlayerRankingsLoaded(object sender, PlayerRankingsEventArgs e) => PlayerRankings = e.Players;

        public async override Task Load()
        {
            if (PdbService.Player180s == null)
            {
                await PdbService.GetPlayer180s();
            }
            else
            {
                Player180s = PdbService.Player180s;
            }
            if (PdbService.PlayerFinishes == null)
            {
                await PdbService.GetPlayerFinishes();
            }
            else
            {
                PlayerFinishes = PdbService.PlayerFinishes;
            }
            if (PdbService.PlayerRankings == null)
            {
                await PdbService.GetPlayerRankings();
            }
            else
            {
                PlayerRankings = PdbService.PlayerRankings;
            }
        }

        public void UpdatePage(IndividualPageType type)
        {
            SelectedPageType = type;
        }
    }
}
