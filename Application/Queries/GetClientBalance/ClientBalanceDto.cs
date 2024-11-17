namespace Application.Queries.GetClientBalance
{
    public class ClientBalanceDto
    {
        public decimal ClientsCurrentBalance { get; set; }
        public string? Currency { get; set; }
    }
}
