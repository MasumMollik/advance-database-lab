using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.DbContexts;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly IDbService<Course> _courseService;


        public DetailsModel(IDbService<Course> courseService)
        {
            _courseService = courseService;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var spec = new CourseWithTeacherSpecification(id);
            Course = await _courseService.GetModelWithSpec(spec);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}