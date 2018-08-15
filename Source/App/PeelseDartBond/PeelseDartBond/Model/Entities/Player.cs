using System;
using System.Collections.Generic;
using System.Linq;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.Model.Entities
{
    public class Player : BaseEntity
    {
        public int _positionRanking;
        public int _position180s;
        public int _positionFinishes;
        public string _name;
        public string _team;
        public string _teamUrl;
        public int _player180s;
        public List<int> _playerFinishes;
        public int _played;
        public int _won;
        public decimal _percentage;

        public Player()
        {
        }

        public int PositionRanking
        {
            get { return _positionRanking; }
            set { SetProperty(ref _positionRanking, value); }
        }
        public int Position180s
        {
            get { return _position180s; }
            set { SetProperty(ref _position180s, value); }
        }
        public int PositionFinishes
        {
            get { return _positionFinishes; }
            set { SetProperty(ref _positionFinishes, value); }
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
        public int Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }
        public List<int> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
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
        public int PlayerHighestFinish
        {
            get { return PlayerFinishes.Max(); }
        }
        public string TextRank
        {
            get { return $"Staat {PositionRanking}e in het klassement"; }
        }
        public string Text180s
        {
            get { return $"Heeft {Player180s} 180ers"; }
        }
        public string TextFinishes
        {
            get 
            { 
                if(PlayerFinishes.IsNullOrEmpty())
                    return $"En heeft geen hoge finishes";

                var finishesText = "En deze hoge finishes:\n";
                var playerFinishes = PlayerFinishes.OrderByDescending(f => f);
                foreach(var finish in playerFinishes)
                {
                    finishesText += $"{finish}\n";
                }

                return finishesText; 
            }
        }
    }
}
