using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IDbService<Student> _service;

        public IndexModel(IDbService<Student> service)
        {
            _service = service;
        }

        public IReadOnlyList<Student> Student { get; set; }

        public async Task OnGetAsync()
        {
            Student = await _service.GetAsync();
        }
    }
}