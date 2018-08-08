using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PeelseDartBond.CustomRenderers;
using PeelseDartBond.iOS.CustomRenderers;

[assembly: ExportRenderer (typeof (LabelLightItalicFont), typeof (LabelLightItalicFontRenderer))]

namespace PeelseDartBond.iOS.CustomRenderers
{
    public class LabelLightItalicFontRenderer : LabelRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var nativeLabel = (UILabel)Control;
            nativeLabel.Font = UIFont.FromName("Lato-LightItalic", nativeLabel.Font.PointSize);
        }
    }
}