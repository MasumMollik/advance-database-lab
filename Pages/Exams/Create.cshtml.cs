using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceCalculator.Pages.Exams
{
    public class CreateModel : PageModel
    {
        private readonly IDbService<Exam> _examService;
        private readonly IDbService<Course> _courseService;
        private readonly IDbService<Teacher> _teacherService;

        public CreateModel(IDbService<Course> courseService, IDbService<Exam> examService,
            IDbService<Teacher> teacherService)
        {
            _examService = examService;
            _courseService = courseService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> OnGet()
        {
            var courses = await _courseService.GetAsync();
            var teachers = await _teacherService.GetAsync();

            ViewData["CourseTitle"] = new SelectList(courses, "Id", "Title");
            ViewData["TeacherName"] =
                new SelectList(teachers.Select(t => new {Id = t.Id, FullName = $"{t.FirstName} {t.LastName}"}), "Id",
                    "FullName");
            return Page();
        }

        [BindProperty] public Exam Exam { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _examService.CreateAsync(Exam);

            return RedirectToPage("./Index");
        }
    }
}