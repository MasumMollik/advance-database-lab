using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System.Threading.Tasks;

namespace PerformanceCalculator.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly TeachersService _service;

        public CreateModel(TeachersService service)
        {
            _service = service;
        }

        [BindProperty] public Teacher Teacher { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.CreateAsync(Teacher);
            return RedirectToPage("../Index");
        }
    }
}