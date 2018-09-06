using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public partial class PlayersVM : BaseRefreshViewModel
    {
        public PlayersVM() : base()
        {
            SelectedPageType = IndividualPageType.Display180s;
            
            Player180s = new List<Player180s>();
            FilteredPlayer180s = new List<Player180s>().ToObservableCollection();
            PlayerFinishes = new List<PlayerFinish>();
            FilteredPlayerFinishes = new List<PlayerFinish>().ToObservableCollection();
            PlayerRankings = new List<PlayerRanking>();
            FilteredPlayerRankings = new List<PlayerRanking>().ToObservableCollection();
            _filterByTeamCommand = new Command(OnFilterByTeam);

            Teams = new List<string>();

            PdbService.Player180sLoaded += Player180sLoaded;
            PdbService.PlayerFinishesLoaded += PlayerFinishesLoaded;
            PdbService.PlayerRankingsLoaded += PlayerRankingsLoaded;
            PdbService.RankingsLoaded += RankingsLoaded;

            Task.Run(async () => await Load());
        }

        public async override Task Load()
        {
            Player180s = PdbService.Player180s;
            PlayerFinishes = PdbService.PlayerFinishes;
            PlayerRankings = PdbService.PlayerRankings;

            var teams = new List<string>();
            PdbService.Rankings.ForEach(t => teams.Add(t.Team));

            Teams = new List<string> { "Alle" };
            Teams.AddRange(teams.OrderBy(t => t));

            SelectedTeam = Teams.FirstOrDefault();

            UpdateFilter();
        }
    }
}
