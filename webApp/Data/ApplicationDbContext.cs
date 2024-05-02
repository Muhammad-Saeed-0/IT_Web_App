using Microsoft.EntityFrameworkCore;
using webApp.Models;

namespace webApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Staff> StaffMembers { get; set; }
        public DbSet<Research> Researches { get; set; }
        public DbSet<StaffLink> StaffLinks { get; set; }
        public DbSet<ScientificAchievement> ScientificAchievements { get; set; }
        public DbSet<RequirementCourse> RequirementCourses { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyPlanCourse> StudyPlanCourses { get; set; }
        public DbSet<EducationalProgram> EducationalProgram { get; set; }
        public DbSet<ProgramCourse> ProgramCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, Name = "Muhammad Saeed", Job = "Demonstrator", Degree = "Bachelor of Information Technology.", Major = "IT", Email = "muhammad.saeed@su.edu.eg", Phone = "0102222222" });

            //1-1
            modelBuilder.Entity<Course>().HasData(
               new Course { Code = "CSW 110", CourseTitle = "Introduction to Computer & Internet Technology", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "No Prerequisite", CourseWork = 5, TermExams = 25, OralPractical = 10, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
               new Course { Code = "Hu 110", CourseTitle = "English Language", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "No Prerequisite", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 2 });

            //1-2
            modelBuilder.Entity<Course>().HasData(
                           new Course { Code = "CSW 232", CourseTitle = "Computer Programming (1)", Lecture = 3, PracticalTutorial = 2, Total = 4, Prerequisite = "CSW 110 Introduction to Computer & Internet Technology", CourseWork = 5, TermExams = 25, OralPractical = 10, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                          new Course { Code = "Hu 111", CourseTitle = "Composition + Technical Writing", Lecture = 3, PracticalTutorial = 0, Total = 3, Prerequisite = "No Prerequisite", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            //2-1
            modelBuilder.Entity<Course>().HasData(
                           new Course { Code = "CSW 221", CourseTitle = "Data Structure", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "Ma 110 Linear Algebra", CourseWork = 5, TermExams = 25, OralPractical = 10, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                           new Course { Code = "CSW 234", CourseTitle = "Computer Programming (2)", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "CSW 241 File Organization & Processing", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            //2-2
            modelBuilder.Entity<Course>().HasData(
                          new Course { Code = "CSW 242", CourseTitle = "Operating Systems (1)", Lecture = 3, PracticalTutorial = 2, Total = 4, Prerequisite = "CSW 232 Computer Programming (1)", CourseWork = 5, TermExams = 25, OralPractical = 10, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                          new Course { Code = "Hu 212", CourseTitle = "Reading & Presentation Skills", Lecture = 2, PracticalTutorial = 0, Total = 2, Prerequisite = "No Prerequisite", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                        new Course { Code = "BS 209", CourseTitle = "Operations Research", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "BS 104 Prob. and Static.", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                       new Course { Code = "IT 203", CourseTitle = "Computer Networks", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "IT 203 Data Comunications", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                       new Course { Code = "IT 204", CourseTitle = "Web Programming", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "No Prerequisite", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                      new Course { Code = "CS 313", CourseTitle = "Machine Learning", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "CS 103 Object Programming", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            modelBuilder.Entity<Course>().HasData(
                      new Course { Code = "IS 323", CourseTitle = "Web Applications", Lecture = 2, PracticalTutorial = 2, Total = 3, Prerequisite = "IT 204 Web Programming", CourseWork = 15, TermExams = 25, OralPractical = 0, FinalExam = 60, ExamTime = 3 });

            //
            modelBuilder.Entity<Staff>().HasIndex(p => new { p.Email }).IsUnique();
            modelBuilder.Entity<Staff>().HasIndex(p => new { p.Phone }).IsUnique();
            modelBuilder.Entity<StudyPlan>().HasIndex(p => new { p.Level }).IsUnique();

            //
            modelBuilder.Entity<RequirementCourse>().HasKey(p => new { p.CourseCode, p.RequirementId });
            modelBuilder.Entity<ProgramCourse>().HasKey(p => new { p.CourseCode, p.EducationalProgramId });
            modelBuilder.Entity<StudyPlanCourse>().HasKey(p => new { p.CourseCode, p.StudyPlanId });

        }
    }
}
