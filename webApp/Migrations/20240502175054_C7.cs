using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations
{
    /// <inheritdoc />
    public partial class C7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyPlanCourses");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.CreateTable(
                name: "StudyPlanEntryLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanEntryLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanProgramLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EducationalProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanProgramLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlanProgramLevels_EducationalProgram_EducationalProgramId",
                        column: x => x.EducationalProgramId,
                        principalTable: "EducationalProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryLevelCourses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudyPlanEntryLevelId = table.Column<int>(type: "int", nullable: false),
                    SemesterOne = table.Column<bool>(type: "bit", nullable: false),
                    SemesterTwo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryLevelCourses", x => new { x.CourseCode, x.StudyPlanEntryLevelId });
                    table.ForeignKey(
                        name: "FK_EntryLevelCourses_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryLevelCourses_StudyPlanEntryLevels_StudyPlanEntryLevelId",
                        column: x => x.StudyPlanEntryLevelId,
                        principalTable: "StudyPlanEntryLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramLevelCourses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudyPlanProgramLevelId = table.Column<int>(type: "int", nullable: false),
                    SemesterOne = table.Column<bool>(type: "bit", nullable: false),
                    SemesterTwo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLevelCourses", x => new { x.CourseCode, x.StudyPlanProgramLevelId });
                    table.ForeignKey(
                        name: "FK_ProgramLevelCourses_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramLevelCourses_StudyPlanProgramLevels_StudyPlanProgramLevelId",
                        column: x => x.StudyPlanProgramLevelId,
                        principalTable: "StudyPlanProgramLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryLevelCourses_StudyPlanEntryLevelId",
                table: "EntryLevelCourses",
                column: "StudyPlanEntryLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLevelCourses_StudyPlanProgramLevelId",
                table: "ProgramLevelCourses",
                column: "StudyPlanProgramLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanEntryLevels_Title",
                table: "StudyPlanEntryLevels",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanProgramLevels_EducationalProgramId",
                table: "StudyPlanProgramLevels",
                column: "EducationalProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanProgramLevels_Title",
                table: "StudyPlanProgramLevels",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryLevelCourses");

            migrationBuilder.DropTable(
                name: "ProgramLevelCourses");

            migrationBuilder.DropTable(
                name: "StudyPlanEntryLevels");

            migrationBuilder.DropTable(
                name: "StudyPlanProgramLevels");

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanCourses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false),
                    SemesterOne = table.Column<bool>(type: "bit", nullable: false),
                    SemesterTwo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanCourses", x => new { x.CourseCode, x.StudyPlanId });
                    table.ForeignKey(
                        name: "FK_StudyPlanCourses_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyPlanCourses_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanCourses_StudyPlanId",
                table: "StudyPlanCourses",
                column: "StudyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_Level",
                table: "StudyPlans",
                column: "Level",
                unique: true,
                filter: "[Level] IS NOT NULL");
        }
    }
}
