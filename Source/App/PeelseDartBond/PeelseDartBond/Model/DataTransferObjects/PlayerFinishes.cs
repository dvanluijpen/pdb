using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class PlayerFinishes
    {
        public PlayerFinishes()
        {
            Players = new List<Player>();
        }

        public int Position { get; set; }
        public List<Player> Players { get; set; }
    }
}
