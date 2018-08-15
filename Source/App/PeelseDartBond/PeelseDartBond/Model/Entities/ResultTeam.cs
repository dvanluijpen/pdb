using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.Entities
{
    public class ResultTeam : BaseEntity
    {
        int _position;
        string _home;
        string _away;
        string _score;

        public ResultTeam()
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
    }
}
