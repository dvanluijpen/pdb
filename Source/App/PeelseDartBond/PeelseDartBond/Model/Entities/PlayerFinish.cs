using System;
using Xamarin.Forms;
namespace PeelseDartBond.Model.Entities
{
    public class PlayerFinish : BasePlayer
    {
        public int _finish;

        public PlayerFinish()
        {
        }

        public int Finish
        {
            get { return _finish; }
            set { SetProperty(ref _finish, value); }
        }
    }
}
