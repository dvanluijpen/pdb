using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class NewsCell : ViewCell
    {
        public NewsCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty NewsProperty = BindableProperty.Create(nameof(News), typeof(News), typeof(NewsCell), default(News));

        public News News
        {
            get { return (News)GetValue(NewsProperty); }
            set { SetValue(NewsProperty, value); }
        }
    }
}
