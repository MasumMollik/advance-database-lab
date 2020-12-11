using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System.Collections.Generic;

namespace PerformanceCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly UserDbService _service;
        public List<Teacher> Teachers { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, UserDbService service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {
            _logger.LogInformation("Index");
            Teachers = _service.Get();
        }
    }
}