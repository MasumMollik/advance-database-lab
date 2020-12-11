using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.DbContexts
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}