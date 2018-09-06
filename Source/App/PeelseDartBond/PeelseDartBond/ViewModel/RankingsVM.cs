using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using Xamarin.Forms;

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

        public ICommand GoToTeamCommand { get { return new Command(async team => await OpenTeamPage(team)); } }

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

        async Task OpenTeamPage(object ranking)
        {
            var r = (Ranking)ranking;
            var team = await PdbService.GetTeamData(r);
            var contentPage = new TeamPage(team);
            contentPage.ViewModel.CloseRequested += async (s, e) => await OnClose(s, e);
            var navigationPage = new NavigationPage(contentPage);
            await NavigationService.GoToModalPage(navigationPage);
        }

        async Task OnClose(object sender, EventArgs e)
        {
            await NavigationService.PopCurrentModalPage();
        }
    }
}
