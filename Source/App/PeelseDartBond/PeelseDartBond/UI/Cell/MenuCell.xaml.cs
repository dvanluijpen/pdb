using System;
using System.Collections.Generic;
using PeelseDartBond.Constants;
using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class MenuCell : ViewCell
    {
        public MenuCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(MenuCell), string.Empty, propertyChanged: OnPropertyChanged);
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var cell = (MenuCell)bindable;
            var division = (string)newValue;

            Logger.Info($"Current MainPage Type is {(((ContainerPage)App.Current.MainPage).Detail).GetType().ToString()}");
            cell.slContainer.BackgroundColor = division == PdbService.Instance.SelectedCompetition.Name ? Colors.Gray3 : Colors.WhiteNormal;
            cell.lblDivision.TextColor = Colors.Gray1; // year == PdbService.Instance.SelectedCompetitionYear.Title ? Colors.Gray1 : Colors.Gray1;
        }
    }
}
