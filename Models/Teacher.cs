using System;
using System.ComponentModel.DataAnnotations;

namespace PerformanceCalculator.Models
{
    public class Teacher : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Designation must be 50 characters or less"), MinLength(5)]
        public string Designation { get; set; }
    }
}