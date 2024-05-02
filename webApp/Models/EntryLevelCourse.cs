using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webApp.Models
{
    public class EntryLevelCourse
    {
        public string CourseCode { get; set; }
        public int StudyPlanEntryLevelId { get; set; }
        public bool SemesterOne { get; set; }
        public bool SemesterTwo { get; set; }

        [ValidateNever]
        public StudyPlanEntryLevel StudyPlanEntryLevel { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
    }
}
