﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApp.Data;

#nullable disable

namespace webApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240502114808_CreateDB2")]
    partial class CreateDB2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webApp.Models.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseWork")
                        .HasColumnType("int");

                    b.Property<int>("ExamTime")
                        .HasColumnType("int");

                    b.Property<int>("FinalExam")
                        .HasColumnType("int");

                    b.Property<int>("Lecture")
                        .HasColumnType("int");

                    b.Property<int>("OralPractical")
                        .HasColumnType("int");

                    b.Property<int>("PracticalTutorial")
                        .HasColumnType("int");

                    b.Property<string>("Prerequisite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TermExams")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Code = "CSW 110",
                            CourseTitle = "Introduction to Computer & Internet Technology",
                            CourseWork = 5,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 2,
                            OralPractical = 10,
                            PracticalTutorial = 2,
                            Prerequisite = "No Prerequisite",
                            TermExams = 25,
                            Total = 3
                        },
                        new
                        {
                            Code = "Hu 110",
                            CourseTitle = "English Language",
                            CourseWork = 15,
                            ExamTime = 2,
                            FinalExam = 60,
                            Lecture = 2,
                            OralPractical = 0,
                            PracticalTutorial = 2,
                            Prerequisite = "No Prerequisite",
                            TermExams = 25,
                            Total = 3
                        },
                        new
                        {
                            Code = "CSW 232",
                            CourseTitle = "Computer Programming (1)",
                            CourseWork = 5,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 3,
                            OralPractical = 10,
                            PracticalTutorial = 2,
                            Prerequisite = "CSW 110 Introduction to Computer & Internet Technology",
                            TermExams = 25,
                            Total = 4
                        },
                        new
                        {
                            Code = "Hu 111",
                            CourseTitle = "Composition + Technical Writing",
                            CourseWork = 15,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 3,
                            OralPractical = 0,
                            PracticalTutorial = 0,
                            Prerequisite = "No Prerequisite",
                            TermExams = 25,
                            Total = 3
                        },
                        new
                        {
                            Code = "CSW 221",
                            CourseTitle = "Data Structure",
                            CourseWork = 5,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 2,
                            OralPractical = 10,
                            PracticalTutorial = 2,
                            Prerequisite = "Ma 110 Linear Algebra",
                            TermExams = 25,
                            Total = 3
                        },
                        new
                        {
                            Code = "CSW 234",
                            CourseTitle = "Computer Programming (2)",
                            CourseWork = 15,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 2,
                            OralPractical = 0,
                            PracticalTutorial = 2,
                            Prerequisite = "CSW 241 File Organization & Processing",
                            TermExams = 25,
                            Total = 3
                        },
                        new
                        {
                            Code = "CSW 242",
                            CourseTitle = "Operating Systems (1)",
                            CourseWork = 5,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 3,
                            OralPractical = 10,
                            PracticalTutorial = 2,
                            Prerequisite = "CSW 232 Computer Programming (1)",
                            TermExams = 25,
                            Total = 4
                        },
                        new
                        {
                            Code = "Hu 212",
                            CourseTitle = "Reading & Presentation Skills",
                            CourseWork = 15,
                            ExamTime = 3,
                            FinalExam = 60,
                            Lecture = 2,
                            OralPractical = 0,
                            PracticalTutorial = 0,
                            Prerequisite = "No Prerequisite",
                            TermExams = 25,
                            Total = 2
                        });
                });

            modelBuilder.Entity("webApp.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("webApp.Models.EducationalProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequirementId");

                    b.ToTable("EducationalProgram");
                });

            modelBuilder.Entity("webApp.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("EndAt")
                        .HasColumnType("time");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("StartAt")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("webApp.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MainImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("webApp.Models.NewsImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsImages");
                });

            modelBuilder.Entity("webApp.Models.ProgramCourse", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EducationalProgramId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompulsory")
                        .HasColumnType("bit");

                    b.HasKey("CourseCode", "EducationalProgramId");

                    b.HasIndex("EducationalProgramId");

                    b.ToTable("ProgramCourses");
                });

            modelBuilder.Entity("webApp.Models.Regulation", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Regulations");
                });

            modelBuilder.Entity("webApp.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegulationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegulationCode");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("webApp.Models.RequirementCourse", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompulsory")
                        .HasColumnType("bit");

                    b.HasKey("CourseCode", "RequirementId");

                    b.HasIndex("RequirementId");

                    b.ToTable("RequirementCourses");
                });

            modelBuilder.Entity("webApp.Models.Research", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfPublication")
                        .HasColumnType("date");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supervisors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Researches");
                });

            modelBuilder.Entity("webApp.Models.ScientificAchievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("ScientificAchievements");
                });

            modelBuilder.Entity("webApp.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("StaffMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Degree = "Bachelor of Information Technology.",
                            Email = "muhammad.saeed@su.edu.eg",
                            Job = "Demonstrator",
                            Major = "IT",
                            Name = "Muhammad Saeed",
                            Phone = "0102222222"
                        });
                });

            modelBuilder.Entity("webApp.Models.StaffLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffLinks");
                });

            modelBuilder.Entity("webApp.Models.StudyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Level")
                        .IsUnique()
                        .HasFilter("[Level] IS NOT NULL");

                    b.ToTable("StudyPlans");
                });

            modelBuilder.Entity("webApp.Models.StudyPlanCourse", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StudyPlanId")
                        .HasColumnType("int");

                    b.Property<bool>("SemesterOne")
                        .HasColumnType("bit");

                    b.Property<bool>("SemesterTwo")
                        .HasColumnType("bit");

                    b.HasKey("CourseCode", "StudyPlanId");

                    b.HasIndex("StudyPlanId");

                    b.ToTable("StudyPlanCourses");
                });

            modelBuilder.Entity("webApp.Models.Education", b =>
                {
                    b.HasOne("webApp.Models.Staff", "Staff")
                        .WithMany("Educations")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("webApp.Models.EducationalProgram", b =>
                {
                    b.HasOne("webApp.Models.Requirement", "Requirement")
                        .WithMany("EducationalPrograms")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("webApp.Models.NewsImages", b =>
                {
                    b.HasOne("webApp.Models.News", "News")
                        .WithMany("NewsImages")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });

            modelBuilder.Entity("webApp.Models.ProgramCourse", b =>
                {
                    b.HasOne("webApp.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApp.Models.EducationalProgram", "EducationalProgram")
                        .WithMany("ProgramCourses")
                        .HasForeignKey("EducationalProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("EducationalProgram");
                });

            modelBuilder.Entity("webApp.Models.Requirement", b =>
                {
                    b.HasOne("webApp.Models.Regulation", "Regulation")
                        .WithMany("Requirements")
                        .HasForeignKey("RegulationCode");

                    b.Navigation("Regulation");
                });

            modelBuilder.Entity("webApp.Models.RequirementCourse", b =>
                {
                    b.HasOne("webApp.Models.Course", "Course")
                        .WithMany("RequirementCourses")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApp.Models.Requirement", "Requirement")
                        .WithMany("RequirementCourses")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("webApp.Models.ScientificAchievement", b =>
                {
                    b.HasOne("webApp.Models.Staff", "Staff")
                        .WithMany("ScientificAchievements")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("webApp.Models.StaffLink", b =>
                {
                    b.HasOne("webApp.Models.Staff", "Staff")
                        .WithMany("StaffLinks")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("webApp.Models.StudyPlanCourse", b =>
                {
                    b.HasOne("webApp.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApp.Models.StudyPlan", "StudyPlan")
                        .WithMany("StudyPlanCourses")
                        .HasForeignKey("StudyPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("StudyPlan");
                });

            modelBuilder.Entity("webApp.Models.Course", b =>
                {
                    b.Navigation("RequirementCourses");
                });

            modelBuilder.Entity("webApp.Models.EducationalProgram", b =>
                {
                    b.Navigation("ProgramCourses");
                });

            modelBuilder.Entity("webApp.Models.News", b =>
                {
                    b.Navigation("NewsImages");
                });

            modelBuilder.Entity("webApp.Models.Regulation", b =>
                {
                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("webApp.Models.Requirement", b =>
                {
                    b.Navigation("EducationalPrograms");

                    b.Navigation("RequirementCourses");
                });

            modelBuilder.Entity("webApp.Models.Staff", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("ScientificAchievements");

                    b.Navigation("StaffLinks");
                });

            modelBuilder.Entity("webApp.Models.StudyPlan", b =>
                {
                    b.Navigation("StudyPlanCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
