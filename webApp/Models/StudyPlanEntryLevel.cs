namespace webApp.Models
{
    public class StudyPlanEntryLevel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<EntryLevelCourse> EntryLevelCourses { get; set; }
    }
}
