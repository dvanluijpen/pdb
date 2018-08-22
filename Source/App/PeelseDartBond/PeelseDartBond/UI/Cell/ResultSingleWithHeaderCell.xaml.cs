using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class ResultSingleWithHeaderCell : ViewCell
    {
        public ResultSingleWithHeaderCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ResultProperty = BindableProperty.Create(nameof(Result), typeof(ResultSingleBase), typeof(ResultSingleWithHeaderCell), default(ResultSingleBase));

        public ResultSingleBase Result
        {
            get { return (ResultSingleBase)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
}
