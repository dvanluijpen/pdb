using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class Player180sCell : ViewCell
    {
        public Player180sCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty PlayerProperty = BindableProperty.Create(nameof(Player), typeof(Player180s), typeof(Player180sCell), default(Player180s));

        public Player180s Player
        {
            get { return (Player180s)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }
    }
}
