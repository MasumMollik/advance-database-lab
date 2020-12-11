using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceCalculator.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly IDbService<Course> _courseService;
        private readonly IDbService<Teacher> _teacherService;

        public EditModel(IDbService<Course> courseService, IDbService<Teacher> teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        [BindProperty] public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var spec = new CourseWithTeacherSpecification(id);
            Course = await _courseService.GetModelWithSpec(spec);

            if (Course == null)
            {
                return NotFound();
            }

            var teachers = await _teacherService.GetAsync();
            ViewData["TeacherName"] =
                new SelectList(teachers.Select(t => new {Id = t.Id, FullName = $"{t.FirstName} {t.LastName}"}), "Id",
                    "FullName");

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
                await _courseService.UpdateAsync(Course);
            }
            catch (DbUpdateConcurrencyException)
            {
                var isCourseExists = await _courseService.IsExists(Course.Id);
                if (!isCourseExists)
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