using FabrikamFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamFood
{
    public partial class ReservationScreen : ContentPage
    {

        public ReservationScreen()
        {
            InitializeComponent();

            checkForExistingReservation();

        }

        async void checkForExistingReservation()
        {
            bool foundReservation = false;
            Reservation res = null;
            string IdOfUserFB = AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId;

            List<Reservation> allReservations = await AzureManager.AzureManagerInstance.GetReservations();
            foreach (Reservation r in allReservations)
            {
                // Delete if reservation is current user's
                if (r.FBID == IdOfUserFB)
                {
                    foundReservation = true;
                    res = r;
                }
            }

            Label nameL = this.FindByName<Label>("nameLabel");
            Label phoneL = this.FindByName<Label>("phoneLabel");
            Label dateL = this.FindByName<Label>("dateLabel");
            Label timeL = this.FindByName<Label>("timeLabel");

            if ((foundReservation == true) && (res != null))
            {
                //this.FindByName<Label>("nameLabel").Text = res.Name;
                nameL.Text = res.Name;
                phoneL.Text = res.Phone;
                dateL.Text = res.Date;
                timeL.Text = res.Time;
            }
            else
            {
                nameL.Text = "N/A";
                phoneL.Text = "N/A";
                dateL.Text = "N/A";
                timeL.Text = "N/A";
            }
        }

        async void OnUpdateClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new UpdateReservation());
        }

        async void OnBackClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new MainPage());
        }

        async void OnCancelClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;


            string IdOfUserToDelete = AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId;



            //await DisplayAlert("User ID", IdOfUserToDelete + "should be e719dc85-4a13-45cc-9590-fcb597ac3d42", "ok");

            // Take reservation details entered by user from 
            List<Reservation> allReservations = await AzureManager.AzureManagerInstance.GetReservations();
            foreach (Reservation r in allReservations)
            {
                // Delete if reservation is current user's
                if (r.FBID == IdOfUserToDelete)
                {
                    await AzureManager.AzureManagerInstance.DeleteReservation(r);
                    await DisplayAlert("deleted!", "gone", "ok");
                }
            }

            Label nameL = this.FindByName<Label>("nameLabel");
            nameL.Text = "N/A";
        }



    }
}
