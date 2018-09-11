using System;
using Newtonsoft.Json;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.Model.Entities
{
    public class ResultDouble : BaseEntity
    {
        int _position;
        string _home1;
        string _home2;
        string _away1;
        string _away2;
        string _score;
        string _headerText;

        public ResultDouble()
        {
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        public string Home1
        {
            get { return _home1; }
            set { SetProperty(ref _home1, value); }
        }
        public string Home2
        {
            get { return _home2; }
            set { SetProperty(ref _home2, value); }
        }
        public string Away1
        {
            get { return _away1; }
            set { SetProperty(ref _away1, value); }
        }
        public string Away2
        {
            get { return _away2; }
            set { SetProperty(ref _away2, value); }
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
            get { return _score.Substring(_score.Length - 1, 1); }
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
