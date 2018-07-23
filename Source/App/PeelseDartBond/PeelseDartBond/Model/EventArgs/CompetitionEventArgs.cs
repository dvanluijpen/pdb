using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class CompetitionEventArgs
    {
        readonly Competition _competition;

        public CompetitionEventArgs(Competition competition)
        {
            _competition = competition;
        }

        public Competition Competition { get { return _competition; } }
    }
}
