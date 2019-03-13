using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using Xamarin.Forms;
using FRCScoutingTeam3932.Droid;

[assembly: Dependency(typeof(NetworkStatus))]
namespace FRCScoutingTeam3932.Droid
{
    class NetworkStatus : INetworkStatus
    {
        public ConnectionStatus GetConnectionStatus()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            if (networkInfo == null)
            {
                return ConnectionStatus.NotConnected;
            }
            else
            {
                bool isOnline = networkInfo.IsConnected;
                if (isOnline)
                {
                    switch (networkInfo.Type)
                    {
                        case ConnectivityType.Wifi:
                            return ConnectionStatus.WifiConnected;

                        case ConnectivityType.Mobile:
                            return ConnectionStatus.CellConnected;

                        default:
                            return ConnectionStatus.NotConnected;
                    }

                }
                else
                {
                    return ConnectionStatus.NotConnected;
                }
            }
        }
    }
}