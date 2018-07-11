using System;
using System.Collections.Generic;
using System.IO;
//using Plugin.Connectivity;
//using Plugin.Connectivity.Abstractions;
using Foundation;
using PeelseDartBond.DependencyServices;
using PeelseDartBond.iOS.DependencyServicesImpl;
using UIKit;
using Xamarin.Forms;
using System.Diagnostics;

[assembly: Dependency(typeof(DeviceService_iOS))]
// How to use in Forms project: DependencyService.Get<IDeviceService>().IsPhone

namespace PeelseDartBond.iOS.DependencyServicesImpl
{
    public class DeviceService_iOS : IDeviceService
    {
        public DeviceService_iOS()
        {
        }

        public bool IsTablet { get { return Device.Idiom == TargetIdiom.Tablet; } }
        public bool IsPhone { get { return Device.Idiom == TargetIdiom.Phone; } }

        public bool IsIos { get { return true; } }
        public bool IsAndroid { get { return false; } }
        public bool IsWindows { get { return false; } }

        public string OsVersion { get { return UIDevice.CurrentDevice.SystemVersion; } }
        public string AppVersion { get { return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString(); } }

        //public bool IsConnected { get { return CrossConnectivity.Current.IsConnected; } }
        //public IEnumerable<ConnectionType> ConnectionTypes { get { return CrossConnectivity.Current.ConnectionTypes; } }

        public string DocumentsPath
        {
            get
            {
                var documentsPath = string.Empty;

                // Documents directory moved since iOS 8. Is last or only one of all paths.
                // https://forums.xamarin.com/discussion/24860/documents-directory-has-moved-in-ios-8
                if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                {
                    var paths = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User);
                    var documentsPathWithoutLibrary = paths[paths.Length - 1].Path;
                    documentsPath = Path.Combine(documentsPathWithoutLibrary, "..", "Library");
                }
                else
                {
                    var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    documentsPath = Path.Combine(documents, "..", "Library");
                }

                return documentsPath;
            }
        }

        public bool IsStatusBarHidden { get { return UIApplication.SharedApplication.StatusBarHidden; } }

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.SetStatusBarHidden(true, UIStatusBarAnimation.Slide);
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.SetStatusBarHidden(false, UIStatusBarAnimation.Slide);
        }
    }
}
