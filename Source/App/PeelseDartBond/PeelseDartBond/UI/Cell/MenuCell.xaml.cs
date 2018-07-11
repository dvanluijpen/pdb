using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class MenuCell : ViewCell
    {
        public MenuCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(MenuCell), string.Empty);

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
    }
}
