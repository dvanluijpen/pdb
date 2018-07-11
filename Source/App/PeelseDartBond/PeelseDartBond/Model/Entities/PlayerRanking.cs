using System;
namespace PeelseDartBond.Model.Entities
{
    public class PlayerRanking : BaseEntity
    {
        public int _position;
        public string _name;
        public string _team;
        public string _teamUrl;
        public int _played;
        public int _won;
        public decimal _percentage;
        public string _status;

        public PlayerRanking()
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
        public int Played
        {
            get { return _played; }
            set { SetProperty(ref _played, value); }
        }
        public int Won
        {
            get { return _won; }
            set { SetProperty(ref _won, value); }
        }
        public decimal Percentage
        {
            get { return _percentage; }
            set { SetProperty(ref _percentage, value); }
        }
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
    }
}
