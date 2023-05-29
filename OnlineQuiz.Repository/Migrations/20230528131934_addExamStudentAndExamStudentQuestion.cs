using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addExamStudentAndExamStudentQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    TimeLeft = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamStudentQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamStudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradedQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStudentQuestion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamStudent");

            migrationBuilder.DropTable(
                name: "ExamStudentQuestion");
        }
    }
}
