using System;
namespace PeelseDartBond.Model.Entities
{
    public class Competition : BaseEntity
    {
        string _name;
        string _rankings;
        string _schedule;
        string _results;
        string _matrix;
        string _playerRankings;
        string _player180s;
        string _playerFinishes;

        public Competition()
        {
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string Rankings
        {
            get { return _rankings; }
            set { SetProperty(ref _rankings, value); }
        }
        public string Schedule
        {
            get { return _schedule; }
            set { SetProperty(ref _schedule, value); }
        }
        public string Results
        {
            get { return _results; }
            set { SetProperty(ref _results, value); }
        }
        public string Matrix
        {
            get { return _matrix; }
            set { SetProperty(ref _matrix, value); }
        }
        public string PlayerRankings
        {
            get { return _playerRankings; }
            set { SetProperty(ref _playerRankings, value); }
        }
        public string Player180s
        {
            get { return _player180s; }
            set { SetProperty(ref _player180s, value); }
        }
        public string PlayerFinishes
        {
            get { return _playerFinishes; }
            set { SetProperty(ref _playerFinishes, value); }
        }
    }
}
