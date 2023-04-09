using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab14f91f-519e-45d6-a754-81f22ca3eb78", "990cac3b-470f-49af-a420-29771bfae3c8", "Professor", "PROFESSOR" },
                    { "ca0621d4-f904-408b-b941-4b3f711ea330", "fe37f3da-572e-4e41-8041-24d236f27111", "Admin", "ADMIN" },
                    { "eb8c9c94-cd50-476f-b019-21608c210649", "8aafdd59-776d-411b-a2cc-defdeb284600", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab14f91f-519e-45d6-a754-81f22ca3eb78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca0621d4-f904-408b-b941-4b3f711ea330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8c9c94-cd50-476f-b019-21608c210649");
        }
    }
}
