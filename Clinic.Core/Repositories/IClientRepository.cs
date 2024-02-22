using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> AddClientAsync(Client client);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task DeleteClientAsync(int id);
        Task<Client> UpdateClientAsync(int id, Client client);
        Task<Comment> AddCommentsAsync(int id, Comment comment);
        Task<IEnumerable<Comment>> GetAllCommentsAsync(int id);
    }
}
