using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class MenuHeaderCell : ViewCell
    {
        public MenuHeaderCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(MenuHeaderCell), string.Empty);

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
    }
}
