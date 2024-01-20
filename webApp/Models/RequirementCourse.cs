using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webApp.Models
{
    public class RequirementCourse
    {
        public string CourseCode { get; set; }
        public int RequirementId { get; set; }
        public bool IsCompulsory { get; set; }

        [ValidateNever]
        public Requirement Requirement { get; set; }

        [ValidateNever]
        public Course Course { get; set; } 
    }
}
