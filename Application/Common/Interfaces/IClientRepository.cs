using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsAsync();
        Task<int> RegisterClientAsync(Client client);
    }
}
