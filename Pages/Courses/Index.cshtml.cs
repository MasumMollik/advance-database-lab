using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly IDbService<Course> _service;

        public IndexModel(IDbService<Course> service)
        {
            _service = service;
        }

        public IReadOnlyList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            var spec = new CourseWithTeacherSpecification();
            Course = await _service.ListAsync(spec);
        }
    }
}
