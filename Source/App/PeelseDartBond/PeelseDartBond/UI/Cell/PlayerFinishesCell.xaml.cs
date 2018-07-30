using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class PlayerFinishesCell : ViewCell
    {
        public PlayerFinishesCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty PlayerProperty = BindableProperty.Create(nameof(Player), typeof(PlayerFinish), typeof(PlayerFinishesCell), default(PlayerFinish));

        public PlayerFinish Player
        {
            get { return (PlayerFinish)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }
    }
}
