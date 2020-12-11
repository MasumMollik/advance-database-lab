using System;

namespace PerformanceCalculator.Models
{
    public class Exam : BaseModel
    {
        public string Title { get; set; }
        public decimal Mark { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}