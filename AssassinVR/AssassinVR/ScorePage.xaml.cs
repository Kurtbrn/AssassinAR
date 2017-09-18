using AssassinVR.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssassinVR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScorePage : ContentPage
    {

        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;


        public ScorePage()
        {
            InitializeComponent();

           
        }

        async void ClickedAsync(object sender, System.EventArgs e)
        {
            List<assassinInformation> notHotDogInformation = await AzureManager.AzureManagerInstance.GetScoreInformation();

            Assassins.ItemsSource = notHotDogInformation;
        }
    }
}