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
            this.client = new MobileServiceClient("MOBILE_APP_URL");
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

        public async Task<List<Reservation>> GetReservations()
        {
            return await this.reservationTable.ToListAsync();
        }
    }
}
