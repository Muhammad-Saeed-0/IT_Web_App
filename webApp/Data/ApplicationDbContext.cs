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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, Name = "Muhammad Saeed", Job = "Demonstrator", Degree = "Bachelor of Information Technology.", Major = "IT", Email = "muhammad.saeed@su.edu.eg", Phone = "0102222222" },
                new Staff { Id = 2, Name = "test", Job = "test", Degree = "test", Major = "test", Email = "test2", Phone = "test1" });

            //
            modelBuilder.Entity<Staff>().HasIndex(p => new { p.Email }).IsUnique();
            modelBuilder.Entity<Staff>().HasIndex(p => new { p.Phone }).IsUnique();
            modelBuilder.Entity<StudyPlan>().HasIndex(p => new { p.Level }).IsUnique();

            //
            modelBuilder.Entity<RequirementCourse>().HasKey(p => new { p.CourseCode, p.RequirementId });
            modelBuilder.Entity<StudyPlanCourse>().HasKey(p => new { p.CourseCode, p.StudyPlanId });
        }
    }
}
