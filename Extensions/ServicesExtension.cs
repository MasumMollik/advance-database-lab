using Microsoft.Extensions.DependencyInjection;
using PerformanceCalculator.Services;

namespace PerformanceCalculator.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<TeachersService>();

            return services;
        }
    }
}