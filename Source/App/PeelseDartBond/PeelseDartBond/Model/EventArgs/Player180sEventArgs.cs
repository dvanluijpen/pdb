using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class Player180sEventArgs : System.EventArgs
    {
        readonly List<Player180s> _players;

        public Player180sEventArgs(List<Player180s> players) : base()
        {
            _players = players;
        }

        public List<Player180s> Players { get { return _players; } }
    }
}
