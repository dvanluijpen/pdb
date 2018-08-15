using System;
using Newtonsoft.Json;

namespace PeelseDartBond.Model.Entities
{
    public class ResultFinish : BaseEntity
    {
        string _player;
        string _finish;

        public ResultFinish()
        {
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
    }
}
