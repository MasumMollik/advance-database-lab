using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceCalculator.DbContexts;
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


        public IReadOnlyList<Exam> Exam { get; set; }

        public async Task OnGetAsync()
        {
            var spec = new ExamWithCourseSpecification();

            Exam = await _service.ListAsync(spec);
        }
    }
}