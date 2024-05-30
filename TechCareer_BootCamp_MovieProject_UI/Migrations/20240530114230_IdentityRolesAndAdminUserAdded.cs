using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechCareer_BootCamp_MovieProject_UI.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRolesAndAdminUserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "168a9e8d-7b0d-4da7-a9c2-4a8d050e75b0", null, "User", "USER" },
                    { "8b1a3a38-bc19-4640-8547-665b82e687bf", null, "Admin", "ADMIN" },
                    { "941e4bac-5721-4fdc-bdf1-336814d805dc", null, "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1185));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(5963));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168a9e8d-7b0d-4da7-a9c2-4a8d050e75b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b1a3a38-bc19-4640-8547-665b82e687bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "941e4bac-5721-4fdc-bdf1-336814d805dc");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 891, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 30, 10, 31, 47, 892, DateTimeKind.Utc).AddTicks(209));
        }
    }
}
