using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Services
{
    public class DbService<T> : IDbService<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;

        public DbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
            ;
        }

        public async Task CreateAsync(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T model)
        {
            model.UpdatedAt = DateTime.UtcNow;
            _context.Attach(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await _context.Set<T>().AnyAsync(m => m.Id == id);
        }

        public async Task<T> GetModelWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AsSingleQuery().ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}