using System;
using AssassinVR.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Amoenus.PclTimer;
using System.Threading;

namespace AssassinVR
{
    public partial class MainPage : ContentPage
    {
        Position pos = new Position(-36.854657, 174.766210);
        Position currentPos;
        Boolean timerLock;
        Random rand = new Random();
        double[,] coordinates = { { -36.854657, 174.766210 }/*AUT Halls of residence*/,
                                  { -36.850814, 174.767810 }/*Albert Park*/,
                                  { -36.849532, 174.766584 }/*Scarecrow*/ };

        public MainPage()
        {
            InitializeComponent();

        }

        async void ButtonClicked(object sender, EventArgs e)
        {

            int missionNum = rand.Next(3);
            var position = new Position(coordinates[missionNum,0], coordinates[missionNum,1]); // Latitude, Longitude
            currentPos = position;
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "custom pin",
                Address = "custom detail info"
            };

            Button button = sender as Button;
            if(button.Text == "Start mission")
            {
                if(timerLock == true)
                {
                    await DisplayAlert("AVR!", "!Mission Already Active!", "ok");
                }
                else
                {
                    MyMap.Pins.Clear();
                    await DisplayAlert("AVR!", "!Placing Marker!", "ok");
                    MyMap.Pins.Add(pin);
                    timerLock = true;
                    timer(20);
                } 
            }
            else if(button.Text == "Finish mission")
            {
                await DisplayAlert("AVR!", "!Removing Marker!", "ok");
                timerLock = false;
                MyMap.Pins.Clear();
            }
        }

        private void timer(double time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                time -= 1;
                if(timerLock == true)
                {
                    Timex.Text = String.Format("{0}", time);
                    if(pos == currentPos)
                    {
                        DisplayAlert("Test", "We hit destination", "cool");
                        timerLock = false;
                        Timex.Text = "Winner Winner Chicken Dinner";
                    }
                }
                else
                {
                    return false;
                }
                
                if (time == 0.00)
                {
                    DisplayAlert("Time's up", "The mission has expired", "Ok");
                    timerLock = false;
                    return false;
                }

                return true;
            });
        }
    }
}
