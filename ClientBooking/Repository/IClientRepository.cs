using ClientBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBooking.Repository
{
    public interface IClientRepository
    {
        List<Client> GetAllClients();
        Client GetClientByID(int ClientID);
        int AddClient(Client client);
        int DeleteClient(int ClientID);
        void UpdateClient(Client client);
    }
}
