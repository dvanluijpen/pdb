using System;
using System.Collections.Generic;
using PeelseDartBond.Constants;
using PeelseDartBond.Services;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class YearCell : ViewCell
    {
        public YearCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty YearProperty = BindableProperty.Create(nameof(Year), typeof(string), typeof(YearCell), default(string), propertyChanged: OnPropertyChanged);
        public string Year
        {
            get { return (string)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var cell = (YearCell)bindable;
            var year = (string)newValue;

            cell.slContainer.BackgroundColor = year == PdbService.Instance.SelectedCompetitionYear.Title ? Colors.Gray3 : Colors.WhiteNormal;
            cell.lblYear.TextColor = Colors.Gray1; // year == PdbService.Instance.SelectedCompetitionYear.Title ? Colors.Gray1 : Colors.Gray1;
        }
    }
}
