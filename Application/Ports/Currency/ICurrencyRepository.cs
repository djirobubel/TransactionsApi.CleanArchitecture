namespace Application.Ports.Currency
{
    public interface ICurrencyRepository
    {
        Task<Dictionary<string, decimal>> GetCurrencyRatesAsync(List<string> currencies);
    }
}
