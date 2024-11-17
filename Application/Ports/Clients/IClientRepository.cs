using Domain.Entities;

namespace Application.Ports.Clients
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<int> RegisterClientAsync(Client client);
    }
}
