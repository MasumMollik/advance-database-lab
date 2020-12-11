using System;

namespace PerformanceCalculator.Models
{
    public class Course : BaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Credit { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}