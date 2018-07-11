using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class PlayerRankingsCell : ViewCell
    {
        public PlayerRankingsCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty PlayerRankingProperty = BindableProperty.Create(nameof(PlayerRanking), typeof(PlayerRanking), typeof(PlayerRankingsCell), default(PlayerRanking));

        public PlayerRanking PlayerRanking
        {
            get { return (PlayerRanking)GetValue(PlayerRankingProperty); }
            set { SetValue(PlayerRankingProperty, value); }
        }
    }
}
