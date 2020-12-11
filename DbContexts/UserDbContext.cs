using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.DbContexts
{
    public class UserDbContext : DbContext

    {
        public UserDbContext([NotNull] DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
    }
}