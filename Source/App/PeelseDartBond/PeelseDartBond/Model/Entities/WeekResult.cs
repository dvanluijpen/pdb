using System;
namespace PeelseDartBond.Model.Entities
{
    public class WeekResult : BaseEntity
    {
        string _matchUrl;
        int _week;
        string _teamHome;
        string _teamHomeUrl;
        string _teamAway;
        string _teamAwayUrl;
        string _result;
        int _resultHome;
        int _resultAway;
        string _status;

        public WeekResult()
        {
        }

        public string MatchUrl
        {
            get { return _matchUrl; }
            set { SetProperty(ref _matchUrl, value); }
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
        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }
        public int ResultHome
        {
            get { return _resultHome; }
            set { SetProperty(ref _resultHome, value); }
        }
        public int ResultAway
        {
            get { return _resultAway; }
            set { SetProperty(ref _resultAway, value); }
        }
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
    }
}
