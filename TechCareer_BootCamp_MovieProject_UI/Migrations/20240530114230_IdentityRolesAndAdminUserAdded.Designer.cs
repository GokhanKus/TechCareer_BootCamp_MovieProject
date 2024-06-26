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
    [Migration("20240530114230_IdentityRolesAndAdminUserAdded")]
    partial class IdentityRolesAndAdminUserAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "168a9e8d-7b0d-4da7-a9c2-4a8d050e75b0",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "941e4bac-5721-4fdc-bdf1-336814d805dc",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        },
                        new
                        {
                            Id = "8b1a3a38-bc19-4640-8547-665b82e687bf",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7258),
                            DoB = new DateTime(1957, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Daniel Day Lewis",
                            ImagePath = "DanielDayLewis.jpg",
                            PlaceOfBirth = "Londra, UK"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Paul Dano's Biography",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7263),
                            DoB = new DateTime(1975, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Paul Dano",
                            ImagePath = "PaulDano.jpg",
                            PlaceOfBirth = "New York, USA"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "Dillon Freasier's Biography",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7265),
                            DoB = new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Dillon Freasier",
                            ImagePath = "DillonFreasier.jpg",
                            PlaceOfBirth = "Texas, USA"
                        },
                        new
                        {
                            Id = 4,
                            Biography = "Erica Sullivan's Biography",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7268),
                            DoB = new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Erica Sullivan",
                            ImagePath = "EricaSullivan.jpg",
                            PlaceOfBirth = "California, USA"
                        },
                        new
                        {
                            Id = 5,
                            Biography = "Russell Harvard's Biography",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7269),
                            DoB = new DateTime(1977, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Russell Harvard",
                            ImagePath = "RussellHarvard.jpg",
                            PlaceOfBirth = "Pasadena, Texas, USA"
                        },
                        new
                        {
                            Id = 6,
                            Biography = "Ciarán Hinds's Biography",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(7271),
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
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 452, DateTimeKind.Utc).AddTicks(9961),
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
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1185)
                        },
                        new
                        {
                            Id = 2,
                            ActorId = 2,
                            CharacterName = "Paul Sunday, Eli Sunday",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1188)
                        },
                        new
                        {
                            Id = 3,
                            ActorId = 6,
                            CharacterName = "Fletcher",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1189)
                        },
                        new
                        {
                            Id = 4,
                            ActorId = 3,
                            CharacterName = "Baby Plainview",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1190)
                        },
                        new
                        {
                            Id = 5,
                            ActorId = 4,
                            CharacterName = "Signal Hill Woman",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1192)
                        },
                        new
                        {
                            Id = 6,
                            ActorId = 5,
                            CharacterName = "Adult Plainview",
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(1193)
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
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(2442),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(2444),
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

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

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

                    b.Property<double>("Score")
                        .HasColumnType("float");

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
                            CreatedTime = new DateTime(2024, 5, 30, 11, 42, 27, 453, DateTimeKind.Utc).AddTicks(5963),
                            DirectorId = 1,
                            Duration = new TimeSpan(0, 2, 38, 0, 0),
                            OriginalLanguage = 2,
                            OriginalTitle = "There Will Be Blood",
                            Plot = "A story of family, religion, hatred, oil and madness, focusing on a turn-of-the-century prospector in the early days of the business.",
                            PosterPath = "ThereWillBeBlood.jpg",
                            ReleaseDate = 2007,
                            Score = 8.4000000000000004,
                            Title = "Kan Dokulecek"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
