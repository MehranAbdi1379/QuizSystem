using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class sefj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07b5d456-81a5-41b8-9fd3-3a57c58c7635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7f7e407-3aa1-4790-8297-d622af0a9c1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea8e860a-6f3c-4003-aa18-618050f0ba01");

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06f26b14-1ecf-47fc-99ff-dad62252d4df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35eb57e7-cb71-4310-9956-1a01c5fb46af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f68c57-1f7e-468d-bbf1-edf388ef327f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07b5d456-81a5-41b8-9fd3-3a57c58c7635", "eb1262d9-1e54-4fc1-9c39-b0142c66945a", "Professor", "PROFESSOR" },
                    { "c7f7e407-3aa1-4790-8297-d622af0a9c1b", "c7bba8b9-0ff1-49ca-9b97-f1786ec5e864", "Student", "STUDENT" },
                    { "ea8e860a-6f3c-4003-aa18-618050f0ba01", "4d4cb7e1-3d8b-4ac4-884b-cd0299ec2170", "Admin", "ADMIN" }
                });
        }
    }
}
