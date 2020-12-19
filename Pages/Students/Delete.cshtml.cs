using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IDbService<Student> _service;

        public DeleteModel(IDbService<Student> service)
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

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var spec = new StudentWithCourseAndExamSpecification(id);
            Student = await _service.GetModelWithSpec(spec);

            if (Student != null)
            {
                await _service.DeleteAsync(Student);
            }

            return RedirectToPage("./Index");
        }
    }
}