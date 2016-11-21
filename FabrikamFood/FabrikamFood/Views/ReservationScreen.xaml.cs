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
        }

        async void OnUpdateClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new UpdateReservation());
        }




    }
}
