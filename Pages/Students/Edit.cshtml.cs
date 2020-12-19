using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IDbService<Student> _service;

        public EditModel(IDbService<Student> service)
        {
            _service = service;
        }

        [BindProperty] public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var spec = new StudentWithCourseAndExamSpecification(id);
            Student = await _service.GetModelWithSpec(spec);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _service.UpdateAsync(Student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _service.IsExists(Student.Id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}