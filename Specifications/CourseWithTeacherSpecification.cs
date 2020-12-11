using System;
using PerformanceCalculator.Models;

namespace PerformanceCalculator.Specifications
{
    public class CourseWithTeacherSpecification : BaseSpecification<Course>
    {
        public CourseWithTeacherSpecification()
        {
            AddInclude(x => x.Teacher);
        }

        public CourseWithTeacherSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Teacher);
        }
    }
}