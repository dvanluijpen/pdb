using System;
using Xamarin.Forms;

namespace PeelseDartBond.Model.Entities
{
    public class BasePlayer : BaseEntity
    {
        public int _position;
        public string _name;
        public string _team;
        public string _teamUrl;
        public string _status;

        public BasePlayer()
        {
        }

        public BasePlayer(string name, string team, string teamUrl)
        {
            Position = 1;
            Name = name;
            Team = team;
            TeamUrl = teamUrl;
            Status = "confirmed";
        }

        public BasePlayer(int position, string name, string team, string teamUrl, string status)
        {
            Position = position;
            Name = name;
            Team = team;
            TeamUrl = teamUrl;
            Status = status;
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
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        public ImageSource StatusImage
        {
            get { return Status.ToLower() == "confirmed" ? ImageSource.FromFile("CheckmarkGreen.png") : ImageSource.FromFile("CheckmarkYellow.png"); }
        }
    }
}
