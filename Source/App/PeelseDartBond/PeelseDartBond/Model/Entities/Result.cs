﻿using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Types;
using PeelseDartBond.Utilities;

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
        public List<object> All
        {
            get
            {
                var all = new List<object>();
                all.AddRange(Singles);
                all.AddRange(Doubles);
                all.AddRange(Captains);
                all.AddRange(Teams);
                all.AddRange(Player180s);
                all.AddRange(PlayerFinishes);
                return all;
            }
        }
        public string TeamHomeScore
        {
            get { return _score.Substring(0, 1); }
        }
        public string TeamAwayScore
        {
            get { return _score.Substring(_score.Length - 1, 1); }
        }
        public MatchResultType TeamHomeResult
        {
            get 
            {
                return TeamHomeScore.ToInt() == TeamAwayScore.ToInt()
                    ? MatchResultType.Draw
                    : TeamHomeScore.ToInt() > TeamAwayScore.ToInt()
                        ? MatchResultType.Win
                        : MatchResultType.Lose;
            }
        }
        public MatchResultType TeamAwayResult
        {
            get
            {
                return TeamAwayScore.ToInt() == TeamHomeScore.ToInt()
                    ? MatchResultType.Draw
                    : TeamAwayScore.ToInt() > TeamHomeScore.ToInt()
                        ? MatchResultType.Win
                        : MatchResultType.Lose;
            }
        }
    }
}
