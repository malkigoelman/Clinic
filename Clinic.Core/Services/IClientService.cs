using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task DeleteClientAsync(int id);
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(int id, Client client);
        Task AddCommentsAsync(int id, Comment comment);
        Task<IEnumerable<Comment>> GetCommentsAsync(int id);
    }
}
