using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public partial class PlayersVM
    {
        public void UpdatePage(IndividualPageType type)
        {
            SelectedPageType = type;
            UpdateFilter();
        }

        async Task OpenPlayerPage(object basePlayer)
        {
            var bp = (BasePlayer)basePlayer;

            if (bp == null) 
                return;

            var player = PdbService.GetPlayerData(bp.Name, bp.Team, bp.TeamUrl);
            var contentPage = new PlayerPage(player);
            contentPage.ViewModel.CloseRequested += async (s, e) => await OnClose(s, e);
            var navigationPage = new NavigationPage(contentPage);
            await NavigationService.GoToModalPage(navigationPage);
        }

        async Task OnClose(object sender, EventArgs e)
        {
            await NavigationService.PopCurrentModalPage();
        }

        void FillTeams(List<Ranking> rankings)
        {
            var teams = new List<string>();
            rankings.ForEach(t => teams.Add(t.Team));

            Teams = new List<string> { "Alle" };
            Teams.AddRange(teams.OrderBy(t => t));

            SelectedTeam = Teams.FirstOrDefault();
        }

        void OnFilterByTeam(object parameter)
        {
            SelectedTeam = parameter.ToString();
            UpdateFilter();
        }

        public void UpdateFilter()
        {
            FilteredPlayer180s.Clear();
            FilteredPlayerFinishes.Clear();
            FilteredPlayerRankings.Clear();

            foreach (var player in Player180s)
            {
                if (SelectedTeam == "Alle" || string.IsNullOrWhiteSpace(SelectedTeam))
                    FilteredPlayer180s.Add(player);
                else if (player.Team == SelectedTeam)
                    FilteredPlayer180s.Add(player);
            }
            foreach (var player in PlayerFinishes)
            {
                if (SelectedTeam == "Alle" || string.IsNullOrWhiteSpace(SelectedTeam))
                    FilteredPlayerFinishes.Add(player);
                else if (player.Team == SelectedTeam)
                    FilteredPlayerFinishes.Add(player);
            }
            foreach (var player in PlayerRankings)
            {
                if (SelectedTeam == "Alle" || string.IsNullOrWhiteSpace(SelectedTeam))
                    FilteredPlayerRankings.Add(player);
                else if (player.Team == SelectedTeam)
                    FilteredPlayerRankings.Add(player);
            }

            if (SelectedPageType == IndividualPageType.Display180s)
                HasResults = !FilteredPlayer180s.IsNullOrEmpty();
            else if (SelectedPageType == IndividualPageType.DisplayFinishes)
                HasResults = !FilteredPlayerFinishes.IsNullOrEmpty();
            else if (SelectedPageType == IndividualPageType.DisplaySingles)
                HasResults = !FilteredPlayerRankings.IsNullOrEmpty();
        }
    }
}
