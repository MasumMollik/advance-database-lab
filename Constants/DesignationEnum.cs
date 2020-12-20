using System.ComponentModel.DataAnnotations;

namespace PerformanceCalculator.Constants
{
    public enum DesignationEnum
    {
        Director = 0,
        Professor = 1,
        [Display(Name = "Assistant Professor")]
        AssistantProfessor = 2,
        Lecturer = 3
    }
}