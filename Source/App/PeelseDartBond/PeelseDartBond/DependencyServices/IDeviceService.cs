using System;
//using System.Collections.Generic;
//using Plugin.Connectivity.Abstractions;

namespace PeelseDartBond.DependencyServices
{
    public interface IDeviceService
    {
        bool IsTablet { get; }
        bool IsPhone { get; }

        bool IsIos { get; }
        bool IsAndroid { get; }
        bool IsWindows { get; }

        string OsVersion { get; }
        string AppVersion { get; }

        //bool IsConnected { get; }
        //IEnumerable<ConnectionType> ConnectionTypes { get; }

        string DocumentsPath { get; }

        bool IsStatusBarHidden { get; }
        void HideStatusBar();
        void ShowStatusBar();
    }
}
