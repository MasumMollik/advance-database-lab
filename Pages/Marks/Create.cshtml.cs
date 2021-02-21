using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceCalculator.Services;
using PerformanceCalculator.Models;
using System.Threading.Tasks;
using System;
using PerformanceCalculator.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceCalculator.Pages.Marks
{
    // TODO: map student to course
    // exam -> courseId -> students
    public class CreateModel : PageModel
    {
        private readonly IDbService<Exam> _examService;
         private readonly IDbService<Student> _studentService;
         private readonly IDbService<Course> _courseService;

        public CreateModel(IDbService<Exam> examService, IDbService<Student> studentService, IDbService<Course> courseService )
        {
            _examService = examService;
            _studentService = studentService;
            _courseService = courseService;
        }
        public Exam Exam { get; set; }
        public  List<Student> Students { get; set;}
        public Course Course {get; set;}
        public async Task OnGetAsync(Guid id)
        {
            var spec = new ExamWithCourseAndTeacherSpecification(id);
            
            Exam = await _examService.GetModelWithSpec(spec);
            Course = await _courseService.GetByIdAsync(Exam.CourseId);

            var stdentSpec = new ExamWithStudentAndCourseSpecification();

            var students = await _studentService.ListAsync(stdentSpec);
            Students = students.Where(s => s.Courses.Any(c => c.Id == Course.Id)).ToList();
        }
    }
}