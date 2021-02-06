using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext([NotNull] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateDbIndex(modelBuilder);
            modelBuilder.Entity<Exam>()
                .Property(e => e.ObtainedMark)
                .HasDefaultValue(0.00);
            
            modelBuilder.Entity<Exam>()
                .HasOne<Teacher>(e => e.Teacher)
                .WithOne(t => t.Exam)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithOne(t => t.Course)
                .OnDelete(DeleteBehavior.NoAction);
            
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken));
        }

        private static void CreateDbIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Id);
            modelBuilder.Entity<Exam>()
                .HasIndex(e => e.Id);
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.Id);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseModel,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseModel trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedAt = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedAt = utcNow;
                            trackable.UpdatedAt = utcNow;
                            break;
                    }
                }
            }
        }
    }
}