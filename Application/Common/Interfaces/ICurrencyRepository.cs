namespace Application.Common.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<Dictionary<string, decimal>> GetCurrencyRatesAsync(List<string> currencies);
    }
}
