using System;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Template
{
    public class ResultDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ResultSingleTemplate { get; set; }
        public DataTemplate ResultSingleWithHeaderTemplate { get; set; }
        public DataTemplate ResultDoubleTemplate { get; set; }
        public DataTemplate ResultDoubleWithHeaderTemplate { get; set; }
        public DataTemplate Result180sTemplate { get; set; }
        public DataTemplate Result180sWithHeaderTemplate { get; set; }
        public DataTemplate ResultFinishesTemplate { get; set; }
        public DataTemplate ResultFinishesWithHeaderTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ResultSingleBase)
                return ((ResultSingleBase)item).Position == 1 ? ResultSingleWithHeaderTemplate : ResultSingleTemplate; 

            if (item is ResultDouble)
                return ((ResultDouble)item).Position == 1 ? ResultDoubleWithHeaderTemplate : ResultDoubleTemplate; 

            if (item is Result180)
                return ((Result180)item).Position == 1 ? Result180sWithHeaderTemplate : Result180sTemplate; 

            if (item is ResultFinish)
                return ((ResultFinish)item).Position == 1 ? ResultFinishesWithHeaderTemplate : ResultFinishesTemplate; 
            
            return null;
        }
    }
}
