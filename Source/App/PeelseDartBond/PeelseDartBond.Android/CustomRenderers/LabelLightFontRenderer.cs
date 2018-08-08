using Android.App;
using Android.Widget;
using Android.Graphics;

using Xamarin.Forms.Platform.Android;

using PeelseDartBond.CustomRenderers;
using PeelseDartBond.Droid.CustomRenderers;
using Android.Content;

[assembly: Xamarin.Forms.ExportRenderer (typeof(LabelLightFont), typeof(LabelLightFontRenderer))]

namespace PeelseDartBond.Droid.CustomRenderers
{
    public class LabelLightFontRenderer : LabelRenderer
    {
        public LabelLightFontRenderer(Context context) : base(context)
        {
            
        }

        Typeface _typeFace = Typeface.CreateFromAsset(Application.Context.Assets, "Lato-Light.ttf");

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var nativeTextView = (TextView)Control;

            nativeTextView.SetTypeface(_typeFace, TypefaceStyle.Normal);
        }
    }
}