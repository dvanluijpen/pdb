using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class Result180sCell : ViewCell
    {
        public Result180sCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ResultProperty = BindableProperty.Create(nameof(Result), typeof(Result180), typeof(Result180sCell), default(Result180));

        public Result180 Result
        {
            get { return (Result180)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
}
