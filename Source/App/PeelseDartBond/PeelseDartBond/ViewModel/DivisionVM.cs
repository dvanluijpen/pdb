using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class DivisionVM : BaseRefreshViewModel
    {
        string _division;

        public DivisionVM() : base()
        {
            Task.Run(async () => await Load());
            PdbService.SelectedCompetitionChanged += SelectedCompetitionChanged;
        }

        public string Division
        {
            get { return _division; }
            set { SetProperty(ref _division, value); }
        }

        void SelectedCompetitionChanged(object sender, EventArgs e) => Division = PdbService.SelectedCompetition.Name;

        public async override Task Load()
        {
            await Task.Delay(0);

            if (PdbService.SelectedCompetition == null)
            {
                if(PdbService.Competitions == null)
                {
                    Division = string.Empty;
                }
                else
                {
                    Division = PdbService.Competitions.First().Name;
                }
            }
            else
            {
                Division = PdbService.SelectedCompetition.Name;
            }
        }
    }
}
