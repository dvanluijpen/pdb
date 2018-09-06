using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class TeamVM : BaseRefreshViewModel
    {
        Team _team;

        public TeamVM(Team team) : base()
        {
            Team = team;
        }

        public ICommand CloseCommand { get { return new Command(OnClose); } }

        public event EventHandler CloseRequested;

        public Team Team
        {
            get { return _team; }
            set { SetProperty(ref _team, value); }
        }

        public async override Task Load()
        {
            //throw new NotImplementedException();
        }

        private void OnClose() => CloseRequested?.Invoke(this, null);
    }
}
