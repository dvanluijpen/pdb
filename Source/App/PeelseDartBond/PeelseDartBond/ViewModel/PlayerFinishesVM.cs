using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class PlayerFinishesVM : BaseRefreshViewModel
    {
        List<PlayerFinish> _players;

        public PlayerFinishesVM() : base()
        {
            Players = new List<PlayerFinish>();

            PdbService.PlayerFinishesLoaded += PlayerFinishesLoaded;
        }

        public List<PlayerFinish> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }

        void PlayerFinishesLoaded(object sender, PlayerFinishesEventArgs e)
        {
            Players = e.Players;   
        }

        public async override Task Load()
        {
            if(PdbService.PlayerFinishes == null)
            {
                await PdbService.GetPlayerFinishes();
            }
            else
            {
                Players = PdbService.PlayerFinishes;
            }
        }
    }
}
