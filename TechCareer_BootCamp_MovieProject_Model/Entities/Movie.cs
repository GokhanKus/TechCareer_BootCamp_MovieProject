using TechCareer_BootCamp_MovieProject_Model.BaseEntities;
using TechCareer_BootCamp_MovieProject_Model.Enums;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class Movie : BaseEntity
    {
        public string? Title { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Plot { get; set; } //overview,summary
        public string? PosterPath { get; set; }
        public Language OriginalLanguage { get; set; }
        public int? ReleaseDate { get; set; }
        public double Score { get; set; }
        public TimeSpan Duration { get; set; }
        public int DirectorId { get; set; } //foreign key
        public Director? Director { get; set; } //navigation property

        //ef core tarafindan otomatik olusturulan ara tablolari manuel olarak biz olusturalim cunku, aktorleri filmlerle, film turlerini de filmlerle ilişkilendirmemiz lazım(id'lerini vererek)
        public ICollection<ActorMovie>? ActorMovies { get; set; }
        public ICollection<GenreMovie>? GenreMovies { get; set; }
        //public ICollection<Actor>? Actors { get; set; } 
        //public ICollection<Genre>? Genres { get; set; }
    }
}
