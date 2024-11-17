using Application.Common.Interfaces;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public CurrencyRepository(HttpClient httpClient, string apiUrl, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _apiUrl = apiUrl;
        }

        public async Task<Dictionary<string, decimal>> GetCurrencyRatesAsync(List<string> currencies)
        {
            var url = $"{_apiUrl}?access_key={_apiKey}&symbols={string.Join(",", currencies)}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error while getting exchange rates: {response.StatusCode}.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var rates = JObject.Parse(content)["rates"];

            var currenceRates = new Dictionary<string, decimal>();

            foreach (var currency in currencies)
            {
                if (rates[currency] == null)
                {
                    throw new Exception($"Exchange rate for currency {currency} is not found.");
                }
            }

            for (int i = 0; i < currencies.Count; i++)
            {
                currenceRates[currencies[i]] = (decimal)rates[currencies[i]];
            }

            return currenceRates;
        }
    }
}
