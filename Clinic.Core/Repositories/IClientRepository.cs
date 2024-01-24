using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(int id);
        void DeleteClient(int id);
        Client UpdateClient(int id,Client client);
        Client AddClient(Client client);
        Comment AddComments(int id, Comment comment);
        IEnumerable<Comment> GetAllComments(int id);
    }
}
