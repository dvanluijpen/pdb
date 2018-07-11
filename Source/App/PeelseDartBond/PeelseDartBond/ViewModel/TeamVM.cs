using System;
using System.Threading.Tasks;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.ViewModel
{
    public class TeamVM : BaseRefreshViewModel
    {
        Team _team;

        public TeamVM(Team team) : base()
        {
            _team = team;
        }

        public async override Task Load()
        {
            throw new NotImplementedException();
        }
    }
}
