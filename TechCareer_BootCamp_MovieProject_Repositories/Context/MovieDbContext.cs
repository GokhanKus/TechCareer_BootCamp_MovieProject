using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.Config;

namespace TechCareer_BootCamp_MovieProject_Repositories.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //efcore tarafından many to many iliskilerde ara tablolar otomatik olusturulur, fakat bir verileri birbiri ile iliskilendirecegimiz zaman manuel olarak olusturmaya ihtiyac duyabiliriz
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieId);


            modelBuilder.Entity<GenreMovie>()
                .HasKey(gm => new {gm.GenreId, gm.MovieId});

            modelBuilder.Entity<GenreMovie>()
                .HasOne(gm => gm.Genre)
                .WithMany(g => g.GenreMovies)
                .HasForeignKey(gm => gm.GenreId);

            modelBuilder.Entity<GenreMovie>()
                .HasOne(gm => gm.Movie)
                .WithMany(m => m.GenreMovies)
                .HasForeignKey(gm => gm.MovieId);

            //modelBuilder.ApplyConfiguration(new ActorConfig()); tek tek configleri boyle calistirmak yerine;
            //IEntityTypeConfiguration<Actor> gibi IEntityTypeConfiguration'in butun instancelerini run timeda configlerini olusturalim
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<FictionalCharacter> FictionalCharacters { get; set; }
    }
}
