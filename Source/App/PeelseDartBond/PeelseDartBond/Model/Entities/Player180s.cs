using System;
using Xamarin.Forms;
namespace PeelseDartBond.Model.Entities
{
    public class Player180s : BasePlayer
    {
        public int _amount;

        public Player180s()
        {
        }

        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
    }
}
