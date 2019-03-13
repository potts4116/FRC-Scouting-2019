using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FRCScoutingTeam3932
{
	public partial class SplashPage : ContentPage
	{
		public SplashPage()
		{
			InitializeComponent();
		}

        async void OnContinueClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RobotGameListPage());
        }
        async void OnConfigureClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfigurationPage());
        }
        /*
        void OnConfigureClicked(object sender, EventArgs e)
        {

        }
        */
        /*
        async void OnContinueClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RobotGameListPage());
        }

        async void OnConfigureClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfigurationPage());
        }
        */
    }
}
