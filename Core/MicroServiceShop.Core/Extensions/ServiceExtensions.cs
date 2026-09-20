using MicroServiceShop.Core.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServiceShop.Core.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomExceptionHandling(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlingMiddleware>();
            return services;
        }
    }
}
