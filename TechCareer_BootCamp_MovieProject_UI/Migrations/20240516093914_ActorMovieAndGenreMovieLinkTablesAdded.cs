using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareer_BootCamp_MovieProject_UI.Migrations
{
    /// <inheritdoc />
    public partial class ActorMovieAndGenreMovieLinkTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 906, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 906, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 906, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 906, DateTimeKind.Utc).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 906, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 906, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 16, 9, 39, 11, 907, DateTimeKind.Utc).AddTicks(5352));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "FictionalCharacters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 353, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 354, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 354, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 10, 18, 24, 34, 354, DateTimeKind.Utc).AddTicks(2547));
        }
    }
}
