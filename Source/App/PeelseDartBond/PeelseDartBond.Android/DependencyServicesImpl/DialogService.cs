using Android.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using System;
using PeelseDartBond.Droid.DependencyServicesImpl;
using Xamarin.Forms;
using PeelseDartBond.DependencyServices;
using Android.Content;

[assembly: Dependency (typeof (DialogService_Droid))]
// How to use in Forms project: DependencyService.Get<IDialogService>().ShowProgressDialog(Strings.Ok);

namespace PeelseDartBond.Droid.DependencyServicesImpl
{
    public class DialogService_Droid : IDialogService
    {
        static Dialog _dialog;
        Context _context;

        public DialogService_Droid(Context context)
        {
            _context = context;
        }

        public void HideProgressDialog()
        {
            if (_dialog != null)
            {
                _dialog.Hide();
                _dialog = null;
            }
        }

        public void ShowProgressDialog(string message)
        {
            if (_dialog != null)
            {
                HideProgressDialog();
            }

            _dialog = new Dialog(_context);
            _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
            _dialog.SetCancelable(false);
            _dialog.SetCanceledOnTouchOutside(false);

            Window window = _dialog.Window;
            window.SetLayout(WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.MatchParent);
            window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));

            _dialog.SetContentView(Resource.Layout.FormsDialog_Droid);

            var textView = (TextView)_dialog.FindViewById(Resource.Id._tvLabel);
            textView.Text = message;

            _dialog.Show();
        }
    }
}
