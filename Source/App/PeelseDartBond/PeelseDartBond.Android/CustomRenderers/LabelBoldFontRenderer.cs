﻿using Android.App;
using Android.Widget;
using Android.Graphics;

using Xamarin.Forms.Platform.Android;

using PeelseDartBond.CustomRenderers;
using PeelseDartBond.Droid.CustomRenderers;
using Android.Content;

[assembly: Xamarin.Forms.ExportRenderer (typeof(LabelBoldFont), typeof(LabelBoldFontRenderer))]

namespace PeelseDartBond.Droid.CustomRenderers
{
    public class LabelBoldFontRenderer : LabelRenderer
    {
        public LabelBoldFontRenderer(Context context) : base(context)
        {
            
        }

        Typeface _typeFace = Typeface.CreateFromAsset(Application.Context.Assets, "Lato-Bold.ttf");

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var nativeTextView = (TextView)Control;

            nativeTextView.SetTypeface(_typeFace, TypefaceStyle.Normal);
        }
    }
}