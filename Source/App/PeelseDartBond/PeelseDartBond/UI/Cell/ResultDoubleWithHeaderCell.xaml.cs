using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class ResultDoubleWithHeaderCell : ViewCell
    {
        public ResultDoubleWithHeaderCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ResultProperty = BindableProperty.Create(nameof(Result), typeof(ResultDouble), typeof(ResultDoubleWithHeaderCell), default(ResultDouble));

        public ResultDouble Result
        {
            get { return (ResultDouble)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
}
