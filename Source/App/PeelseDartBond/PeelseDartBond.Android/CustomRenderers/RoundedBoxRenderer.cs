using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using PeelseDartBond.CustomRenderers;
using PeelseDartBond.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedBox), typeof(RoundedBoxRenderer))]
namespace PeelseDartBond.Droid.CustomRenderers
{
    public class RoundedBoxRenderer : BoxRenderer
    {
        public RoundedBoxRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            SetWillNotDraw(false);

            Invalidate();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBox.CornerRadiusProperty.PropertyName)
            {
                Invalidate();
            }
        }

        public override void Draw(Canvas canvas)
        {
            var box = Element as RoundedBox;
            var rect = new Rect();
            var paint = new Paint()
            {
                Color = box.BackgroundColor.ToAndroid(),
                AntiAlias = true,
            };

            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = box.BorderWidth;
            paint.Color = box.BorderColor.ToAndroid();

            GetDrawingRect(rect);

            var radius = Convert.ToInt32(box.CornerRadius) == 0
                                ? (float)(box.Width / 2) 
                                : (float)(rect.Width() / box.Width * box.CornerRadius);

            canvas.DrawRoundRect(new RectF(rect), radius, radius, paint);
        }
    }
}