using System;
using System.Collections.Generic;
using PeelseDartBond.Constants;
using PeelseDartBond.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavigationPageRenderer))] //Custom renderer to set left toolbar item and custom font for title

namespace PeelseDartBond.iOS.CustomRenderers
{
    public class NavigationPageRenderer : NavigationRenderer
    {
        public override void PushViewController(UIViewController viewController, bool animated)
        {
            base.PushViewController(viewController, animated);

            if (TopViewController.NavigationItem.RightBarButtonItems.Length == 2)
            { //2 navigation bar buttons found - so align one item on the left side and one item on the right side
                if (viewController.NavigationItem.Title == "Instellingen")
                {
                    List<UIBarButtonItem> leftButtons = new List<UIBarButtonItem>();
                    leftButtons.Add(TopViewController.NavigationItem.RightBarButtonItems[0]);
                    TopViewController.NavigationItem.LeftBarButtonItems = leftButtons.ToArray();

                    List<UIBarButtonItem> rightButtons = new List<UIBarButtonItem>();
                    rightButtons.Add(TopViewController.NavigationItem.RightBarButtonItems[1]);
                    TopViewController.NavigationItem.RightBarButtonItems = rightButtons.ToArray();
                }
                else
                {
                    List<UIBarButtonItem> leftButtons = new List<UIBarButtonItem>();
                    leftButtons.Add(TopViewController.NavigationItem.RightBarButtonItems[1]);
                    TopViewController.NavigationItem.LeftBarButtonItems = leftButtons.ToArray();

                    List<UIBarButtonItem> rightButtons = new List<UIBarButtonItem>();
                    rightButtons.Add(TopViewController.NavigationItem.RightBarButtonItems[0]);
                    TopViewController.NavigationItem.RightBarButtonItems = rightButtons.ToArray();
                }
            }

            //Remove text from back button
            TopViewController.NavigationItem.BackBarButtonItem = new UIBarButtonItem(" ", UIBarButtonItemStyle.Plain, null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Set custom font and font color for navigation bar title
            this.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = Colors.WhiteNormal.ToUIColor()
            };

            //Set navigation bar item color (button)
            this.NavigationBar.TintColor = Colors.WhiteNormal.ToUIColor();
            this.NavigationBar.BarTintColor = Colors.GreenDark.ToUIColor();
        }
    }
}
