using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class c8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudyPlanProgramLevels_Title",
                table: "StudyPlanProgramLevels");

            migrationBuilder.DropIndex(
                name: "IX_StudyPlanEntryLevels_Title",
                table: "StudyPlanEntryLevels");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "StudyPlanProgramLevels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "StudyPlanEntryLevels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "StudyPlanProgramLevels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "StudyPlanEntryLevels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanProgramLevels_Title",
                table: "StudyPlanProgramLevels",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanEntryLevels_Title",
                table: "StudyPlanEntryLevels",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");
        }
    }
}
