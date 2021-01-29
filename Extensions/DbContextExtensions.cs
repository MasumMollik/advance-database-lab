using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerformanceCalculator.DbContexts;

namespace PerformanceCalculator.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddContexts(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"))
            );
            return services;
        }
    }
}