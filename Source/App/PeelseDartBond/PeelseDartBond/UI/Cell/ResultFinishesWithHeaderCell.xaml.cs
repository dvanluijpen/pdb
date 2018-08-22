using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class ResultFinishesWithHeaderCell : ViewCell
    {
        public ResultFinishesWithHeaderCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ResultProperty = BindableProperty.Create(nameof(Result), typeof(ResultFinish), typeof(ResultFinishesWithHeaderCell), default(ResultFinish));

        public ResultFinish Result
        {
            get { return (ResultFinish)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
}
