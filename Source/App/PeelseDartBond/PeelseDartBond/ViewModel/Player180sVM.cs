using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class Player180sVM : BaseRefreshViewModel
    {
        List<Player180s> _players;

        public Player180sVM() : base()
        {
            Players = new List<Player180s>();

            PdbService.Player180sLoaded += Player180sLoaded;
        }

        public List<Player180s> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }

        void Player180sLoaded(object sender, Player180sEventArgs e)
        {
            Players = e.Players;   
        }

        public async override Task Load()
        {
            if(PdbService.Player180s == null)
            {
                await PdbService.GetPlayer180s();
            }
            else
            {
                Players = PdbService.Player180s;
            }
        }
    }
}
