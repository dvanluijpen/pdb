using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class PlayerRankingsVM : BaseRefreshViewModel
    {
        List<PlayerRanking> _players;

        public PlayerRankingsVM() : base()
        {
            Players = new List<PlayerRanking>();

            PdbService.PlayerRankingsLoaded += PlayerRankingsLoaded;
        }

        public List<PlayerRanking> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }

        void PlayerRankingsLoaded(object sender, PlayerRankingsEventArgs e)
        {
            Players = e.Players;   
        }

        public async override Task Load()
        {
            if(PdbService.PlayerRankings == null)
            {
                await PdbService.GetPlayerRankings();
            }
            else
            {
                Players = PdbService.PlayerRankings;
            }
        }
    }
}
