using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06f26b14-1ecf-47fc-99ff-dad62252d4df", "c7f7e407-3aa1-4790-8297-d622af0a9c1b", "Student", "STUDENT" },
                    { "35eb57e7-cb71-4310-9956-1a01c5fb46af", "ea8e860a-6f3c-4003-aa18-618050f0ba01", "Admin", "ADMIN" },
                    { "95f68c57-1f7e-468d-bbf1-edf388ef327f", "07b5d456-81a5-41b8-9fd3-3a57c58c7635", "Professor", "PROFESSOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
