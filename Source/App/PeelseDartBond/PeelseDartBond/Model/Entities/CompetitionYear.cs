using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.Entities
{
    public class CompetitionYear : BaseEntity
    {
        string _url;
        string _title;
        List<Competition> _competitions;

        public CompetitionYear()
        {
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public List<Competition> Competitions
        {
            get { return _competitions; }
            set { SetProperty(ref _competitions, value); }
        }
    }
}
