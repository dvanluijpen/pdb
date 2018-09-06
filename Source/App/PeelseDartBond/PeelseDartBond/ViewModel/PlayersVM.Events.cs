using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.ViewModel
{
    public partial class PlayersVM
	{
        void Player180sLoaded(object sender, Player180sEventArgs e)
        {
            Player180s = e.Players;
            UpdateFilter();
        }

        void PlayerFinishesLoaded(object sender, PlayerFinishesEventArgs e)
        {
            PlayerFinishes = e.Players;
            UpdateFilter();
        }

        void PlayerRankingsLoaded(object sender, PlayerRankingsEventArgs e)
        {
            PlayerRankings = e.Players;
            UpdateFilter();
        }

        void RankingsLoaded(object sender, RankingEventArgs e)
        {
            FillTeams(e.Teams);
        }
    }
}
