using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerformanceCalculator.Services
{
    public class TeachersService : IDbService<Teacher>
    {
        private readonly ApplicationDbContext _context;

        public TeachersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(Guid id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);
        }

        public async Task CreateAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Attach(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await _context.Teachers.AnyAsync(teacher => teacher.Id == id);
        }
    }
}