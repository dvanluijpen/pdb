using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.DataTransferObjects
{
    public class Player180s
    {
        public Player180s()
        {
            Players = new List<Player>();
        }

        public int Position { get; set; }
        public List<Player> Players { get; set; }
    }
}
