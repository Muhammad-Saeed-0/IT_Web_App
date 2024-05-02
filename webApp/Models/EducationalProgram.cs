using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class EducationalProgram
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Details { get; set; }

        public int RequirementId { get; set; }
        public Requirement Requirement { get; set; }

        public ICollection<ProgramCourse> ProgramCourses { get; set; }
    }
}
