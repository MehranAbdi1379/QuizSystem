using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactorToNewIdentityBaseUserSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Professors");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Professors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Professors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Professors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Professors",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Professors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
    }
}
