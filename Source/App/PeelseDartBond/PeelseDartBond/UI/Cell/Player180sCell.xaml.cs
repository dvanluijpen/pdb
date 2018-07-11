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

        public static readonly BindableProperty Player180sProperty = BindableProperty.Create(nameof(Player180s), typeof(Player180s), typeof(Player180sCell), default(Player180s));

        public Player180s Player180s
        {
            get { return (Player180s)GetValue(Player180sProperty); }
            set { SetValue(Player180sProperty, value); }
        }
    }
}
