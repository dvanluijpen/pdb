using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeelseDartBond.Constants;
using PeelseDartBond.DependencyServices;
using Xamarin.Forms;

namespace PeelseDartBond.Services
{
    public class NavigationService
    {
        static bool _isMasterDetailPageAndTablet = false;

        public static IDeviceService DeviceService
        {
            get
            {
                return DependencyService.Get<IDeviceService>();
            }
        }

        public static Page CurrentModalPage
        {
            get
            {
                return CurrentMainPage.Navigation.ModalStack.Count > 0 ? CurrentMainPage.Navigation.ModalStack.LastOrDefault() : null;
            }
        }

        public static Page CurrentMainPage
        {
            get
            {
                _isMasterDetailPageAndTablet = false;

                if (Application.Current.MainPage is TabbedPage)
                {
                    var currentMainPage = (TabbedPage)Application.Current.MainPage;
                    return currentMainPage.CurrentPage;
                }

                if (Application.Current.MainPage is MasterDetailPage)
                {
                    var currentMainPage = (MasterDetailPage)Application.Current.MainPage;

                    if (DeviceService.IsTablet)
                    {
                        _isMasterDetailPageAndTablet = true;
                        return currentMainPage;
                    }

                    return currentMainPage.Detail;
                }

                return Application.Current.MainPage;
            }
        }

        public async Task GoToPage(Page page, bool animate = true, bool addToNavigationStackMasterPage = false, bool addToNavigationStackDetailPage = false)
        {
            var currentPage = CurrentModalPage;

            if (currentPage == null || currentPage.GetType() != typeof(NavigationPage))
            {
                currentPage = CurrentMainPage;
            }

            if (_isMasterDetailPageAndTablet)
            {
                var currentMasterDetailPage = (MasterDetailPage)currentPage;

                if (addToNavigationStackMasterPage)
                {
                    await currentMasterDetailPage.Master.Navigation.PushAsync(page, animate);

                    // reset detail page to a black page
                    var navigationPage = new NavigationPage(new ContentPage());
                    currentMasterDetailPage.Detail = navigationPage;
                }
                else if (addToNavigationStackDetailPage)
                {
                    await currentMasterDetailPage.Detail.Navigation.PushAsync(page, animate);
                }
                else
                {
                    var navigationPage = new NavigationPage(page);
                    currentMasterDetailPage.Detail = navigationPage;
                }
            }
            else
            {
                await currentPage.Navigation.PushAsync(page, animate);
            }
        }

        public async Task GoToModalPage(Page page, bool animate = true)
        {
            await CurrentMainPage.Navigation.PushModalAsync(page, animate);
        }

        public async Task PopCurrentModalPage(bool animate = true)
        {
            if (CurrentModalPage != null)
            {
                await CurrentModalPage.Navigation.PopModalAsync(animate);
            }
        }

        public async Task PopCurrentPage(bool animate = true)
        {
            if (CurrentMainPage != null)
            {
                await CurrentMainPage.Navigation.PopAsync(animate);
            }
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            var currentPage = CurrentModalPage ?? CurrentMainPage;

            if (currentPage != null)
            {
                await currentPage.DisplayAlert(title, message, cancel);
            }
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var currentPage = CurrentModalPage ?? CurrentMainPage;

            if (currentPage != null)
            {
                return await currentPage.DisplayAlert(title, message, accept, cancel);
            }

            return false;
        }

        public async Task<string> DisplayActionSheet(string title, List<string> actions)
        {
            var currentPage = CurrentModalPage ?? CurrentMainPage;

            if (currentPage != null)
            {
                return await currentPage.DisplayActionSheet(title, Strings.Cancel, null, actions?.ToArray());
            }

            return Strings.Cancel;
        }
    }
}
