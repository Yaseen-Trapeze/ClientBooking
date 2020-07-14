using ClientBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public class ClientRepository : IClientRepository
    {
        private ClientBookingContext ClientDB;
        public ClientRepository()
        {

            ClientDB = new ClientBookingContext() ?? throw new ArgumentNullException(nameof(ClientDB));
        }

        public int AddClient(Client client)
        {
            ClientDB.Client.Add(client);
            ClientDB.SaveChanges();

            return client.ClientId;

        }

        public int DeleteClient(int ClientID)
        {
            int result = 0;

            //Find the client for specific client id
            var client = ClientDB.Client.FirstOrDefault(x => x.ClientId == ClientID);

            if (client != null)
            {
                //Delete that client
                ClientDB.Client.Remove(client);

                //Commit the transaction
                result = ClientDB.SaveChanges();
            }
            return result;

        }

        public List<Client> GetAllClients()
        {
            return ClientDB.Set<Client>().Include(c => c.ClientContact).Include(d => d.Booking).ThenInclude(e => e.BookingAdress)
                       .ToList();

        }

        public Client GetClientByID(int ClientID)
        {
            return ClientDB.Client.Include(c => c.ClientContact).Include(d => d.Booking).ThenInclude(e => e.BookingAdress)
                .FirstOrDefault(x => x.ClientId == ClientID);
        }

        public void UpdateClient(Client client)
        {
            //Update that client
            ClientDB.Client.Update(client);

            //Commit the transaction
            ClientDB.SaveChanges();

        }
    }
}
