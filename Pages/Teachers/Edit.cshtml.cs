using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;

namespace PerformanceCalculator.Pages.Teachers
{
    public class EditModel : PageModel
    {
        [BindProperty] public Teacher Teacher { get; set; }

        private readonly IDbService<Teacher> _service;

        public EditModel(IDbService<Teacher> service)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _service.UpdateAsync(Teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                var isExist = await _service.IsExists(Teacher.Id);
                if (!isExist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }
    }
}