using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class RankingCell : ViewCell
    {
        public RankingCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty RankingProperty = BindableProperty.Create(nameof(Ranking), typeof(Ranking), typeof(RankingCell), default(Ranking));

        public Ranking Ranking
        {
            get { return (Ranking)GetValue(RankingProperty); }
            set { SetValue(RankingProperty, value); }
        }
    }
}
