using PeelseDartBond.Services;
using PeelseDartBond.UI.Page;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PeelseDartBond
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<NavigationService, NavigationService>();
            DependencyService.Register<PdbService, PdbService>();
            MainPage = new ContainerPage();
        }
    }
}
