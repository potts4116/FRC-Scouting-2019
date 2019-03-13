using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using FRCScoutingTeam3932.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)] //Can we use this here, with a partial class?
namespace FRCScoutingTeam3932
{
	public partial class App : Application
	{

        private static RobotGameDatabase database;
        private static string deviceID { get; set; }

        public App ()
		{
            //InitializeComponent(); //Do we need this here?

            //MainPage = new FRCScoutingTeam3932.SplashPage();

            database = Database;

            var nav = new NavigationPage(new SplashPage());
            MainPage = nav;
        }

        public int ResumeAtRobotGameId { get; set; }

        public static RobotGameDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RobotGameDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("FRCScoutingTeam3932.db3"));
                }
                return database;
            }
        }

        public static string DeviceID
        {
            get
            {
                if (deviceID == null)
                {
                    deviceID = DependencyService.Get<IDeviceID>().GetIdentifier();
                }
                return deviceID;
            }
        }

        /*
        protected override async void OnStart ()
		{
            // Handle when your app starts
            if (Properties.ContainsKey("ResumeAtRobotGameId"))
            {
                var resumeID = Properties["ResumeAtRobotGameId"].ToString();
                if (!String.IsNullOrEmpty(resumeID))
                {
                    ResumeAtRobotGameId = int.Parse(resumeID);
                    if (ResumeAtRobotGameId >= 0)
                    {
                        var robotGamePage = new RobotGamePage();
                        robotGamePage.BindingContext = await Database.GetGameAsync(ResumeAtRobotGameId);
                        await MainPage.Navigation.PushAsync(robotGamePage, false); // no animation
                    }
                }
            }
        }
        */

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            Properties["ResumeAtRobotGameId"] = ResumeAtRobotGameId;
        }

        /*
		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        */
	}
}
