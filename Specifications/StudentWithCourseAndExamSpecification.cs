using System;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class StudentWithCourseAndExamSpecification : BaseSpecification<Student>
    {
        public StudentWithCourseAndExamSpecification()
        {
            AddInclude(s => s.Courses);
            AddInclude(s => s.Exams);
        }

        public StudentWithCourseAndExamSpecification(Guid id) : base(s => s.Id == id)
        {
            AddInclude(s => s.Courses);
            AddInclude(s => s.Exams);
        }
    }
}