namespace Application.Common.Dtos
{
    public class GetClientTransactionsDto
    {
        public decimal Amount { get; set; }
        public string? TransactionComment { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
