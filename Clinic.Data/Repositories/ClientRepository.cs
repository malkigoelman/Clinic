using Microsoft.EntityFrameworkCore;
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

        public async Task<Client> AddClientAsync(Client client)
        {
            _dataContext.Clients.Add(client);
            await _dataContext.SaveChangesAsync();
            return client;
        }

        public async Task<Comment> AddCommentsAsync(int id, Comment comment)
        {
            var client = _dataContext.Clients.Find(id);
            client.Comments.Add(comment);
            await _dataContext.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteClientAsync(int id)
        {
            var client =await GetClientByIdAsync(id);
            _dataContext.Clients.Remove(client);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(int id)
        {
            var client = await GetClientByIdAsync(id);
            return client.Comments;

        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _dataContext.Clients.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _dataContext.Clients.ToListAsync();
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            var client1 = await GetClientByIdAsync(id);
            client1.Id = client.Id;
            client1.Name = client.Name;
            client1.Address = client.Address;
            client1.Payment = client.Payment;
            client1.Phone = client.Phone;
            await _dataContext.SaveChangesAsync();
            return client1;
        }
    }
}
