using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int id);
        void DeleteClient(int id);
        void UpdateClient(int id,Client client);
        void AddClient(Client client);
    }
}
