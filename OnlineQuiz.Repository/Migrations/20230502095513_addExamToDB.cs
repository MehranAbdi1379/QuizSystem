using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addExamToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06f26b14-1ecf-47fc-99ff-dad62252d4df", "aa17855b-9d3a-4ce2-a32e-96b4fe1ab898", "Student", "STUDENT" },
                    { "35eb57e7-cb71-4310-9956-1a01c5fb46af", "398cfc42-632a-4e42-895d-4a9a7d27a608", "Admin", "ADMIN" },
                    { "95f68c57-1f7e-468d-bbf1-edf388ef327f", "fd17e83a-b4ad-4870-94a5-c70cc2fa48d4", "Professor", "PROFESSOR" }
                });
        }
    }
}
