using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Repositories.Config
{
    public class DirectorConfig : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(
                new Director
                {
                    Id = 1,
                    CreatedTime = DateTime.UtcNow,
                    FullName = "Paul Thomas Anderson",
                    DoB = new DateTime(1970, 06, 26),
                    PlaceOfBirth = "LA, California, USA",
                    ImagePath = "PaulThomasAnderson.jpg",
                    Biography = "Paul Thomas Anderson's Biography"
                });
        }
    }
}
