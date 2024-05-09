using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechCareer_BootCamp_MovieProject_UI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FictionalCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FictionalCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FictionalCharacters_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OriginalLanguage = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<int>(type: "int", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "CreatedTime", "DoB", "FullName", "ImagePath", "PlaceOfBirth" },
                values: new object[,]
                {
                    { 1, "Daniel Day Lewis's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8787), new DateTime(1957, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Day Lewis", "DanielDayLewis.jpg", "Londra, UK" },
                    { 2, "Paul Dano's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8794), new DateTime(1975, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Dano", "PaulDano.jpg", "New York, USA" },
                    { 3, "Dillon Freasier's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8797), new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dillon Freasier", "DillonFreasier.jpg", "Texas, USA" },
                    { 4, "Erica Sullivan's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8800), new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erica Sullivan", "EricaSullivan.jpg", "California, USA" },
                    { 5, "Russell Harvard's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8802), new DateTime(1977, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russell Harvard", "RussellHarvard.jpg", "Pasadena, Texas, USA" },
                    { 6, "Ciarán Hinds's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8804), new DateTime(1953, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciarán Hinds", "CiaranHinds.jpg", "Belfast, Northern Ireland" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Biography", "CreatedTime", "DoB", "FullName", "ImagePath", "PlaceOfBirth" },
                values: new object[] { 1, "Paul Thomas Anderson's Biography", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(1481), new DateTime(1970, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Thomas Anderson", "PaulThomasAnderson.jpg", "LA, California, USA" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedTime", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(3917), "Drama" },
                    { 2, new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(3919), "Western" }
                });

            migrationBuilder.InsertData(
                table: "FictionalCharacters",
                columns: new[] { "Id", "ActorId", "CharacterName", "CreatedTime" },
                values: new object[,]
                {
                    { 1, 1, "Daniel Plainview", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2735) },
                    { 2, 2, "Paul Sunday, Eli Sunday", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2737) },
                    { 3, 6, "Fletcher", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2738) },
                    { 4, 3, "Baby Plainview", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2739) },
                    { 5, 4, "Signal Hill Woman", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2740) },
                    { 6, 5, "Adult Plainview", new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2741) }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedTime", "DirectorId", "OriginalLanguage", "OriginalTitle", "Plot", "PosterPath", "ReleaseDate", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(6216), 1, 2, "There Will Be Blood", "A story of family, religion, hatred, oil and madness, focusing on a turn-of-the-century prospector in the early days of the business.", "ThereWillBeBlood.jpg", 2007, "Kan Dokulecek" });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_FictionalCharacters_ActorId",
                table: "FictionalCharacters",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MovieId",
                table: "GenreMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "FictionalCharacters");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
