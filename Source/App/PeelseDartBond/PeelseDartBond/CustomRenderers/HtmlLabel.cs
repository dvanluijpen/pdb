using System;
using Xamarin.Forms;

namespace PeelseDartBond.CustomRenderers
{
    public class HtmlLabel : Label
    {
        public HtmlLabel()
        {
        }

        public int MaxLines { get; set; }
    }
}
