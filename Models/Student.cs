using System;
using System.Collections.Generic;

namespace PerformanceCalculator.Models
{
    public class Student : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string PhoneNo { get; set; }
        public List<Course> Courses { get; set; }
        public List<Exam> Exams { get; set; }
    }
}