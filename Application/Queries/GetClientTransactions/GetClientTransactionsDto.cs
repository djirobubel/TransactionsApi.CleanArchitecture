namespace Application.Queries.GetClientTransactions
{
    public class GetClientTransactionsDto
    {
        public decimal Amount { get; set; }
        public string? TransactionComment { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
