using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;
using PeelseDartBond.Utilities;

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

        void OnCompetitionChanged(object sender, CompetitionEventArgs e)
        {
            if (e.Competition.IsNullOrEmpty())
                return;
            
            Division = e.Competition.Name;
        }
    }
}
