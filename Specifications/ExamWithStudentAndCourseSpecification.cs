using System;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class ExamWithStudentAndCourseSpecification : BaseSpecification<Student>
    {
        public ExamWithStudentAndCourseSpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Exams);
            AddInclude(x => x.Courses);
        }

        public ExamWithStudentAndCourseSpecification()
        {
            AddInclude(x => x.Exams);
            AddInclude(x => x.Courses);
        }
    }
}