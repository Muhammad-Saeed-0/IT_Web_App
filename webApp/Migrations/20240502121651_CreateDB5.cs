using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "CourseTitle", "CourseWork", "ExamTime", "FinalExam", "Lecture", "OralPractical", "PracticalTutorial", "Prerequisite", "TermExams", "Total" },
                values: new object[] { "BS 209", "Operations Research", 15, 3, 60, 2, 0, 2, "BS 104 Prob. and Static.", 25, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Code",
                keyValue: "BS 209");
        }
    }
}
