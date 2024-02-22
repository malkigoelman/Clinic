using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;

namespace Mirpaha.Clinic.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddClientAsync(client);
        }

        public async Task AddCommentsAsync(int id, Comment comment)
        {
            var clietn = await _clientRepository.GetClientByIdAsync(id);
            clietn.Comments.Add(comment);
        }

        public async Task DeleteClientAsync(int id)
        {
           await _clientRepository.DeleteClientAsync(id);
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        public async Task UpdateClientAsync(int id, Client client)
        {
           await _clientRepository.UpdateClientAsync(id, client);
        }
        public async Task<IEnumerable<Comment>> GetCommentsAsync(int id)
        {
            return await _clientRepository.GetAllCommentsAsync(id);
        }
    }
}
