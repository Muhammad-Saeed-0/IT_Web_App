using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Code", "CourseTitle", "CourseWork", "ExamTime", "FinalExam", "Lecture", "OralPractical", "PracticalTutorial", "Prerequisite", "TermExams", "Total" },
                values: new object[,]
                {
                    { "CS 313", "Machine Learning", 15, 3, 60, 2, 0, 2, "CS 103 Object Programming", 25, 3 },
                    { "IS 323", "Web Applications", 15, 3, 60, 2, 0, 2, "IT 204 Web Programming", 25, 3 },
                    { "IT 203", "Computer Networks", 15, 3, 60, 2, 0, 2, "IT 203 Data Comunications", 25, 3 },
                    { "IT 204", "Web Programming", 15, 3, 60, 2, 0, 2, "No Prerequisite", 25, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Code",
                keyValue: "CS 313");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Code",
                keyValue: "IS 323");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Code",
                keyValue: "IT 203");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Code",
                keyValue: "IT 204");
        }
    }
}
