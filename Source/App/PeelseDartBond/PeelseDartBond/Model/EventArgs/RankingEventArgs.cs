using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class RankingEventArgs : System.EventArgs
    {
        readonly List<Ranking> _teams;

        public RankingEventArgs(List<Ranking> teams) : base()
        {
            _teams = teams;
        }

        public List<Ranking> Teams { get { return _teams; } }
    }
}
