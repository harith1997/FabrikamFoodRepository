using FabrikamFood.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamFood
{
    public partial class UpdateReservation : ContentPage
    {
        public UpdateReservation()
        {
            InitializeComponent();
        }

        async void OnSaveChangesClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            // Take reservation details entered by user from text properties and assign to Reservation object's fields
            Reservation res = new Reservation()
            {
                Name = nameEntry.Text,
                Phone = phoneEntry.Text,
                Date = dateEntry.Date.ToString(),
                Time = timeEntry.Time.ToString(),
                FBID = AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId

        };

            // if search backend and ID for user returns empty data, then ADD. Otherwise UPDATE
            bool foundReservation = false;
            List<Reservation> allReservations = await AzureManager.AzureManagerInstance.GetReservations();
            foreach (Reservation r in allReservations)
            {
                // Delete if reservation is current user's
                if (r.FBID == AzureManager.AzureManagerInstance.AzureClient.CurrentUser.UserId)
                {
                    foundReservation = true;
                }
            }

            if (foundReservation == true)
            {
                await AzureManager.AzureManagerInstance.UpdateReservation(res);
            }
            else
            {
                await AzureManager.AzureManagerInstance.AddReservation(res);
            }


            // Update ReservationScreen info with updated details
            //ReservationScreen resScreen = new ReservationScreen();


           
            await Navigation.PushModalAsync(new ReservationScreen());
        }

        async void OnCancelClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new ReservationScreen());
        }



    }
}
