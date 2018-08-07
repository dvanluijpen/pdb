using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class CompetitionYearEventArgs : System.EventArgs
    {
        readonly CompetitionYear _competitionYear;

        public CompetitionYearEventArgs(CompetitionYear competitionYear) : base()
        {
            _competitionYear = competitionYear;
        }

        public CompetitionYear CompetitionYear { get { return _competitionYear; } }
    }
}
