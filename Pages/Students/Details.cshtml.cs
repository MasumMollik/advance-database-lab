using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IDbService<Student> _studentService;
        private readonly IDbService<Course> _courseService;
        private readonly IDbService<Exam> _examService;

        public DetailsModel(IDbService<Student> studentService, IDbService<Course> courseService,
            IDbService<Exam> examService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _examService = examService;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var spec = new StudentWithCourseAndExamSpecification(id);
            Student = await _studentService.GetModelWithSpec(spec);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}