using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;
using PerformanceCalculator.Specifications;

namespace PerformanceCalculator.Pages.Exams
{
    public class IndexModel : PageModel
    {
        private readonly IDbService<Exam> _service;

        public IndexModel(IDbService<Exam> service)
        {
            _service = service;
        }


        public List<Exam> Exam { get; set; }

        public async Task OnGetAsync()
        {
            var spec = new ExamWithCourseAndTeacherSpecification();
            Exam = await _service.ListAsync(spec);
        }
    }
}