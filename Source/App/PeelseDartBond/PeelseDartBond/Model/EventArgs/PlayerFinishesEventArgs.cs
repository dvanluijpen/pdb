using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class PlayerFinishesEventArgs : System.EventArgs
    {
        readonly List<PlayerFinish> _players;

        public PlayerFinishesEventArgs(List<PlayerFinish> players) : base()
        {
            _players = players;
        }

        public List<PlayerFinish> Players { get { return _players; } }
    }
}
