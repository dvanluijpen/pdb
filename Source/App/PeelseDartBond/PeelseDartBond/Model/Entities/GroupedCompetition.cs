using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PeelseDartBond.Model.Entities
{
    public class GroupedCompetition : ObservableCollection<Competition>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public GroupedCompetition(string longName, string shortName)
        {
            LongName = longName;
            ShortName = shortName;
        }
    }
}
