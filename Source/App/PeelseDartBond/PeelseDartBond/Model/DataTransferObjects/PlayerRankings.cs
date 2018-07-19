using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class PlayerRankings
    {
        public PlayerRankings()
        {
            Players = new List<Player>();
        }

        public int Position { get; set; }
        public List<Player> Players { get; set; }
    }
}
