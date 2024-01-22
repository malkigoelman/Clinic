using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Entities;

namespace Mirpaha.Clinic.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _dataContext;
        public ClientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Client AddClient(Client client)
        {
            _dataContext.Clients.Add(client);
            _dataContext.SaveChanges();
            return client;
        }

        public void DeleteClient(int id)
        {
            var client = GetClientById(id);
            _dataContext.Clients.Remove(client);
            _dataContext.SaveChanges();
        }

        public Client GetClientById(int id)
        {
            return _dataContext.Clients.Find(id);
        }

        public IEnumerable<Client> GetClients()
        {
            return _dataContext.Clients.ToList();
        }

        public Client UpdateClient(int id, Client client)
        {
            var client1 = GetClientById(id);
            client1.Id=client.Id;
            client1.Name=client.Name;
            client1.Address=client.Address;
            client1.Payment=client.Payment;
            client1.Phone=client.Phone;
            _dataContext.SaveChanges();
            return client1;
        }
    }
}
