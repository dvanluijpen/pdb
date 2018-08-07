using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class StringListEventArgs : System.EventArgs
    {
        readonly List<string> _items;

        public StringListEventArgs(List<string> items) : base()
        {
            _items = items;
        }

        public List<string> Items { get { return _items; } }
    }
}
