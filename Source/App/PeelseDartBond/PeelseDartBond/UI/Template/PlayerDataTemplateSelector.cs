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
            if (item.GetType() == typeof(Player180s))
                return Player180sTemplate;

            if (item.GetType() == typeof(PlayerFinish))
                return PlayerFinishesTemplate;
            
            if (item.GetType() == typeof(PlayerRanking))
                return PlayerRankingsTemplate;

            return null;
        }
    }
}
