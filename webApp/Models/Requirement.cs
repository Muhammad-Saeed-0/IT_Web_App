﻿namespace webApp.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalHours { get; set; }
        public string Details { get; set; }

        public string RegulationCode { get; set; }
        public Regulation Regulation { get; set; }

        public ICollection<RequirementCourse> RequirementCourses { get; set; }
        public ICollection<EducationalProgram> EducationalPrograms { get; set; }
    }
}
