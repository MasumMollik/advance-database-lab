using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using System;
using System.Threading.Tasks;

namespace PerformanceCalculator.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly IDbService<Teacher> _service;

        public DeleteModel(IDbService<Teacher> service)
        {
            _service = service;
        }

        [BindProperty] public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Teacher = await _service.GetByIdAsync(id);
            if (Teacher == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Teacher = await _service.GetByIdAsync(id);
            if (Teacher != null)
            {
                await _service.DeleteAsync(Teacher);
            }

            return RedirectToPage("../Index");
        }
    }
}