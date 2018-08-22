using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.Entities
{
    public class Result180 : BaseEntity
    {
        int _position;
        string _player;
        int _amount;
        string _headerText;

        public Result180()
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
        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }
    }
}
