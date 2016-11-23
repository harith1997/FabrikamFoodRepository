using FabrikamFood.DataModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamFood
{
    public class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Reservation> reservationTable;

      


        private AzureManager()
        {
            this.client = new MobileServiceClient("https://FabrikamFood2.azurewebsites.net/");
            this.reservationTable = this.client.GetTable<Reservation>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task AddReservation(Reservation reservation)
        {
            await this.reservationTable.InsertAsync(reservation);
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            await this.reservationTable.DeleteAsync(reservation);
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            await this.reservationTable.UpdateAsync(reservation);
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await this.reservationTable.ToListAsync();
        }
    }
}
