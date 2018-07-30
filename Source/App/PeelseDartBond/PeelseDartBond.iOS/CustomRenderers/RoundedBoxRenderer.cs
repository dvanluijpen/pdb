using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using CoreGraphics;
using PeelseDartBond.CustomRenderers;
using PeelseDartBond.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(RoundedBox), typeof(RoundedBoxRenderer))]

namespace PeelseDartBond.iOS.CustomRenderers
{
    public class RoundedBoxRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                Layer.MasksToBounds = true;
                UpdateCornerRadius(Element as RoundedBox);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBox.CornerRadiusProperty.PropertyName)
            {
                UpdateCornerRadius(Element as RoundedBox);
            }
        }

        void UpdateCornerRadius(RoundedBox box)
        {
            Layer.CornerRadius = Convert.ToInt32(box.CornerRadius) == 0
                ? (nfloat)(box.WidthRequest / 2) 
                : (nfloat)box.CornerRadius;
            //Layer.CornerRadius = (float)(box.WidthRequest / 2);
            Layer.BackgroundColor = box.BackgroundColor.ToCGColor();
            Layer.BorderColor = box.BorderColor.ToCGColor();
            Layer.BorderWidth = box.BorderWidth;
        }
    }
}