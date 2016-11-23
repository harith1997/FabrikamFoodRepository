using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabrikamFood;

using Xamarin.Forms;

namespace FabrikamFood.Views
{
    public partial class FacebookLoginScreen : ContentPage
    {

        // Track whether the user has authenticated.
        bool authenticated = false;

        public FacebookLoginScreen()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (authenticated == true)
            {
                // Hide the Sign-in button.
                this.loginButton.IsVisible = false;
            }
        }
        
        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
                this.loginButton.IsVisible = false;

            await Navigation.PushModalAsync(new ReservationScreen());
        }
    }
}
