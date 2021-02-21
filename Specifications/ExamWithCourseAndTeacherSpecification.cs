using System;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class ExamWithCourseAndTeacherSpecification : BaseSpecification<Exam>
    {
        public ExamWithCourseAndTeacherSpecification()
        {
            AddInclude(x => x.Course);
            AddInclude(x => x.Teacher);
        }
        public ExamWithCourseAndTeacherSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Course);
            AddInclude(x => x.Teacher);
        }
    }
}