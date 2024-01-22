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

        public void AddClient(Client client)
        {
            _clientRepository.AddClient(client);
        }

        //public void AddComments(int id, Comment comment)
        //{
        //   _clientRepository.GetClientById(id).Comments.Add(comment);
        //}

        public void DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
        }

        public Client GetClientById(int id)
        {
           return _clientRepository.GetClientById(id);  
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetClients();
        }

        public void UpdateClient(int id, Client client)
        {
            _clientRepository.UpdateClient(id, client);
        }
    }
}
