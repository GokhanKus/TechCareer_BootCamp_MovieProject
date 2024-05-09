using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Repositories.Config
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(
                new Actor
                {
                    Id = 1,
                    CreatedTime = DateTime.UtcNow,
                    DoB = new DateTime(1957, 04, 29),
                    ImagePath = "DanielDayLewis.jpg",
                    PlaceOfBirth = "Londra, UK",
                    FullName = "Daniel Day Lewis",
                    Biography = "Daniel Day Lewis's Biography",
                },
                new Actor
                {
                    Id = 2,
                    CreatedTime = DateTime.UtcNow,
                    DoB = new DateTime(1975, 03, 27),
                    ImagePath = "PaulDano.jpg",
                    PlaceOfBirth = "New York, USA",
                    FullName = "Paul Dano",
                    Biography = "Paul Dano's Biography"
                },
                new Actor
                {
                    Id = 3,
                    CreatedTime = DateTime.UtcNow,
                    DoB = new DateTime(1996, 08, 13),
                    ImagePath = "DillonFreasier.jpg",
                    PlaceOfBirth = "Texas, USA",
                    FullName = "Dillon Freasier",
                    Biography = "Dillon Freasier's Biography"
                },
                new Actor
                {
                    Id = 4,
                    CreatedTime = DateTime.UtcNow,
                    DoB = new DateTime(1989, 01, 01),
                    ImagePath = "EricaSullivan.jpg",
                    PlaceOfBirth = "California, USA",
                    FullName = "Erica Sullivan",
                    Biography = "Erica Sullivan's Biography"
                },
                new Actor
                {
                    Id = 5,
                    CreatedTime = DateTime.UtcNow,
                    DoB = new DateTime(1977, 04, 16),
                    ImagePath = "RussellHarvard.jpg",
                    PlaceOfBirth = "Pasadena, Texas, USA",
                    FullName = "Russell Harvard",
                    Biography = "Russell Harvard's Biography"
                },
                new Actor
                {
                    Id = 6,
                    CreatedTime = DateTime.UtcNow,
                    DoB = new DateTime(1953, 02, 09),
                    ImagePath = "CiaranHinds.jpg",
                    PlaceOfBirth = "Belfast, Northern Ireland",
                    FullName = "Ciarán Hinds",
                    Biography = "Ciarán Hinds's Biography"
                });
        }
    }
}
