using Application.Common.Dtos;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Queries.GetClientBalance
{
    public class GetClientBalanceQueryHandler : IRequestHandler<GetClientBalanceQuery, GetClientsBalanceQueryResult>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public GetClientBalanceQueryHandler(
            ITransactionRepository transactionRepository, ICurrencyRepository currencyRepository)
        {
            _transactionRepository = transactionRepository;
            _currencyRepository = currencyRepository;
        }

        public async Task<GetClientsBalanceQueryResult> Handle(
            GetClientBalanceQuery request, CancellationToken cancellationToken)
        {
            var amount = await _transactionRepository.GetClientsCurrentBalanceAsync(request.ClientId);

            var currencyRates = await _currencyRepository.GetCurrencyRatesAsync(request.ToCurrencies);

            var result = currencyRates.Select(currencyRate => new ClientBalanceDto
            {
                ClientsCurrentBalance = amount * currencyRate.Value,
                Currency = currencyRate.Key
            }).ToList();

            return new GetClientsBalanceQueryResult
            {
                Balance = result
            };
        }
    }
}
