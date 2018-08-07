using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class PlayerRankingsEventArgs : System.EventArgs
    {
        readonly List<PlayerRanking> _players;

        public PlayerRankingsEventArgs(List<PlayerRanking> players) : base()
        {
            _players = players;
        }

        public List<PlayerRanking> Players { get { return _players; } }
    }
}
