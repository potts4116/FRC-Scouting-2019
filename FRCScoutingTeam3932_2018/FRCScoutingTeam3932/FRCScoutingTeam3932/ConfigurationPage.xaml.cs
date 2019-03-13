using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//20180203:Cesar - added the following references
using System.Net.Http;
using System.Net.Http.Headers;
using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FRCScoutingTeam3932.Data;
using FRCScoutingTeam3932.Models;

namespace FRCScoutingTeam3932
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigurationPage : ContentPage
	{

        //private static int eventYear = 2017; //Application.Current.Resources.TryGetValue(""); //2017;
        private int eventYear;
        private Dictionary<string, string> dicEvents;
        private Dictionary<string, int> dicSchedule;

        public ConfigurationPage ()
		{
			InitializeComponent();
            pikYear.IsEnabled = true;
            pikEvent.IsEnabled = false;
            pikMatch.IsEnabled = false;
            pikAlliance.IsEnabled = false;
            pikPosition.IsEnabled = false;
            btnUpdate.IsEnabled = false;
        }

        void pikYearSelected(object sender, EventArgs e)
        {
            if (pikYear.SelectedIndex != -1)
            {
                GetEventData();
            }
        }

        async void OnTestAPIClicked(object sender, EventArgs e)
        {
            bool apiStatus = false;

            if (DependencyService.Get<INetworkStatus>().GetConnectionStatus() != ConnectionStatus.NotConnected)
            {
                var client = new HttpClient(new NativeMessageHandler());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1RTc2ODNFOS0wNDcwLTQzNUUtOENFRi1BOERFNjc3Q0FFMUI=");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1MUM2NThDMS05NUIxLTQxQTktQTdENi0wMjk0MjQ0NDY3MkQ=");
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;

                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                //It doesn't matter if you ask for XML - you always get JSON
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetStringAsync("https://frc-api.firstinspires.org/v2.0/");
                JObject jsonStatusResponse = JObject.Parse(response);

                string strAPIStatus = "Status = ";
                if (jsonStatusResponse["status"] == null)
                {
                    strAPIStatus += "Uknown";
                }
                else
                {
                    strAPIStatus += jsonStatusResponse["status"].ToString();
                    apiStatus = true;
                }
                await DisplayAlert("Return Value", strAPIStatus, "OK");
                if (apiStatus)
                {
                    GetEventData();
                    //pikYear.IsEnabled = true;
                    pikEvent.IsEnabled = true;
                    pikMatch.IsEnabled = true;
                    pikAlliance.IsEnabled = true;
                    pikPosition.IsEnabled = true;
                }
            }
            else
            {
                await DisplayAlert("Error connecting", "The FirstInspires site may be down, or your device may not be connected to the network", "OK");
            }
        }

        private async void GetEventData()
        {
            eventYear = Int32.Parse(pikYear.Items[pikYear.SelectedIndex].ToString());

            var client = new HttpClient(new NativeMessageHandler());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1RTc2ODNFOS0wNDcwLTQzNUUtOENFRi1BOERFNjc3Q0FFMUI=");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1MUM2NThDMS05NUIxLTQxQTktQTdENi0wMjk0MjQ0NDY3MkQ=");
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //It doesn't matter if you ask for XML - you always get JSON
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetStringAsync("https://frc-api.firstinspires.org/v2.0/" + eventYear.ToString() + "/events");
            JObject jsonEventsResponse = JObject.Parse(response);

            dicEvents = new Dictionary<string, string>();

            var sortedEvents = from ev in jsonEventsResponse["Events"] where (ev["type"].ToString() != "None") orderby ev["dateStart"] select ev;
            foreach (var objEvent in sortedEvents)
            {
                DateTime datStart = DateTimeOffset.Parse(objEvent["dateStart"].ToString()).DateTime;
                DateTime datEnd = DateTimeOffset.Parse(objEvent["dateEnd"].ToString()).DateTime;
                dicEvents.Add(datStart.ToString("yyyy-MM-dd") + " " + datEnd.ToString("yyyy-MM-dd") + " " + objEvent["name"].ToString(), objEvent["code"].ToString());
            }

            pikEvent.Items.Clear();
            foreach (var dicEvent in dicEvents.Keys)
            {
                pikEvent.Items.Add(dicEvent);
            }
        }

        void pikEventSelected(object sender, EventArgs e)
        {
            if (pikEvent.SelectedIndex != -1)
            {
                string eventCode = pikEvent.Items[pikEvent.SelectedIndex];
                //var answer = await DisplayAlert("Selected event code", dicEvents[eventCode], "OK", "Cancel");
                GetScheduleData(dicEvents[eventCode]);
            }
        }

        private async void GetScheduleData(string eventCode)
        {
            var client = new HttpClient(new NativeMessageHandler());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1RTc2ODNFOS0wNDcwLTQzNUUtOENFRi1BOERFNjc3Q0FFMUI=");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1MUM2NThDMS05NUIxLTQxQTktQTdENi0wMjk0MjQ0NDY3MkQ=");
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            //It doesn't matter if you ask for XML - you always get JSON
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetStringAsync("https://frc-api.firstinspires.org/v2.0/" + eventYear.ToString() + "/schedule/" + eventCode + "?tournamentLevel=qual");
            JObject jsonScheduleResponse = JObject.Parse(response);

            dicSchedule = new Dictionary<string, int>();

            var sortedSchedule = from sc in jsonScheduleResponse["Schedule"] orderby sc["matchNumber"] select sc;

            if (sortedSchedule.Count() > 0)
            {

                foreach (var objSchedule in sortedSchedule)
                {
                    DateTime datStart = DateTimeOffset.Parse(objSchedule["startTime"].ToString()).DateTime;
                    dicSchedule.Add(datStart.ToString("yyyy-MM-dd hh:mm:ss") + " " + objSchedule["description"].ToString(), Int32.Parse(objSchedule["matchNumber"].ToString()));
                }

                if (dicSchedule.Count > 0)
                {
                    pikMatch.Items.Clear();
                    foreach (var dicMatch in dicSchedule.Keys)
                    {
                        pikMatch.Items.Add(dicMatch);
                    }
                    pikMatch.IsEnabled = true;
                    btnUpdate.IsEnabled = true;
                }
                else
                {
                    pikMatch.Items.Clear();
                    pikMatch.Items.Add("-Unavailable-");
                    //pikMatch.SelectedIndex = 0;
                    //pikMatch.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                    await DisplayAlert("No schedule data", "No schedule data was available for event " + pikEvent.Items[pikEvent.SelectedIndex], "OK");
                }

            }
            else
            {
                pikMatch.Items.Clear();
                pikMatch.Items.Add("-Unavailable-");
                //pikMatch.SelectedIndex = 0;
                //pikMatch.IsEnabled = false;
                btnUpdate.IsEnabled = false;
                await DisplayAlert("Error retrieving data", "An error occurred or schedule data is not yet available for event " + pikEvent.Items[pikEvent.SelectedIndex], "OK");
            }

        }

        async void pikMatchSelected(object sender, EventArgs e)
        {
            if (pikMatch.SelectedIndex != -1)
            {
                string matchName = pikMatch.Items[pikMatch.SelectedIndex];
                var answer = await DisplayAlert("Selected match code", dicSchedule[matchName].ToString(), "OK", "Cancel");
            }
        }

        async void OnUpdateClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Confirm", "Erase all match data from this device?", "OK", "Cancel");
            if (answer)
            {
                int countRows = 0;
                string[] arrAlliances = { "Blue", "Red" };

                RobotGameDatabase dbRobGam = App.Database;
                string sqlCmd = "DELETE FROM RobotGame";
                await dbRobGam.BulkImportAsync(sqlCmd);
                sqlCmd = "DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'RobotGame';";
                await dbRobGam.BulkImportAsync(sqlCmd);


                var client = new HttpClient(new NativeMessageHandler());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1RTc2ODNFOS0wNDcwLTQzNUUtOENFRi1BOERFNjc3Q0FFMUI=");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "Y2VzaW5jbzo1MUM2NThDMS05NUIxLTQxQTktQTdENi0wMjk0MjQ0NDY3MkQ=");
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;

                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                //It doesn't matter if you ask for XML - you always get JSON
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetStringAsync("https://frc-api.firstinspires.org/v2.0/" + eventYear.ToString() + "/schedule/" + dicEvents[pikEvent.Items[pikEvent.SelectedIndex]] + "?tournamentLevel=qual");
                JObject jsonScheduleResponse = JObject.Parse(response);

                var sortedSchedule = from sc in jsonScheduleResponse["Schedule"] orderby sc["matchNumber"] select sc;
                foreach (var objSchedule in sortedSchedule)
                {
                    var filtMatch = objSchedule["teams"];

                    Guid mergedID;
                    string deviceID = App.DeviceID;
                    int ally1;
                    int ally2;
                    DateTime dtCreatedAt = System.DateTime.Now;

                    foreach (string ally in arrAlliances)
                    {
                        for (int sta = 1; sta < 4; sta++)
                        {
                            if ((pikAlliance.Items[pikAlliance.SelectedIndex] == "Both") || (pikAlliance.Items[pikAlliance.SelectedIndex] == ally))
                            {
                                if ((pikPosition.Items[pikPosition.SelectedIndex] == "All") || (pikPosition.Items[pikPosition.SelectedIndex] == sta.ToString()))
                                {
                                    mergedID = Guid.NewGuid();

                                    DateTime dtRowTime = new DateTime(dtCreatedAt.AddSeconds(countRows++).Ticks);

                                    int teamTracked = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + sta.ToString() + "')]")["teamNumber"].ToString());

                                    switch (sta)
                                    {
                                        case 1:
                                            ally1 = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + "2')]")["teamNumber"].ToString());
                                            ally2 = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + "3')]")["teamNumber"].ToString());
                                            break;
                                        case 2:
                                            ally1 = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + "1')]")["teamNumber"].ToString());
                                            ally2 = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + "3')]")["teamNumber"].ToString());
                                            break;
                                        default:
                                            ally1 = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + "1')]")["teamNumber"].ToString());
                                            ally2 = Int32.Parse(filtMatch.SelectToken("[?(@.station == '" + ally + "2')]")["teamNumber"].ToString());
                                            break;
                                    }

                                    RobotGame rowRobGam = new RobotGame();
                                    rowRobGam.mergedID = mergedID;
                                    rowRobGam.deviceID = deviceID;
                                    rowRobGam.Team = teamTracked;
                                    rowRobGam.Ally1 = ally1;
                                    rowRobGam.Ally2 = ally2;
                                    rowRobGam.Game = Int32.Parse(objSchedule["matchNumber"].ToString());
                                    rowRobGam.CreatedAt = (System.DateTime.Now).ToString("yyyy-MM-ddTHH:mm:ss.fff");
                                    rowRobGam.Alliance = ally;
                                    rowRobGam.Station = sta;

                                    await dbRobGam.SaveGameAsync(rowRobGam);
                                }
                            }
                        }
                    }
                }

                if (countRows > 0)
                {
                    await DisplayAlert("Import Complete", countRows.ToString() + " row(s) were imported for event " + pikEvent.Items[pikEvent.SelectedIndex] + " filtering on " + pikAlliance.Items[pikAlliance.SelectedIndex] + " alliances and position = " + pikPosition.Items[pikPosition.SelectedIndex], "OK");
                }
            }
        }
    }
}