using System;
using System.Windows.Input;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.ViewModel
{
    public class PlayerVM : BaseViewModel
    {
        Player _player;

        public PlayerVM(Player player)
        {
            Player = player;
        }

        public ICommand CloseCommand { get { return new Command(OnClose); } }

        public event EventHandler CloseRequested;

        public Player Player
        {
            get { return _player; }
            set { SetProperty(ref _player, value); }
        }

        private void OnClose() => CloseRequested?.Invoke(this, null);
    }
}
