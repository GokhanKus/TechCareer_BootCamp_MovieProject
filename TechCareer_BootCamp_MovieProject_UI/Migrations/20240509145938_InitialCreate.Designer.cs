﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

#nullable disable

namespace TechCareer_BootCamp_MovieProject_UI.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20240509145938_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Daniel Day Lewis's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8787),
                            DoB = new DateTime(1957, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Daniel Day Lewis",
                            ImagePath = "DanielDayLewis.jpg",
                            PlaceOfBirth = "Londra, UK"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Paul Dano's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8794),
                            DoB = new DateTime(1975, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Paul Dano",
                            ImagePath = "PaulDano.jpg",
                            PlaceOfBirth = "New York, USA"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "Dillon Freasier's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8797),
                            DoB = new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Dillon Freasier",
                            ImagePath = "DillonFreasier.jpg",
                            PlaceOfBirth = "Texas, USA"
                        },
                        new
                        {
                            Id = 4,
                            Biography = "Erica Sullivan's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8800),
                            DoB = new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Erica Sullivan",
                            ImagePath = "EricaSullivan.jpg",
                            PlaceOfBirth = "California, USA"
                        },
                        new
                        {
                            Id = 5,
                            Biography = "Russell Harvard's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8802),
                            DoB = new DateTime(1977, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Russell Harvard",
                            ImagePath = "RussellHarvard.jpg",
                            PlaceOfBirth = "Pasadena, Texas, USA"
                        },
                        new
                        {
                            Id = 6,
                            Biography = "Ciarán Hinds's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 909, DateTimeKind.Utc).AddTicks(8804),
                            DoB = new DateTime(1953, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Ciarán Hinds",
                            ImagePath = "CiaranHinds.jpg",
                            PlaceOfBirth = "Belfast, Northern Ireland"
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.ActorMovie", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovie");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            ActorId = 2,
                            MovieId = 1
                        },
                        new
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                        new
                        {
                            ActorId = 4,
                            MovieId = 1
                        },
                        new
                        {
                            ActorId = 5,
                            MovieId = 1
                        },
                        new
                        {
                            ActorId = 6,
                            MovieId = 1
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Paul Thomas Anderson's Biography",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(1481),
                            DoB = new DateTime(1970, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Paul Thomas Anderson",
                            ImagePath = "PaulThomasAnderson.jpg",
                            PlaceOfBirth = "LA, California, USA"
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.FictionalCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("FictionalCharacters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActorId = 1,
                            CharacterName = "Daniel Plainview",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2735)
                        },
                        new
                        {
                            Id = 2,
                            ActorId = 2,
                            CharacterName = "Paul Sunday, Eli Sunday",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2737)
                        },
                        new
                        {
                            Id = 3,
                            ActorId = 6,
                            CharacterName = "Fletcher",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2738)
                        },
                        new
                        {
                            Id = 4,
                            ActorId = 3,
                            CharacterName = "Baby Plainview",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2739)
                        },
                        new
                        {
                            Id = 5,
                            ActorId = 4,
                            CharacterName = "Signal Hill Woman",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2740)
                        },
                        new
                        {
                            Id = 6,
                            ActorId = 5,
                            CharacterName = "Adult Plainview",
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(2741)
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(3917),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(3919),
                            Name = "Western"
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.GenreMovie", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("GenreMovie");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            GenreId = 2,
                            MovieId = 1
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("OriginalLanguage")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterPath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("ReleaseDate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2024, 5, 9, 14, 59, 37, 910, DateTimeKind.Utc).AddTicks(6216),
                            DirectorId = 1,
                            OriginalLanguage = 2,
                            OriginalTitle = "There Will Be Blood",
                            Plot = "A story of family, religion, hatred, oil and madness, focusing on a turn-of-the-century prospector in the early days of the business.",
                            PosterPath = "ThereWillBeBlood.jpg",
                            ReleaseDate = 2007,
                            Title = "Kan Dokulecek"
                        });
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.ActorMovie", b =>
                {
                    b.HasOne("TechCareer_BootCamp_MovieProject_Model.Entities.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechCareer_BootCamp_MovieProject_Model.Entities.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.FictionalCharacter", b =>
                {
                    b.HasOne("TechCareer_BootCamp_MovieProject_Model.Entities.Actor", "Actor")
                        .WithMany("FictionalCharacters")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.GenreMovie", b =>
                {
                    b.HasOne("TechCareer_BootCamp_MovieProject_Model.Entities.Genre", "Genre")
                        .WithMany("GenreMovies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechCareer_BootCamp_MovieProject_Model.Entities.Movie", "Movie")
                        .WithMany("GenreMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Movie", b =>
                {
                    b.HasOne("TechCareer_BootCamp_MovieProject_Model.Entities.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Actor", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("FictionalCharacters");
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Genre", b =>
                {
                    b.Navigation("GenreMovies");
                });

            modelBuilder.Entity("TechCareer_BootCamp_MovieProject_Model.Entities.Movie", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("GenreMovies");
                });
#pragma warning restore 612, 618
        }
    }
}