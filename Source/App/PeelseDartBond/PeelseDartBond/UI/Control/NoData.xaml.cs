using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Control
{
    public partial class NoData : ContentView
    {
        public NoData()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(NoData), string.Empty);

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
    }
}
