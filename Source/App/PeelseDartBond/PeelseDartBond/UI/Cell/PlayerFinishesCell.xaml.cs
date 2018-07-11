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

        public static readonly BindableProperty PlayerFinishProperty = BindableProperty.Create(nameof(PlayerFinish), typeof(PlayerFinish), typeof(PlayerFinishesCell), default(PlayerFinish));

        public PlayerFinish PlayerFinish
        {
            get { return (PlayerFinish)GetValue(PlayerFinishProperty); }
            set { SetValue(PlayerFinishProperty, value); }
        }
    }
}
