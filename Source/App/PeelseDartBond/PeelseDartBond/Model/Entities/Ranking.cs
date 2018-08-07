using System;
using Xamarin.Forms;

namespace PeelseDartBond.Model.Entities
{
    public class Ranking : BaseEntity
    {
        int _position;
        string _team;
        string _teamUrl;
        int _played;
        int _won;
        int _draw;
        int _lost;
        int _points;
        string _penalties;
        int _matchPoints;
        decimal _averagePoints;
        string _status;

        public Ranking()
        {
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
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
        public int Draw
        {
            get { return _draw; }
            set { SetProperty(ref _draw, value); }
        }
        public int Lost
        {
            get { return _lost; }
            set { SetProperty(ref _lost, value); }
        }
        public int Points
        {
            get { return _points; }
            set { SetProperty(ref _points, value); }
        }
        public string Penalties
        {
            get { return _penalties; }
            set { SetProperty(ref _penalties, value); }
        }
        public int MatchPoints
        {
            get { return _matchPoints; }
            set { SetProperty(ref _matchPoints, value); }
        }
        public decimal AveragePoints
        {
            get { return _averagePoints; }
            set { SetProperty(ref _averagePoints, value); }
        }
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public ImageSource StatusImage
        {
            get { return string.IsNullOrEmpty(Status) ? ImageSource.FromFile("") : Status.ToLower() == "confirmed" ? ImageSource.FromFile("CheckmarkGreen.png") : ImageSource.FromFile("CheckmarkYellow.png"); }
        }
        public string PlayedTotals
        {
            get { return $"Gespeeld: {Played} ({Won}-{Draw}-{Lost})"; }
        }
    }
}
