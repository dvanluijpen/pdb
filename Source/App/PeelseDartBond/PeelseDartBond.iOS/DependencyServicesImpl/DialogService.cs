using System;
using System.Drawing;
using PeelseDartBond.DependencyServices;
using PeelseDartBond.iOS;
using PeelseDartBond.iOS.UI.Views;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogService_iOS))]
// How to use in Forms project: DependencyService.Get<IDialogService>().ShowProgressDialog(Strings.Ok);

namespace PeelseDartBond.iOS
{
    public class DialogService_iOS : IDialogService
    {
        static FormsDialog_iOS _formsDialog;

        public void HideProgressDialog()
        {
            _formsDialog?.Hide();
            _formsDialog = null;
        }

        public void ShowProgressDialog(string message)
        {
            if (_formsDialog != null)
            {
                HideProgressDialog();
            }

            var rootPage = UIApplication.SharedApplication.KeyWindow.RootViewController;
            var childPage = rootPage.PresentedViewController;

            var bounds = childPage != null ? childPage.View.Bounds : rootPage.View.Bounds;
            _formsDialog = new FormsDialog_iOS(new RectangleF((float)bounds.X, (float)bounds.Y, (float)bounds.Width, (float)bounds.Height), message);

            if (childPage != null)
            {
                childPage.View.Add(_formsDialog);
            }
            else
            {
                rootPage.View.Add(_formsDialog);
            }
        }
    }
}
