using MediatR;

namespace Application.Queries.GetClientBalance
{
    public class GetClientBalanceQuery : IRequest<GetClientsBalanceQueryResult>
    {
        public Guid ClientId { get; set; }
        public List<string> ToCurrencies { get; set; }

        public GetClientBalanceQuery(Guid clientId, List<string> toCurrency)
        {
            ClientId = clientId;
            ToCurrencies = toCurrency;
        }
    }
}
