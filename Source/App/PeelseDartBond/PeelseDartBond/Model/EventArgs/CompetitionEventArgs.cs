using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class CompetitionEventArgs : System.EventArgs
    {
        readonly Competition _competition;

        public CompetitionEventArgs(Competition competition) : base()
        {
            _competition = competition;
        }

        public Competition Competition { get { return _competition; } }
    }
}
