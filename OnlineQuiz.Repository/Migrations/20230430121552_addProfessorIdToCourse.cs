using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addProfessorIdToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fb1cfe7-6960-4683-afe2-074f564b5018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e304326-1338-4b59-b135-459e7f330105");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832317e5-ccab-4467-b507-45c998f9f8d4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fb1cfe7-6960-4683-afe2-074f564b5018", "8e52b787-263c-4223-b63a-812aedcc70d2", "Professor", "PROFESSOR" },
                    { "2e304326-1338-4b59-b135-459e7f330105", "2e30f543-7c7d-4abd-af2b-76833896b5f8", "Admin", "ADMIN" },
                    { "832317e5-ccab-4467-b507-45c998f9f8d4", "f060680a-d175-43a7-93b6-a0320b052439", "Student", "STUDENT" }
                });
        }
    }
}
