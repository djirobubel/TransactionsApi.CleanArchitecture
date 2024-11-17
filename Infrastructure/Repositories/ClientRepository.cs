using Application.Ports.Clients;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<int> RegisterClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            return await _context.SaveChangesAsync();
        }
    }
}
