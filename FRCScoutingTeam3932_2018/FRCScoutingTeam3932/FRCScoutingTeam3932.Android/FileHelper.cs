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

//20170218:Cesar - added using statements
using System.IO;
using Xamarin.Forms;
using FRCScoutingTeam3932;
using FRCScoutingTeam3932.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace FRCScoutingTeam3932.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
            //return Path.Combine("/sdcard/", filename); //Allows access with File Management utilities, but should not be used for production purposes
        }
    }
}