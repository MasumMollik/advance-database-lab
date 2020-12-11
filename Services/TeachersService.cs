using System;
using System.Collections.Generic;
using System.Linq;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Services
{
    public class TeachersService
    {
        private readonly UserDbContext _context;

        public TeachersService(UserDbContext context)
        {
            _context = context;
        }

        public List<Teacher> Get()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetById(Guid id)
        {
            return _context.Teachers.FirstOrDefault(t => t.Id == id);
        }

        public void Create(Teacher teacher)
        {
            teacher.Id = Guid.NewGuid();
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
    }
}