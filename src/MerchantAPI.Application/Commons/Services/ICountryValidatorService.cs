using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantAPI.Infrastructure.Services.CountryValidator
{
    public interface ICountryValidatorService
    {
        Task<bool> IsValidCountryAsync(string country);
    }
}
