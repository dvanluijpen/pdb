using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class CompetitionYearsEventArgs : System.EventArgs
    {
        readonly List<CompetitionYear> _competitionYears;

        public CompetitionYearsEventArgs(List<CompetitionYear> competitionYears) : base()
        {
            _competitionYears = competitionYears;
        }

        public List<CompetitionYear> CompetitionYears { get { return _competitionYears; } }
    }
}
