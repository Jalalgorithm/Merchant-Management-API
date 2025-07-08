using MerchantAPI.WebAPIServer.Exceptions;

namespace MerchantAPI.WebAPIServer.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddWebAPIServer(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            return services;
        }

        //public static IApplicationBuilder UsePresentation(this IApplicationBuilder app)
        //{
        //    app.
        //    return app;
        //}
    }
}
