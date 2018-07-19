using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class ScheduleVM : BaseRefreshViewModel
    {
        List<Schedule> _schedule;

        public ScheduleVM() : base()
        {
            Schedule = new List<Schedule>();

            PdbService.ScheduleLoaded += ScheduleLoaded;
        }

        public List<Schedule> Schedule
        {
            get { return _schedule; }
            set { SetProperty(ref _schedule, value); }
        }

        void ScheduleLoaded(object sender, ScheduleEventArgs e)
        {
            Schedule = e.Schedule;   
        }

        public async override Task Load()
        {
            if(PdbService.Schedule == null)
            {
                await PdbService.GetSchedule();
            }
            else
            {
                Schedule = PdbService.Schedule;
            }
        }
    }
}
