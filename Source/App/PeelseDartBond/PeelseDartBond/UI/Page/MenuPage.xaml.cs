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

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Competition;
            if (item != null)
            {
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

                var divisionNavigationPage = new NavigationPage(new DivisionPage());
                divisionNavigationPage.BarBackgroundColor = Colors.GreenDark;
                divisionNavigationPage.BarTextColor = Colors.WhiteNormal;
                ((ContainerPage)App.Current.MainPage).Detail = divisionNavigationPage;
                _vm.ChangeSelection(item);
                listView.SelectedItem = null;
                ((ContainerPage)App.Current.MainPage).IsPresented = false;
            }
        }
    }
}
