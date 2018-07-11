using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class PlayerRankings
    {
        public PlayerRankings()
        {
        }

        public int Position { get; set; }
        public List<Player> Players { get; set; }
    }
}
