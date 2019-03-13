using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FRCScoutingTeam3932.Models;

namespace FRCScoutingTeam3932
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RobotGamePage : ContentPage
	{
		public RobotGamePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var robotGame = (RobotGame)BindingContext;
            if (robotGame != null)
            {
                if ((robotGame.Alliance != null) && (robotGame.Station > 0))
                {
                    this.lblAlliancePosition.Text = robotGame.Alliance + " " + robotGame.Station.ToString();
                }

                ((App)App.Current).ResumeAtRobotGameId = robotGame.ID;
            }
        }

        //####################################################################################

        bool stpAutoDescendPlatformChanged;
        bool txtAutoDescendPlatformChanged;

        void OnTxtAutoDescendPlatformChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intAutoDescendPlatform;
                txtAutoDescendPlatformChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intAutoDescendPlatform))
                {
                    if (intAutoDescendPlatform < 0 || intAutoDescendPlatform > 2)
                    {
                        intAutoDescendPlatform = 0;
                    }
                    if (!stpAutoDescendPlatformChanged)
                    {
                        stpAutoDescendPlatform.Value = intAutoDescendPlatform;
                    }
                }
                else
                {
                    AutoDescendPlatform.Text = e.OldTextValue;
                }
                txtAutoDescendPlatformChanged = false;
            }
        }

        void OnStpAutoDescendPlatformChanged(object sender, ValueChangedEventArgs e)
        {
            if (AutoDescendPlatform.Text == null)
            {
                stpAutoDescendPlatformChanged = true;
                AutoDescendPlatform.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpAutoDescendPlatformChanged = false;
            }
            else
            {
                int intAutoDescendPlatform;
                if (Int32.TryParse(AutoDescendPlatform.Text, out intAutoDescendPlatform))
                {
                    if (intAutoDescendPlatform < 0 || intAutoDescendPlatform > 2)
                    {
                        intAutoDescendPlatform = 0;
                        stpAutoDescendPlatform.Value = stpAutoDescendPlatform.Increment;
                    }
                    intAutoDescendPlatform += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intAutoDescendPlatform = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtAutoDescendPlatformChanged)
                {
                    stpAutoDescendPlatformChanged = true;
                    AutoDescendPlatform.Text = intAutoDescendPlatform.ToString();
                    stpAutoDescendPlatformChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpAutoPlaceHatchChanged;
        bool txtAutoPlaceHatchChanged;

        void OnTxtAutoPlaceHatchChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intAutoPlaceHatch;
                txtAutoPlaceHatchChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intAutoPlaceHatch))
                {
                    if (intAutoPlaceHatch < 0 || intAutoPlaceHatch > 999)
                    {
                        intAutoPlaceHatch = 0;
                    }
                    if (!stpAutoPlaceHatchChanged)
                    {
                        stpAutoPlaceHatch.Value = intAutoPlaceHatch;
                    }
                }
                else
                {
                    AutoPlaceHatch.Text = e.OldTextValue;
                }
                txtAutoPlaceHatchChanged = false;
            }
        }

        void OnStpAutoPlaceHatchChanged(object sender, ValueChangedEventArgs e)
        {
            if (AutoPlaceHatch.Text == null)
            {
                stpAutoPlaceHatchChanged = true;
                AutoPlaceHatch.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpAutoPlaceHatchChanged = false;
            }
            else
            {
                int intAutoPlaceHatch;
                if (Int32.TryParse(AutoPlaceHatch.Text, out intAutoPlaceHatch))
                {
                    if (intAutoPlaceHatch < 0 || intAutoPlaceHatch > 999)
                    {
                        intAutoPlaceHatch = 0;
                        stpAutoPlaceHatch.Value = stpAutoPlaceHatch.Increment;
                    }
                    intAutoPlaceHatch += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intAutoPlaceHatch = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtAutoPlaceHatchChanged)
                {
                    stpAutoPlaceHatchChanged = true;
                    AutoPlaceHatch.Text = intAutoPlaceHatch.ToString();
                    stpAutoPlaceHatchChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpAutoPlaceCargoChanged;
        bool txtAutoPlaceCargoChanged;

        void OnTxtAutoPlaceCargoChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intAutoPlaceCargo;
                txtAutoPlaceCargoChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intAutoPlaceCargo))
                {
                    if (intAutoPlaceCargo < 0 || intAutoPlaceCargo > 999)
                    {
                        intAutoPlaceCargo = 0;
                    }
                    if (!stpAutoPlaceCargoChanged)
                    {
                        stpAutoPlaceCargo.Value = intAutoPlaceCargo;
                    }
                }
                else
                {
                    AutoPlaceCargo.Text = e.OldTextValue;
                }
                txtAutoPlaceCargoChanged = false;
            }
        }

        void OnStpAutoPlaceCargoChanged(object sender, ValueChangedEventArgs e)
        {
            if (AutoPlaceCargo.Text == null)
            {
                stpAutoPlaceCargoChanged = true;
                AutoPlaceCargo.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpAutoPlaceCargoChanged = false;
            }
            else
            {
                int intAutoPlaceCargo;
                if (Int32.TryParse(AutoPlaceCargo.Text, out intAutoPlaceCargo))
                {
                    if (intAutoPlaceCargo < 0 || intAutoPlaceCargo > 999)
                    {
                        intAutoPlaceCargo = 0;
                        stpAutoPlaceCargo.Value = stpAutoPlaceCargo.Increment;
                    }
                    intAutoPlaceCargo += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intAutoPlaceCargo = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtAutoPlaceCargoChanged)
                {
                    stpAutoPlaceCargoChanged = true;
                    AutoPlaceCargo.Text = intAutoPlaceCargo.ToString();
                    stpAutoPlaceCargoChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTelePlaceHatchLowChanged;
        bool txtTelePlaceHatchLowChanged;

        void OnTxtTelePlaceHatchLowChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTelePlaceHatchLow;
                txtTelePlaceHatchLowChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTelePlaceHatchLow))
                {
                    if (intTelePlaceHatchLow < 0 || intTelePlaceHatchLow > 999)
                    {
                        intTelePlaceHatchLow = 0;
                    }
                    if (!stpTelePlaceHatchLowChanged)
                    {
                        stpTelePlaceHatchLow.Value = intTelePlaceHatchLow;
                    }
                }
                else
                {
                    TelePlaceHatchLow.Text = e.OldTextValue;
                }
                txtTelePlaceHatchLowChanged = false;
            }
        }

        void OnStpTelePlaceHatchLowChanged(object sender, ValueChangedEventArgs e)
        {
            if (TelePlaceHatchLow.Text == null)
            {
                stpTelePlaceHatchLowChanged = true;
                TelePlaceHatchLow.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTelePlaceHatchLowChanged = false;
            }
            else
            {
                int intTelePlaceHatchLow;
                if (Int32.TryParse(TelePlaceHatchLow.Text, out intTelePlaceHatchLow))
                {
                    if (intTelePlaceHatchLow < 0 || intTelePlaceHatchLow > 999)
                    {
                        intTelePlaceHatchLow = 0;
                        stpTelePlaceHatchLow.Value = stpTelePlaceHatchLow.Increment;
                    }
                    intTelePlaceHatchLow += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTelePlaceHatchLow = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTelePlaceHatchLowChanged)
                {
                    stpTelePlaceHatchLowChanged = true;
                    TelePlaceHatchLow.Text = intTelePlaceHatchLow.ToString();
                    stpTelePlaceHatchLowChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTelePlaceHatchMedChanged;
        bool txtTelePlaceHatchMedChanged;

        void OnTxtTelePlaceHatchMedChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTelePlaceHatchMed;
                txtTelePlaceHatchMedChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTelePlaceHatchMed))
                {
                    if (intTelePlaceHatchMed < 0 || intTelePlaceHatchMed > 999)
                    {
                        intTelePlaceHatchMed = 0;
                    }
                    if (!stpTelePlaceHatchMedChanged)
                    {
                        stpTelePlaceHatchMed.Value = intTelePlaceHatchMed;
                    }
                }
                else
                {
                    TelePlaceHatchMed.Text = e.OldTextValue;
                }
                txtTelePlaceHatchMedChanged = false;
            }
        }

        void OnStpTelePlaceHatchMedChanged(object sender, ValueChangedEventArgs e)
        {
            if (TelePlaceHatchMed.Text == null)
            {
                stpTelePlaceHatchMedChanged = true;
                TelePlaceHatchMed.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTelePlaceHatchMedChanged = false;
            }
            else
            {
                int intTelePlaceHatchMed;
                if (Int32.TryParse(TelePlaceHatchMed.Text, out intTelePlaceHatchMed))
                {
                    if (intTelePlaceHatchMed < 0 || intTelePlaceHatchMed > 999)
                    {
                        intTelePlaceHatchMed = 0;
                        stpTelePlaceHatchMed.Value = stpTelePlaceHatchMed.Increment;
                    }
                    intTelePlaceHatchMed += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTelePlaceHatchMed = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTelePlaceHatchMedChanged)
                {
                    stpTelePlaceHatchMedChanged = true;
                    TelePlaceHatchMed.Text = intTelePlaceHatchMed.ToString();
                    stpTelePlaceHatchMedChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTelePlaceHatchHighChanged;
        bool txtTelePlaceHatchHighChanged;

        void OnTxtTelePlaceHatchHighChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTelePlaceHatchHigh;
                txtTelePlaceHatchHighChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTelePlaceHatchHigh))
                {
                    if (intTelePlaceHatchHigh < 0 || intTelePlaceHatchHigh > 999)
                    {
                        intTelePlaceHatchHigh = 0;
                    }
                    if (!stpTelePlaceHatchHighChanged)
                    {
                        stpTelePlaceHatchHigh.Value = intTelePlaceHatchHigh;
                    }
                }
                else
                {
                    TelePlaceHatchHigh.Text = e.OldTextValue;
                }
                txtTelePlaceHatchHighChanged = false;
            }
        }

        void OnStpTelePlaceHatchHighChanged(object sender, ValueChangedEventArgs e)
        {
            if (TelePlaceHatchHigh.Text == null)
            {
                stpTelePlaceHatchHighChanged = true;
                TelePlaceHatchHigh.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTelePlaceHatchHighChanged = false;
            }
            else
            {
                int intTelePlaceHatchHigh;
                if (Int32.TryParse(TelePlaceHatchHigh.Text, out intTelePlaceHatchHigh))
                {
                    if (intTelePlaceHatchHigh < 0 || intTelePlaceHatchHigh > 999)
                    {
                        intTelePlaceHatchHigh = 0;
                        stpTelePlaceHatchHigh.Value = stpTelePlaceHatchHigh.Increment;
                    }
                    intTelePlaceHatchHigh += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTelePlaceHatchHigh = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTelePlaceHatchHighChanged)
                {
                    stpTelePlaceHatchHighChanged = true;
                    TelePlaceHatchHigh.Text = intTelePlaceHatchHigh.ToString();
                    stpTelePlaceHatchHighChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTelePlaceCargoLowChanged;
        bool txtTelePlaceCargoLowChanged;

        void OnTxtTelePlaceCargoLowChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTelePlaceCargoLow;
                txtTelePlaceCargoLowChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTelePlaceCargoLow))
                {
                    if (intTelePlaceCargoLow < 0 || intTelePlaceCargoLow > 999)
                    {
                        intTelePlaceCargoLow = 0;
                    }
                    if (!stpTelePlaceCargoLowChanged)
                    {
                        stpTelePlaceCargoLow.Value = intTelePlaceCargoLow;
                    }
                }
                else
                {
                    TelePlaceCargoLow.Text = e.OldTextValue;
                }
                txtTelePlaceCargoLowChanged = false;
            }
        }

        void OnStpTelePlaceCargoLowChanged(object sender, ValueChangedEventArgs e)
        {
            if (TelePlaceCargoLow.Text == null)
            {
                stpTelePlaceCargoLowChanged = true;
                TelePlaceCargoLow.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTelePlaceCargoLowChanged = false;
            }
            else
            {
                int intTelePlaceCargoLow;
                if (Int32.TryParse(TelePlaceCargoLow.Text, out intTelePlaceCargoLow))
                {
                    if (intTelePlaceCargoLow < 0 || intTelePlaceCargoLow > 999)
                    {
                        intTelePlaceCargoLow = 0;
                        stpTelePlaceCargoLow.Value = stpTelePlaceCargoLow.Increment;
                    }
                    intTelePlaceCargoLow += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTelePlaceCargoLow = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTelePlaceCargoLowChanged)
                {
                    stpTelePlaceCargoLowChanged = true;
                    TelePlaceCargoLow.Text = intTelePlaceCargoLow.ToString();
                    stpTelePlaceCargoLowChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTelePlaceCargoMedChanged;
        bool txtTelePlaceCargoMedChanged;

        void OnTxtTelePlaceCargoMedChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTelePlaceCargoMed;
                txtTelePlaceCargoMedChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTelePlaceCargoMed))
                {
                    if (intTelePlaceCargoMed < 0 || intTelePlaceCargoMed > 999)
                    {
                        intTelePlaceCargoMed = 0;
                    }
                    if (!stpTelePlaceCargoMedChanged)
                    {
                        stpTelePlaceCargoMed.Value = intTelePlaceCargoMed;
                    }
                }
                else
                {
                    TelePlaceCargoMed.Text = e.OldTextValue;
                }
                txtTelePlaceCargoMedChanged = false;
            }
        }

        void OnStpTelePlaceCargoMedChanged(object sender, ValueChangedEventArgs e)
        {
            if (TelePlaceCargoMed.Text == null)
            {
                stpTelePlaceCargoMedChanged = true;
                TelePlaceCargoMed.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTelePlaceCargoMedChanged = false;
            }
            else
            {
                int intTelePlaceCargoMed;
                if (Int32.TryParse(TelePlaceCargoMed.Text, out intTelePlaceCargoMed))
                {
                    if (intTelePlaceCargoMed < 0 || intTelePlaceCargoMed > 999)
                    {
                        intTelePlaceCargoMed = 0;
                        stpTelePlaceCargoMed.Value = stpTelePlaceCargoMed.Increment;
                    }
                    intTelePlaceCargoMed += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTelePlaceCargoMed = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTelePlaceCargoMedChanged)
                {
                    stpTelePlaceCargoMedChanged = true;
                    TelePlaceCargoMed.Text = intTelePlaceCargoMed.ToString();
                    stpTelePlaceCargoMedChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTelePlaceCargoHighChanged;
        bool txtTelePlaceCargoHighChanged;

        void OnTxtTelePlaceCargoHighChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTelePlaceCargoHigh;
                txtTelePlaceCargoHighChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTelePlaceCargoHigh))
                {
                    if (intTelePlaceCargoHigh < 0 || intTelePlaceCargoHigh > 999)
                    {
                        intTelePlaceCargoHigh = 0;
                    }
                    if (!stpTelePlaceCargoHighChanged)
                    {
                        stpTelePlaceCargoHigh.Value = intTelePlaceCargoHigh;
                    }
                }
                else
                {
                    TelePlaceCargoHigh.Text = e.OldTextValue;
                }
                txtTelePlaceCargoHighChanged = false;
            }
        }

        void OnStpTelePlaceCargoHighChanged(object sender, ValueChangedEventArgs e)
        {
            if (TelePlaceCargoHigh.Text == null)
            {
                stpTelePlaceCargoHighChanged = true;
                TelePlaceCargoHigh.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTelePlaceCargoHighChanged = false;
            }
            else
            {
                int intTelePlaceCargoHigh;
                if (Int32.TryParse(TelePlaceCargoHigh.Text, out intTelePlaceCargoHigh))
                {
                    if (intTelePlaceCargoHigh < 0 || intTelePlaceCargoHigh > 999)
                    {
                        intTelePlaceCargoHigh = 0;
                        stpTelePlaceCargoHigh.Value = stpTelePlaceCargoHigh.Increment;
                    }
                    intTelePlaceCargoHigh += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTelePlaceCargoHigh = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTelePlaceCargoHighChanged)
                {
                    stpTelePlaceCargoHighChanged = true;
                    TelePlaceCargoHigh.Text = intTelePlaceCargoHigh.ToString();
                    stpTelePlaceCargoHighChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTeleHabHeightChanged;
        bool txtTeleHabHeightChanged;

        void OnTxtTeleHabHeightChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTeleHabHeight;
                txtTeleHabHeightChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTeleHabHeight))
                {
                    if (intTeleHabHeight < 0 || intTeleHabHeight > 3)
                    {
                        intTeleHabHeight = 0;
                    }
                    if (!stpTeleHabHeightChanged)
                    {
                        stpTeleHabHeight.Value = intTeleHabHeight;
                    }
                }
                else
                {
                    TeleHabHeight.Text = e.OldTextValue;
                }
                txtTeleHabHeightChanged = false;
            }
        }

        void OnStpTeleHabHeightChanged(object sender, ValueChangedEventArgs e)
        {
            if (TeleHabHeight.Text == null)
            {
                stpTeleHabHeightChanged = true;
                TeleHabHeight.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTeleHabHeightChanged = false;
            }
            else
            {
                int intTeleHabHeight;
                if (Int32.TryParse(TeleHabHeight.Text, out intTeleHabHeight))
                {
                    if (intTeleHabHeight < 0 || intTeleHabHeight > 3)
                    {
                        intTeleHabHeight = 0;
                        stpTeleHabHeight.Value = stpTeleHabHeight.Increment;
                    }
                    intTeleHabHeight += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTeleHabHeight = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTeleHabHeightChanged)
                {
                    stpTeleHabHeightChanged = true;
                    TeleHabHeight.Text = intTeleHabHeight.ToString();
                    stpTeleHabHeightChanged = false;
                }
            }
        }

        //####################################################################################

        bool stpTeleDefensePlayedChanged;
        bool txtTeleDefensePlayedChanged;

        void OnTxtTeleDefensePlayedChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                int intTeleDefensePlayed;
                txtTeleDefensePlayedChanged = true;
                if (Int32.TryParse(e.NewTextValue, out intTeleDefensePlayed))
                {
                    if (intTeleDefensePlayed < 0 || intTeleDefensePlayed > 999)
                    {
                        intTeleDefensePlayed = 0;
                    }
                    if (!stpTeleDefensePlayedChanged)
                    {
                        stpTeleDefensePlayed.Value = intTeleDefensePlayed;
                    }
                }
                else
                {
                    TeleDefensePlayed.Text = e.OldTextValue;
                }
                txtTeleDefensePlayedChanged = false;
            }
        }

        void OnStpTeleDefensePlayedChanged(object sender, ValueChangedEventArgs e)
        {
            if (TeleDefensePlayed.Text == null)
            {
                stpTeleDefensePlayedChanged = true;
                TeleDefensePlayed.Text = Convert.ToInt32(e.NewValue - e.OldValue).ToString();
                stpTeleDefensePlayedChanged = false;
            }
            else
            {
                int intTeleDefensePlayed;
                if (Int32.TryParse(TeleDefensePlayed.Text, out intTeleDefensePlayed))
                {
                    if (intTeleDefensePlayed < 0 || intTeleDefensePlayed > 999)
                    {
                        intTeleDefensePlayed = 0;
                        stpTeleDefensePlayed.Value = stpTeleDefensePlayed.Increment;
                    }
                    intTeleDefensePlayed += Convert.ToInt32(e.NewValue - e.OldValue);
                }
                else
                {
                    intTeleDefensePlayed = Convert.ToInt32(e.NewValue - e.OldValue);
                }
                if (!txtTeleDefensePlayedChanged)
                {
                    stpTeleDefensePlayedChanged = true;
                    TeleDefensePlayed.Text = intTeleDefensePlayed.ToString();
                    stpTeleDefensePlayedChanged = false;
                }
            }
        }

        //####################################################################################

        async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                var robotGame = (RobotGame)BindingContext;
                if (((App)App.Current).ResumeAtRobotGameId != robotGame.ID)
                {
                    robotGame.deviceID = App.DeviceID;
                    robotGame.mergedID = Guid.NewGuid();
                    robotGame.CreatedAt = (System.DateTime.Now).ToString("yyyy-MM-ddTHH:mm:ss.fff");
                }
                await App.Database.SaveGameAsync(robotGame);
                await DisplayAlert("Match saved", "Match data was successfully saved", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error saving", ex.Message, "OK");
            }
        }

        /*
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var robotGame = (RobotGame)BindingContext;
            await App.Database.DeleteGameAsync(robotGame);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        */

    }
}