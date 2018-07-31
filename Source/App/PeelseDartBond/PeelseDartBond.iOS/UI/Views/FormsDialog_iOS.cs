using System;
using System.Drawing;
using UIKit;

namespace PeelseDartBond.iOS.UI.Views
{
    public class FormsDialog_iOS : UIView
    {
        UIActivityIndicatorView _aivDialog;
        UILabel _lblDialog;

        public FormsDialog_iOS(RectangleF frame, string message) : base(frame)
        {
            BackgroundColor = UIColor.Black;
            Alpha = 0.60f;
            AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

            float labelHeight = 22;
            float labelWidth = (float)frame.Width / 2;

            float centerX = (float)Frame.Width / 2;
            float centerY = (float)Frame.Height / 2;

            _aivDialog = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            _aivDialog.Frame = new RectangleF(
                centerX - ((float)_aivDialog.Frame.Width / 2),
                centerY - (float)_aivDialog.Frame.Height - 20,
                (float)_aivDialog.Frame.Width,
                (float)_aivDialog.Frame.Height);

            _aivDialog.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;

            AddSubview(_aivDialog);

            _aivDialog.StartAnimating();

            _lblDialog = new UILabel(new RectangleF(
                centerX - (labelWidth / 2),
                centerY + 20,
                labelWidth,
                labelHeight));

            _lblDialog.BackgroundColor = UIColor.Clear;
            _lblDialog.TextColor = UIColor.White;
            _lblDialog.Text = message;
            _lblDialog.TextAlignment = UITextAlignment.Center;
            _lblDialog.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;

            AddSubview(_lblDialog);
        }

        public void Hide()
        {
            Animate(
                0.5,
                () => { Alpha = 0; },
                () => { RemoveFromSuperview(); }
            );
        }
    }
}
