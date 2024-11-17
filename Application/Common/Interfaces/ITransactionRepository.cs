using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ITransactionRepository
    {
        Task<int> CreateTransactionAsync(Transaction transaction);
        Task<decimal> GetClientsCurrentBalanceAsync(Guid clientId);
        Task<List<Transaction>> GetClientTransactions(
            Guid clientId, int pageNumber, int pageSize, string sortBy, bool isAscending);
    }
}
