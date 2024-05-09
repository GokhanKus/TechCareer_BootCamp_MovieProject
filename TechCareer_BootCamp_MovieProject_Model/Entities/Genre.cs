using TechCareer_BootCamp_MovieProject_Model.BaseEntities;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class Genre : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Movie>? Movies { get; set; } //= new List<Movie>();
    }
}
