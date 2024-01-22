using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class add1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "StudyPlans");

            migrationBuilder.AddColumn<bool>(
                name: "SemesterOne",
                table: "StudyPlanCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SemesterTwo",
                table: "StudyPlanCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SemesterOne",
                table: "StudyPlanCourses");

            migrationBuilder.DropColumn(
                name: "SemesterTwo",
                table: "StudyPlanCourses");

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "StudyPlans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
