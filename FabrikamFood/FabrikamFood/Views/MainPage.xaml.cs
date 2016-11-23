using FabrikamFood.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace FabrikamFood
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnMenuClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new MenuScreen());
        }

        async void OnReservationClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new FacebookLoginScreen());
            //await Navigation.PushModalAsync(new ReservationScreen());
        }

        void OnFindUsClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            DependencyService.Get<INativeAndroidMaps>().startGoogleMaps();
            //await Navigation.PushModalAsync(new FindUsScreen());
        }

        async void OnAboutUsClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new AboutUsScreen());
        }
    }
}
