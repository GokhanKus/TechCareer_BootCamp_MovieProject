using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Repositories.Config
{
    public class GenreMovieConfig : IEntityTypeConfiguration<GenreMovie>
    {
        public void Configure(EntityTypeBuilder<GenreMovie> builder)
        {
            builder.HasData(
                new GenreMovie { GenreId = 1, MovieId = 1 },
                new GenreMovie { GenreId = 2, MovieId = 1 }
                );
        }
    }
}
