using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.Entities
{
    public class Result180 : BaseEntity
    {
        string _player;
        int _amount;

        public Result180()
        {
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
    }
}
