using System;
namespace PeelseDartBond.Model.Entities
{
    public class News : BaseEntity
    {
        string _title;
        string _text;
        DateTime _date;

        public News()
        {
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
    }
}
