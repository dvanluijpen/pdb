using PeelseDartBond.Constants;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class MenuPage : ContentPage
    {
        MenuVM _vm;

		public MenuPage()
        {
            InitializeComponent();

			_vm = new MenuVM();
            BindingContext = _vm;
        }

        protected async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Competition;
            if (item != null)
            {
                // don't do anything is the competition is the same
                if (item == _vm.PdbService.SelectedCompetition)
                {
                    ((ContainerPage)App.Current.MainPage).IsPresented = false;
                    return;
                }
                
                // Show something else than a competition
                if(string.IsNullOrWhiteSpace(item.Rankings))
                {
                    if(item.Name.Equals(Strings.News))
                    {
                        var newsNavigationPage = new NavigationPage(new NewsPage());
                        newsNavigationPage.BarBackgroundColor = Colors.GreenDark;
                        newsNavigationPage.BarTextColor = Colors.WhiteNormal;
                        ((ContainerPage)App.Current.MainPage).Detail = newsNavigationPage;
                        ((ContainerPage)App.Current.MainPage).IsPresented = false;
                    }

                    listView.SelectedItem = null;
                    return;
                }

                // Show a competition
                var divisionPage = new DivisionPage();
                var divisionNavigationPage = new NavigationPage(divisionPage);
                divisionNavigationPage.BarBackgroundColor = Colors.GreenDark;
                divisionNavigationPage.BarTextColor = Colors.WhiteNormal;
                ((ContainerPage)App.Current.MainPage).Detail = divisionNavigationPage;
                await _vm.ChangeSelection(item);
                listView.SelectedItem = null;
                ((ContainerPage)App.Current.MainPage).IsPresented = false;
            }
        }
    }
}
