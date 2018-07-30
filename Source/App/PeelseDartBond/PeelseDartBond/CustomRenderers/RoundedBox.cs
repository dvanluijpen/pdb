using System;
using PeelseDartBond.Constants;
using Xamarin.Forms;

namespace PeelseDartBond.CustomRenderers
{
    public class RoundedBox : BoxView
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(RoundedBox), default(double));
        public static readonly BindableProperty SizeRequestProperty =
            BindableProperty.Create(nameof(SizeRequest), typeof(double), typeof(RoundedBox), default(double));
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(RoundedBox), default(int));
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(RoundedBox), Colors.Gray1);
        
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public double SizeRequest
        {
            get { return (double)GetValue(SizeRequestProperty); }
            set { SetValue(SizeRequestProperty, value); }
        }
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
