using System;
namespace PeelseDartBond.Model.Entities
{
    public class Team : BaseEntity
    {
        int _position;

        public Team()
        {
        }

        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
    }
}
