using System;
namespace PeelseDartBond.Model.Entities
{
    public class BasePlayer : BaseEntity
    {
        public string _name;
        public string _team;
        public string _teamUrl;

        public BasePlayer()
        {
        }

        public BasePlayer(string name, string team, string teamUrl)
        {
            Name = name;
            Team = team;
            TeamUrl = teamUrl;
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string Team
        {
            get { return _team; }
            set { SetProperty(ref _team, value); }
        }
        public string TeamUrl
        {
            get { return _teamUrl; }
            set { SetProperty(ref _teamUrl, value); }
        }
    }
}
