using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceCalculator.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly IDbService<Course> _courseService;
        private readonly IDbService<Teacher> _teacherService;

        public CreateModel(IDbService<Course> courseService, IDbService<Teacher> teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> OnGet()
        {
            var teachers = await _teacherService.GetAsync();
            ViewData["TeacherName"] =
                new SelectList(teachers.Select(t => new {Id = t.Id, FullName = $"{t.FirstName} {t.LastName}"}), "Id",
                    "FullName");

            return Page();
        }

        [BindProperty] public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            await _courseService.CreateAsync(Course);

            return RedirectToPage("./Index");
        }
    }
}