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

        public static readonly BindableProperty PlayerProperty = BindableProperty.Create(nameof(Player), typeof(PlayerRanking), typeof(PlayerRankingsCell), default(PlayerRanking));

        public PlayerRanking Player
        {
            get { return (PlayerRanking)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }
    }
}
