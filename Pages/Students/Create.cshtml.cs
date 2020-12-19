using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;

namespace PerformanceCalculator.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IDbService<Student> _service;

        public CreateModel(IDbService<Student> service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            await _service.CreateAsync(Student);

            return RedirectToPage("./Index");
        }
    }
}
