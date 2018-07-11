using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class PlayerRankingsEventArgs
    {
        readonly List<PlayerRanking> _players;

        public PlayerRankingsEventArgs(List<PlayerRanking> players)
        {
            _players = players;
        }

        public List<PlayerRanking> Players { get { return _players; } }
    }
}
