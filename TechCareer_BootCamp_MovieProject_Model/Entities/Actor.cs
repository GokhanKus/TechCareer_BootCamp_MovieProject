using TechCareer_BootCamp_MovieProject_Model.BaseEntities;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class Actor : Person //Person + BaseEntity
    {
        public ICollection<FictionalCharacter>? FictionalCharacters { get; set; }//filmi canlandiran aktorun karakter adı
        public ICollection<ActorMovie>? ActorMovies { get; set; }
        //public ICollection<Movie>? Movies { get; set; }//= new List<Movie>();
    }
}
