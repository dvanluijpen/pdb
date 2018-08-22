using System;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Template
{
    public class PlayerDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Player180sTemplate { get; set; }
        public DataTemplate PlayerFinishesTemplate { get; set; }
        public DataTemplate PlayerRankingsTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Player180s)
                return Player180sTemplate;

            if (item is PlayerFinish)
                return PlayerFinishesTemplate;
            
            if (item is PlayerRanking)
                return PlayerRankingsTemplate;

            return null;
        }
    }
}
