using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceCalculator.Models
{
    public class Exam : BaseModel
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [Range(0, 100)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalMark { get; set; }
        [Range(0, 100)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ObtainedMark { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}