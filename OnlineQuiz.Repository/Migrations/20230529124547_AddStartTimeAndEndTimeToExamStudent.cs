using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddStartTimeAndEndTimeToExamStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeLeft",
                table: "ExamStudent");

            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "ExamStudentQuestion",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ExamStudent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ExamStudent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ExamStudentQuestion");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ExamStudent");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ExamStudent");

            migrationBuilder.AddColumn<double>(
                name: "TimeLeft",
                table: "ExamStudent",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
