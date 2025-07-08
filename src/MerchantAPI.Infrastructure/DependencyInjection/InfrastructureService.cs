using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantAPI.Application.Commons.Data;
using MerchantAPI.Infrastructure.Persistence;
using MerchantAPI.Infrastructure.Services.CountryValidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MerchantAPI.Infrastructure.DependencyInjection
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddHttpClient<ICountryValidatorService , CountryValidatorService>();
            services.AddDatabase();
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>options.UseInMemoryDatabase("MerchantAPIDb"));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
          
            return services;
        }

        public static async Task SeedDatabaseAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (!dbContext.Database.IsInMemory())
            {
                await dbContext.Database.EnsureCreatedAsync();
            }
            await ApplicationDbSeeder.SeedAsync(dbContext);
        }
    }
}
