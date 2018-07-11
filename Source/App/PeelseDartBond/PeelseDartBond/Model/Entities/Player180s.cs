using System;
namespace PeelseDartBond.Model.Entities
{
    public class Player180s : BaseEntity
    {
        public int _position;
        public string _name;
        public string _team;
        public string _teamUrl;
        public int _amount;
        public string _status;

        public Player180s()
        {
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
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
        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
    }
}
