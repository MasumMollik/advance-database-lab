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

        public List<Course> Courses { get; set; }
    }

    public class Course : BaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Credit { get; set; }
    }
}