using Application.Common.Dtos;

namespace Application.Queries.GetClientTransactions
{
    public class GetClientTransactionsQueryResult
    {
        public List<GetClientTransactionsDto>? Transactions { get; set; }
    }
}
