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

//20171212:Cesar - added using statement
using FRCScoutingTeam3932;
using FRCScoutingTeam3932.Droid;
using Xamarin.Forms;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceID))]
namespace FRCScoutingTeam3932.Droid
{
    class DeviceID : IDeviceID
    {
        public string GetIdentifier()
        {
            //return Android.Provider.Settings.Secure.GetString(Forms.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            //https://forums.xamarin.com/discussion/11467/how-to-get-a-context-when-not-in-a-activity
            //But also:
            //https://forums.xamarin.com/discussion/1342/getting-unique-device-id


            //Some 3rd-party addins for Xamarin:
            //https://github.com/XLabs/Xamarin-Forms-Labs
            //https://github.com/jamesmontemagno/DeviceInfoPlugin

            var serial = "";
            try
            {
                // Android 2.3 and up (API 10)
                serial = Build.Serial;
            }
            catch (Exception) { }

            var androidId = "";
            try
            {
                // Not 100% reliable on 2.2 (API 8)
                androidId = Settings.Secure.AndroidId;
            }
            catch (Exception) { }

            return serial + androidId;
        }
    }
}