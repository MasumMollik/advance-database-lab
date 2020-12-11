using System;

namespace PerformanceCalculator.Models
{
    public class Teacher : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Designation { get; set; }
    }
}