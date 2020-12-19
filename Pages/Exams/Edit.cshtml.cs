using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Exams
{
    public class EditModel : PageModel
    {
        private readonly IDbService<Exam> _examService;
        private readonly IDbService<Course> _courseService;

        public EditModel(IDbService<Exam> examService, IDbService<Course> courseService)
        {
            _examService = examService;
            _courseService = courseService;
        }

        [BindProperty] public Exam Exam { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var spec = new ExamWithCourseSpecification(id);
            Exam = await _examService.GetModelWithSpec(spec);
            if (Exam == null)
            {
                return NotFound();
            }

            var courses = (await _courseService.GetAsync());
            ViewData["CourseTitle"] = new SelectList(courses, "Id", "Title");

            return Page();
        }

        // To protect from over posting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _examService.UpdateAsync(Exam);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _examService.IsExists(Exam.Id)))
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