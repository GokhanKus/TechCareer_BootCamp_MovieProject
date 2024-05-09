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
    public class FictionalCharacterConfig : IEntityTypeConfiguration<FictionalCharacter>
    {
        public void Configure(EntityTypeBuilder<FictionalCharacter> builder)
        {
            builder.Property(f => f.CharacterName)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(
                new FictionalCharacter { Id = 1, CreatedTime = DateTime.UtcNow, ActorId = 1, CharacterName = "Daniel Plainview" },
                new FictionalCharacter { Id = 2, CreatedTime = DateTime.UtcNow, ActorId = 2, CharacterName = "Paul Sunday, Eli Sunday" },
                new FictionalCharacter { Id = 3, CreatedTime = DateTime.UtcNow, ActorId = 6, CharacterName = "Fletcher" },
                new FictionalCharacter { Id = 4, CreatedTime = DateTime.UtcNow, ActorId = 3, CharacterName = "Baby Plainview" },
                new FictionalCharacter { Id = 5, CreatedTime = DateTime.UtcNow, ActorId = 4, CharacterName = "Signal Hill Woman" },
                new FictionalCharacter { Id = 6, CreatedTime = DateTime.UtcNow, ActorId = 5, CharacterName = "Adult Plainview" }
                );
        }
    }
}
