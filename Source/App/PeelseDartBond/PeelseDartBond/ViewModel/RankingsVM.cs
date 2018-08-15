using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class RankingsVM : BaseRefreshViewModel
    {
        List<Ranking> _teams;

        public RankingsVM() : base()
        {
            Teams = new List<Ranking>();

            PdbService.RankingsLoaded += RankingsLoaded;
        }

        public List<Ranking> Teams
        {
            get { return _teams; }
            set { SetProperty(ref _teams, value); }
        }

        void RankingsLoaded(object sender, RankingEventArgs e)
        {
            Teams = e.Teams;   
        }

        public async override Task Load()
        {
            if(PdbService.Rankings == null)
            {
                await PdbService.GetRankingsAsync();
            }
            else
            {
                Teams = PdbService.Rankings;
            }
        }
    }
}
