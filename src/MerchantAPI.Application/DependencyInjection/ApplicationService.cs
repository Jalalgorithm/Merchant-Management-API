using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MerchantAPI.Application.Commons.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantAPI.Application.DependencyInjection
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ApplicationService).Assembly , includeInternalTypes: true);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ApplicationService).Assembly);
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
