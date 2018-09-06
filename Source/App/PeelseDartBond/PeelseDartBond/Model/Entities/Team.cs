using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.Entities
{
    public class Team : BaseEntity
    {
        int _position;
        string _name;
        string _url;
        string _division;
        List<Player> _players;

        public Team()
        {
            Players = new List<Player>();
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
        public string Division
        {
            get { return _division; }
            set { SetProperty(ref _division, value); }
        }
        public List<Player> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }
    }
}
