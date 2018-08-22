using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.Content.Res;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PeelseDartBond.CustomRenderers;
using PeelseDartBond.Droid.CustomRenderers;

[assembly: ExportRenderer (typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace PeelseDartBond.Droid.CustomRenderers
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        public HtmlLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                var view = (HtmlLabel)Element;
                var htmlText = Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.N
                                      ? Html.FromHtml(view.Text.ToString(), FromHtmlOptions.ModeLegacy)
                                      : Html.FromHtml(view.Text.ToString());

                //Control.SetTypeface(Typeface.CreateFromAsset(Android.App.Application.Context.Assets, Fonts.WeightRegularDroid), TypefaceStyle.Normal);
                Control.SetText(htmlText, TextView.BufferType.Spannable);
                Control.SetMaxLines(view.MaxLines);
            }
        }
    }
}
