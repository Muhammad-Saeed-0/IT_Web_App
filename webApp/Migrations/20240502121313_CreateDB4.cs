using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Requirements",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Educations",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "EducationalProgram",
                newName: "Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Requirements",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Educations",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "EducationalProgram",
                newName: "Description");
        }
    }
}
