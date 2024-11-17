using Application.Ports.Transactions;
using MediatR;

namespace Application.Queries.GetClientTransactions
{
    public class GetClientTransactionsQueryHandler : IRequestHandler<GetClientTransactionsQuery,
       GetClientTransactionsQueryResult>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetClientTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<GetClientTransactionsQueryResult> Handle(
            GetClientTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetClientTransactions(
                request.ClientId, request.PageNumber, request.PageSize, request.SortBy, request.IsAscending);

            var result = transactions.Select(x => new GetClientTransactionsDto
            {
                Amount = x.Amount,
                TransactionComment = x.TransactionComment,
                TransactionDate = x.TransactionDate
            }).ToList();

            return new GetClientTransactionsQueryResult
            {
                Transactions = result
            };
        }
    }
}
