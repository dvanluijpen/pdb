using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Exceptions;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class DivisionVM : BaseViewModel
    {
        string _division;

        public DivisionVM() : base()
        {
            Division = PdbService.SelectedCompetition?.Name ?? string.Empty;

            PdbService.SelectedCompetitionChanged -= OnCompetitionChanged;
            PdbService.SelectedCompetitionChanged += OnCompetitionChanged;
        }

        public string Division
        {
            get { return _division; }
            set { SetProperty(ref _division, value); }
        }

        async void OnCompetitionChanged(object sender, CompetitionEventArgs e)
        {
            if (e.Competition.IsNullOrEmpty())
                return;

            Division = e.Competition.Name;

            try
            {
                Device.BeginInvokeOnMainThread(() => DialogService.ShowProgressDialog("Bezig met laden..."));
                await PdbService.GetCompetitionData();
            }
            catch (ConnectivityException ex)
            {
                Logger.Error("Connectivity Issue", ex);
                await ShowNoConnectionError();
            }
            catch (Exception ex)
            {
                Logger.Error("Other Exception", ex);
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() => DialogService.HideProgressDialog());
            }
        }
    }
}
