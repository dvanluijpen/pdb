using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.Model.Entities
{
    public class Group<T> : ObservableCollection<T>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public Group(string longName, string shortName)
        {
            LongName = longName;
            ShortName = shortName;
        }

        public Group(List<T> list)
        {
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public Group(string longName, string shortName, IEnumerable<T> list)
        {
            LongName = longName;
            ShortName = shortName;

            foreach (var item in list)
            {
                Add(item);
            }
        }
    }
}
