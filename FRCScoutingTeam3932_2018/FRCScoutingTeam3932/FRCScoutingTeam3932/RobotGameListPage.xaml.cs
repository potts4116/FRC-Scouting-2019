using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FRCScoutingTeam3932.Models;
using Android.Content;
using Android.App;
using FRCScoutingTeam3932;

namespace FRCScoutingTeam3932
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RobotGameListPage : ContentPage
	{
		public RobotGameListPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtRobotGameId = -1;
            listView.ItemsSource = await App.Database.GetGamesAsync();
        }

        async void OnNewGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RobotGamePage
            {
                BindingContext = new RobotGame()
            });
        }

        async void OnGameSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtRobotGameId = (e.SelectedItem as RobotGame).ID;
            System.Diagnostics.Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as RobotGame).ID);

            await Navigation.PushAsync(new RobotGamePage
            {
                BindingContext = e.SelectedItem as RobotGame
            });
        }

        async void OnExportClicked(object sender, EventArgs e)
        {
            string sqlExport = await App.Database.ExportGamesAsync();

            SQLeditor.Text = sqlExport;

            //bool cancelled = await DisplayAlert("Copy SQL Code", sqlExport, "OK", "Cancel");

            //var clipboard = (ClipboardManager)Context.GetSystemService(Context.ClipboardService);
            //var clip = ClipData.NewPlainText("SQL Code", sqlExport);
            //clipboard.PrimaryClip = clip;
            //SQLeditor.Text = "SQL Code copied to clipboard";
        }
    }
}