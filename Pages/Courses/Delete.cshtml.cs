using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;
using System;
using System.Threading.Tasks;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly IDbService<Course> _service;

        public DeleteModel(IDbService<Course> service)
        {
            _service = service;
        }

        [BindProperty] public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spec = new CourseWithTeacherSpecification();

            Course = (await _service.GetModelWithSpec(spec));

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Course = await _service.GetByIdAsync(id);

            if (Course != null)
            {
                await _service.DeleteAsync(Course);
            }

            return RedirectToPage("./Index");
        }
    }
}