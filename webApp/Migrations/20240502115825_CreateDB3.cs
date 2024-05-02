using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "Regulations",
                newName: "Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Regulations",
                newName: "Hours");
        }
    }
}
