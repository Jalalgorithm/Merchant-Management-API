using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantAPI.Application.DependencyInjection
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services here
            return services;
        }
    }
}
