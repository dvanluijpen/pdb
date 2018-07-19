using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class ResultsCell : ViewCell
    {
        public ResultsCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MatchProperty = BindableProperty.Create(nameof(Match), typeof(WeekResult), typeof(ResultsCell), default(WeekResult));

        public WeekResult Match
        {
            get { return (WeekResult)GetValue(MatchProperty); }
            set { SetValue(MatchProperty, value); }
        }
    }
}
