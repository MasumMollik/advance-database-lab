using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerformanceCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDbService<Teacher> _service;

        public IReadOnlyList<Teacher> Teachers { get; set; }

        public IndexModel(IDbService<Teacher> service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            Teachers = await _service.GetAsync();
        }
    }
}