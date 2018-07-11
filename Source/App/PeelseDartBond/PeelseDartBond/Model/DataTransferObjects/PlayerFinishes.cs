using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class PlayerFinishes
    {
        public PlayerFinishes()
        {
        }

        public int Position { get; set; }
        public List<Player> Players { get; set; }
    }
}
