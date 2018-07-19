using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class MatrixCell : ViewCell
    {
        public MatrixCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MatrixRowProperty = BindableProperty.Create(nameof(MatrixRow), typeof(MatrixRow), typeof(MatrixCell), default(MatrixRow));

        public MatrixRow MatrixRow
        {
            get { return (MatrixRow)GetValue(MatrixRowProperty); }
            set { SetValue(MatrixRowProperty, value); }
        }
    }
}
