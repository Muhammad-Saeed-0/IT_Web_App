namespace webApp.Models
{
    public class StudyPlan
    {
        public int Id { get; set; }
        public string Level { get; set; }

        public ICollection<StudyPlanCourse> StudyPlanCourses { get; set; }
    }
}
