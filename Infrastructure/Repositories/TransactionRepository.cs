using Application.Ports.Transactions;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            return await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetClientsCurrentBalanceAsync(Guid clientId)
        {
            return await _context.Transactions.Where(x => x.ClientId == clientId).SumAsync(x => x.Amount);
        }

        public async Task<List<Transaction>> GetClientTransactions(
            Guid clientId, int pageNumber, int pageSize, string sortBy, bool isAscending)
        {
            var transactions = _context.Transactions.Where(x => x.ClientId == clientId).AsQueryable();

            transactions = sortBy.ToLower() switch
            {
                "amount" => isAscending ? transactions.OrderBy(x => x.Amount) :
                transactions.OrderByDescending(x => x.Amount),

                "transactiondate" => isAscending ? transactions.OrderBy(x => x.TransactionDate) :
                transactions.OrderByDescending(x => x.TransactionDate),

                _ => transactions.OrderBy(x => x.TransactionDate)
            };

            return await transactions.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
