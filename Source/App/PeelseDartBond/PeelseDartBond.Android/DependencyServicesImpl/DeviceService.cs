using System;
using System.Collections.Generic;
using Android.Content;
//using Plugin.Connectivity;
//using Plugin.Connectivity.Abstractions;
using PeelseDartBond.DependencyServices;
using PeelseDartBond.Droid.DependencyServicesImpl;
using Xamarin.Forms;
using Android.App;
using Android.Views;

[assembly: Dependency (typeof (DeviceService_Droid))]
// How to use in Forms project: DependencyService.Get<IDeviceService>().IsPhone

namespace PeelseDartBond.Droid.DependencyServicesImpl
{
    public class DeviceService_Droid : IDeviceService
    {
        bool _isHidden;
        WindowManagerFlags _originalFlags;

        public DeviceService_Droid ()
        {
        }

        public bool IsTablet { get { return Device.Idiom == TargetIdiom.Tablet; } }
        public bool IsPhone { get { return Device.Idiom == TargetIdiom.Phone; } }

        public bool IsIos { get { return false; } }
        public bool IsAndroid { get { return true; } }
        public bool IsWindows { get { return false; } }

        public string OsVersion { get { return Android.OS.Build.VERSION.Release; } }
        public string AppVersion 
        { 
            get 
            { 
                Context context = Android.App.Application.Context;
                return context.PackageManager.GetPackageInfo (context.PackageName, 0).VersionName;
            }
        }

        //public bool IsConnected { get { return CrossConnectivity.Current.IsConnected; } }
        //public IEnumerable<ConnectionType> ConnectionTypes { get { return CrossConnectivity.Current.ConnectionTypes; } }

        public string DocumentsPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); } }

        public bool IsStatusBarHidden 
        { 
            get 
            {
                return _isHidden; 
            } 
        }

        public void HideStatusBar()
        {
            var activity = (Activity)Android.App.Application.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
            _isHidden = true;
        }

        public void ShowStatusBar()
        {
            var activity = (Activity)Android.App.Application.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
            _isHidden = false;
        }
    }
}
