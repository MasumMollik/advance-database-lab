using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class ExamWithCourseSpecification : BaseSpecification<Exam>
    {
        public ExamWithCourseSpecification()
        {
            AddInclude(x => x.Course);
        }
    }
}