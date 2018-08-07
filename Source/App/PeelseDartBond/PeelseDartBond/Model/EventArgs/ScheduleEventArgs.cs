using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class ScheduleEventArgs : System.EventArgs
    {
        readonly List<Schedule> _schedule;

        public ScheduleEventArgs(List<Schedule> schedule) : base()
        {
            _schedule = schedule;
        }

        public List<Schedule> Schedule { get { return _schedule; } }
    }
}
