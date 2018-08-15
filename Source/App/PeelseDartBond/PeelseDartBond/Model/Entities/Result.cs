using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.Entities
{
    public class Result : BaseEntity
    {
        string _teamHome;
        string _teamAway;
        string _score;
        List<ResultSingle> _singles;
        List<ResultDouble> _doubles;
        List<ResultCaptain> _captains;
        List<ResultTeam> _teams;
        List<Result180> _player180s;
        List<ResultFinish> _playerFinishes;

        public Result()
        {
        }

        public string TeamHome
        {
            get { return _teamHome; }
            set { SetProperty(ref _teamHome, value); }
        }
        public string TeamAway
        {
            get { return _teamAway; }
            set { SetProperty(ref _teamAway, value); }
        }
        public string Score
        {
            get { return _score; }
            set { SetProperty(ref _score, value); }
        }
        public List<ResultSingle> Singles
        {
            get { return _singles; }
            set { SetProperty(ref _singles, value); }
        }
        public List<ResultDouble> Doubles
        {
            get { return _doubles; }
            set { SetProperty(ref _doubles, value); }
        }
        public List<ResultCaptain> Captains
        {
            get { return _captains; }
            set { SetProperty(ref _captains, value); }
        }
        public List<ResultTeam> Teams
        {
            get { return _teams; }
            set { SetProperty(ref _teams, value); }
        }
        public List<Result180> Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }
        public List<ResultFinish> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
        }
    }
}
