using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Exams
{
    public class DetailsModel : PageModel
    {
        private readonly IDbService<Exam> _service;

        public DetailsModel(IDbService<Exam> service)
        {
            _service = service;
        }

        public Exam Exam { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {

            var spec = new ExamWithCourseSpecification(id);
            Exam = await _service.GetModelWithSpec(spec);

            if (Exam == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}