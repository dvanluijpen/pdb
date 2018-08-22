using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class Result180sWithHeaderCell : ViewCell
    {
        public Result180sWithHeaderCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ResultProperty = BindableProperty.Create(nameof(Result), typeof(Result180), typeof(Result180sWithHeaderCell), default(Result180));

        public Result180 Result
        {
            get { return (Result180)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
}
