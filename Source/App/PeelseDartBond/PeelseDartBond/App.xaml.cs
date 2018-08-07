using System.Threading.Tasks;
using PeelseDartBond.DependencyServices;
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

            RegisterDependencyServices();
            InitializeData();
            SetMainPage();
        }

        private void RegisterDependencyServices()
        {
            DependencyService.Register<NavigationService, NavigationService>();
        }

        private void InitializeData()
        {
            PdbService.Instance.Initialize();
        }

        private void SetMainPage()
        {
            MainPage = new ContainerPage();
        }
    }
}
