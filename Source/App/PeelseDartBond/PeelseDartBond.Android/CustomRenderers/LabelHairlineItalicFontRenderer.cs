using Android.App;
using Android.Widget;
using Android.Graphics;

using Xamarin.Forms.Platform.Android;

using PeelseDartBond.CustomRenderers;
using PeelseDartBond.Droid.CustomRenderers;
using Android.Content;

[assembly: Xamarin.Forms.ExportRenderer (typeof(LabelHairlineItalicFont), typeof(LabelHairlineItalicFontRenderer))]

namespace PeelseDartBond.Droid.CustomRenderers
{
    public class LabelHairlineItalicFontRenderer : LabelRenderer
    {
        public LabelHairlineItalicFontRenderer(Context context) : base(context)
        {
            
        }

        Typeface _typeFace = Typeface.CreateFromAsset(Application.Context.Assets, "Lato-HairlineItalic.ttf");

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var nativeTextView = (TextView)Control;

            nativeTextView.SetTypeface(_typeFace, TypefaceStyle.Normal);
        }
    }
}