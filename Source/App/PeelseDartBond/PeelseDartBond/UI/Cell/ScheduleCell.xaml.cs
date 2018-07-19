using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class ScheduleCell : ViewCell
    {
        public ScheduleCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MatchProperty = BindableProperty.Create(nameof(Match), typeof(Schedule), typeof(ScheduleCell), default(Schedule));

        public Schedule Match
        {
            get { return (Schedule)GetValue(MatchProperty); }
            set { SetValue(MatchProperty, value); }
        }
    }
}
