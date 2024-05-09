using TechCareer_BootCamp_MovieProject_Model.BaseEntities;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class Movie : BaseEntity
    {
        public string? Title { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Plot { get; set; } //overview,summary
        public string? PosterPath { get; set; }
        public string? OriginalLanguage { get; set; }
        public int ReleaseDate { get; set; }

        public int DirectorId { get; set; } //foreign key
        public Director? Director { get; set; } //navigation property
        public ICollection<Actor>? Actors { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}
