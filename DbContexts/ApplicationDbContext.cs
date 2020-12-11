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
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}