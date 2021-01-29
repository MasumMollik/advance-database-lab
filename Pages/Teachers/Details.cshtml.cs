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
        [BindProperty] public Teacher Teacher { get; set; }

        private readonly IDbService<Teacher> _service;

        public DetailsModel(IDbService<Teacher> service)
        {
            _service = service;
        }

        public IActionResult OnGet(Guid id)
        {
            Teacher = _service.GetByStorageProcedure("SpGetTeacherById", id.ToString());
            if (Teacher == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}