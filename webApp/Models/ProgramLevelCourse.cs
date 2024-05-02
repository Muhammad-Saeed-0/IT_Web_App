using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webApp.Models
{
    public class ProgramLevelCourse
    {
        public string CourseCode { get; set; }
        public int StudyPlanProgramLevelId { get; set; }
        public bool SemesterOne { get; set; }
        public bool SemesterTwo { get; set; }

        [ValidateNever]
        public StudyPlanProgramLevel StudyPlanProgramLevel { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
    }
}
