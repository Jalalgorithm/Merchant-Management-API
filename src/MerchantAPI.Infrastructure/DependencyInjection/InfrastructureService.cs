using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantAPI.Infrastructure.DependencyInjection
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register your infrastructure services here
            // Example: services.AddScoped<IMyService, MyService>();
            return services;
        }
    }
}
