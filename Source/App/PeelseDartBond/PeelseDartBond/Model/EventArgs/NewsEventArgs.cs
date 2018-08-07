using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class NewsEventArgs : System.EventArgs
    {
        readonly List<News> _news;

        public NewsEventArgs(List<News> news) : base()
        {
            _news = news;
        }

        public List<News> News { get { return _news; } }
    }
}
