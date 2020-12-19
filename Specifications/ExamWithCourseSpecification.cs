using System;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class ExamWithCourseSpecification : BaseSpecification<Exam>
    {
        public ExamWithCourseSpecification()
        {
            AddInclude(x => x.Course);
        }

        public ExamWithCourseSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Course);
        }
    }
}