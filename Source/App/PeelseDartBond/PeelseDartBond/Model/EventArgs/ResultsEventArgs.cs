using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class ResultsEventArgs : System.EventArgs
    {
        readonly List<WeekResult> _results;

        public ResultsEventArgs(List<WeekResult> results) : base()
        {
            _results = results;
        }

        public List<WeekResult> Results { get { return _results; } }
    }
}
