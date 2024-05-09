using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Repositories.Config
{
    public class ActorMovieConfig : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasData(
                new ActorMovie { ActorId = 1, MovieId = 1 },
                new ActorMovie { ActorId = 2, MovieId = 1 },
                new ActorMovie { ActorId = 3, MovieId = 1 },
                new ActorMovie { ActorId = 4, MovieId = 1 },
                new ActorMovie { ActorId = 5, MovieId = 1 },
                new ActorMovie { ActorId = 6, MovieId = 1 }
                );
        }
    }
}
