using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddingTimePeriodTOCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Courses",
                newName: "TimePeriod_StartDate");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Courses",
                newName: "TimePeriod_EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimePeriod_StartDate",
                table: "Courses",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "TimePeriod_EndDate",
                table: "Courses",
                newName: "EndTime");
        }
    }
}
