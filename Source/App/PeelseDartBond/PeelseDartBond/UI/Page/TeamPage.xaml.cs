using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class TeamPage : ContentPage
    {
        TeamVM _vm;

        public TeamPage(Team team)
        {
            InitializeComponent();

            _vm = new TeamVM(team);
            BindingContext = _vm;
        }

        public TeamVM ViewModel { get { return _vm; } }
    }
}
