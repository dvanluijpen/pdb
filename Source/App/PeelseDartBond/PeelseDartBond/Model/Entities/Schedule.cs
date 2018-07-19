using System;
namespace PeelseDartBond.Model.Entities
{
    public class Schedule : BaseEntity
    {
        string _matchDay;
        DateTime _matchDate;
        int _week;
        string _teamHome;
        string _teamHomeUrl;
        string _teamAway;
        string _teamAwayUrl;

        public Schedule()
        {
        }

        public string MatchDay
        {
            get { return _matchDay; }
            set { SetProperty(ref _matchDay, value); }
        }
        public DateTime MatchDate
        {
            get { return _matchDate; }
            set { SetProperty(ref _matchDate, value); }
        }
        public int Week
        {
            get { return _week; }
            set { SetProperty(ref _week, value); }
        }
        public string TeamHome
        {
            get { return _teamHome; }
            set { SetProperty(ref _teamHome, value); }
        }
        public string TeamHomeUrl
        {
            get { return _teamHomeUrl; }
            set { SetProperty(ref _teamHomeUrl, value); }
        }
        public string TeamAway
        {
            get { return _teamAway; }
            set { SetProperty(ref _teamAway, value); }
        }
        public string TeamAwayUrl
        {
            get { return _teamAwayUrl; }
            set { SetProperty(ref _teamAwayUrl, value); }
        }
    }
}
