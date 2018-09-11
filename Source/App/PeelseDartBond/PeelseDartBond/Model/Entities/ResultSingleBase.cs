using System;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.Model.Entities
{
    public class ResultSingleBase : BaseEntity
    {
        int _position;
        string _home;
        string _away;
        string _score;
        string _headerText;

        public ResultSingleBase()
        {
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        public string Home
        {
            get { return _home; }
            set { SetProperty(ref _home, value); }
        }
        public string Away
        {
            get { return _away; }
            set { SetProperty(ref _away, value); }
        }
        public string Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }
        public string HomeScore
        {
            get { return _score.Substring(0, 1); }
        }
        public string AwayScore
        {
            get { return _score.Substring(_score.Length-1, 1); }
        }
        public MatchResultType HomeResult
        {
            get
            {
                return HomeScore.ToInt() == AwayScore.ToInt()
                    ? MatchResultType.Draw
                    : HomeScore.ToInt() > AwayScore.ToInt()
                        ? MatchResultType.Win
                        : MatchResultType.Lose;
            }
        }
        public MatchResultType AwayResult
        {
            get
            {
                return AwayScore.ToInt() == HomeScore.ToInt()
                    ? MatchResultType.Draw
                    : AwayScore.ToInt() > HomeScore.ToInt()
                        ? MatchResultType.Win
                        : MatchResultType.Lose;
            }
        }
    }
}
