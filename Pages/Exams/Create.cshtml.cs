using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Pages.Exams
{
    public class CreateModel : PageModel
    {
        private readonly PerformanceCalculator.DbContexts.ApplicationDbContext _context;

        public CreateModel(PerformanceCalculator.DbContexts.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Exam Exam { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exams.Add(Exam);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
