using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class ResultDoubleCell : ViewCell
    {
        public ResultDoubleCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ResultProperty = BindableProperty.Create(nameof(Result), typeof(ResultDouble), typeof(ResultDoubleCell), default(ResultDouble));

        public ResultDouble Result
        {
            get { return (ResultDouble)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
}
