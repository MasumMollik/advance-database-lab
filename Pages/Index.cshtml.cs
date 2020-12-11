using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PerformanceCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly TeachersService _service;

        public List<Teacher> Teachers { get; set; }

        public IndexModel(ILogger<IndexModel> logger, TeachersService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task OnGet()
        {
            _logger.LogInformation("Index");
            Teachers = await _service.GetAsync();
        }
    }
}