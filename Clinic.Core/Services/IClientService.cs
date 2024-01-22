using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int id);
        void DeleteClient(int id);
        void AddClient(Client client);
        void UpdateClient(int id,Client client);
        //void AddComments(int id,Comment comment);
    }
}
