using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Pages.Exams
{
    public class DetailsModel : PageModel
    {
        private readonly PerformanceCalculator.DbContexts.ApplicationDbContext _context;

        public DetailsModel(PerformanceCalculator.DbContexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public Exam Exam { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exam = await _context.Exams
                .Include(e => e.Course).FirstOrDefaultAsync(m => m.Id == id);

            if (Exam == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
