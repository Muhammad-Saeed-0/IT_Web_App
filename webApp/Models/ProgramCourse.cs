using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webApp.Models
{
    public class ProgramCourse
    {
        public string CourseCode { get; set; }
        public int EducationalProgramId { get; set; }
        public bool IsCompulsory { get; set; }

        [ValidateNever]
        public EducationalProgram EducationalProgram { get; set; }

        [ValidateNever]
        public Course Course { get; set; } 
    }
}
