using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantAPI.Infrastructure.Services.CountryValidator
{
    public class CountryValidatorService : ICountryValidatorService
    {
        private readonly HttpClient _httpClient;

        public CountryValidatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsValidCountryAsync(string country)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{Uri.EscapeDataString(country)}?fullText=true");

            return response.IsSuccessStatusCode;
        }
    }
}
