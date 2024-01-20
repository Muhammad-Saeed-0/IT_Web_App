using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webApp.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Course Code")]
        public string Code { get; set; }
        [DisplayName("Course Title")]
        public string CourseTitle { get; set; }
        [DisplayName("L")]
        public int Lecture { get; set; }
        [DisplayName("P/T")]
        public int Practical_Tutorial { get; set; }
        public int Total { get; set; }
        public string Prerequisite { get; set; }
        [DisplayName("CW")]
        public int CourseWork { get; set; }
        [DisplayName("T.E")]
        public int TermExams { get; set; }
        [DisplayName("F.E")]
        public int FinalExam { get; set; }
        [DisplayName("Oral/P")]
        public int Oral_Practical { get; set; }
        [DisplayName("Exam Time (hr)")]
        public int ExamTime { get; set; }
        //public bool IsBasic { get; set; }

        public ICollection<RequirementCourse> RequirementCourses { get; set; }
    }
}
