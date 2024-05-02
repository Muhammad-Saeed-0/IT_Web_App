using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webApp.Models
{
    public class StudyPlanProgramLevel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int EducationalProgramId { get; set; }

        [ValidateNever]
        public EducationalProgram EducationalProgram { get; set; }

        public ICollection<ProgramLevelCourse> ProgramLevelCourses { get; set; }
    }
}
