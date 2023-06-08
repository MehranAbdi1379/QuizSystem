using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class deleteGradeFromExamStudentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ExamStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "ExamStudent",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
