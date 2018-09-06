using System;
using Xamarin.Forms;
namespace PeelseDartBond.Model.Entities
{
    public class PlayerRanking : BasePlayer
    {
        public int _played;
        public int _won;
        public decimal _percentage;

        public PlayerRanking()
        {
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
    }
}
