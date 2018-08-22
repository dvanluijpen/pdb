using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.Entities
{
    public class ResultFinish : BaseEntity
    {
        int _position;
        string _player;
        string _finish;
        string _headerText;

        public ResultFinish()
        {
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        public string Player
        {
            get { return _player; }
            set { SetProperty(ref _player, value); }
        }
        public string Finish
        {
            get { return _finish; }
            set { SetProperty(ref _finish, value); }
        }
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }
    }
}
