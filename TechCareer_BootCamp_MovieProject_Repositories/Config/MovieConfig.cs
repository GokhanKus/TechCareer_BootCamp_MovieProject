using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.Enums;

namespace TechCareer_BootCamp_MovieProject_Repositories.Config
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //builder.ToTable("Movies"); //tablo adi belirtir yazmasak default olarak sinif adi kullanilir Movie..
            //builder.HasKey(m => m.Id); //buna da gerek yok eger Id yada MovieId ise otomatik primary key olur

            // Fluent Api'ler
            builder.Property(m => m.OriginalTitle)
                .IsRequired() // Zorunlu alan
                .HasMaxLength(200);

            builder.Property(m => m.Title)
                .HasMaxLength(200); // Maksimum uzunluk

            builder.Property(m => m.PosterPath)
                .HasMaxLength(300);

            builder.Property(m => m.OriginalLanguage)
                .HasMaxLength(50);

            builder.HasData(
                new Movie
                {
                    Id = 1,
                    CreatedTime = DateTime.UtcNow,
                    OriginalTitle = "There Will Be Blood",
                    Title = "Kan Dokulecek",
                    Plot = "A story of family, religion, hatred, oil and madness, focusing on a turn-of-the-century prospector in the early days of the business.",
                    PosterPath = "ThereWillBeBlood.jpg",
                    OriginalLanguage = Language.English,
                    ReleaseDate = 2007,
                    Score = 8.4,
                    Duration = new TimeSpan(hours:2,minutes:38,seconds:0),
                    DirectorId=1
                });
        }
    }
}
