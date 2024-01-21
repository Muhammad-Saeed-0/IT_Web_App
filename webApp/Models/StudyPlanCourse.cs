using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webApp.Models
{
    public class StudyPlanCourse
    {
        public string CourseCode { get; set; }
        public int StudyPlanId { get; set; }

        [ValidateNever]
        public StudyPlan StudyPlan { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
    }
}
