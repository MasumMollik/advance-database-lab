using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;

namespace PerformanceCalculator.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        [BindProperty] 
        public Teacher Teacher { get; set; }

        private readonly IDbService<Teacher> _service;

        public DetailsModel(IDbService<Teacher> service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Teacher = await _service.GetByIdAsync(id);
            if (Teacher == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}