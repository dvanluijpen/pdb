using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class ResultsEventArgs
    {
        readonly List<WeekResult> _results;

        public ResultsEventArgs(List<WeekResult> results)
        {
            _results = results;
        }

        public List<WeekResult> Results { get { return _results; } }
    }
}
