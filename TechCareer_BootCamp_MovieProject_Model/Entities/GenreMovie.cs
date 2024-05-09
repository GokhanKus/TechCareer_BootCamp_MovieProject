namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class GenreMovie
    {
        //manuel olusturdugumuz ara tablo
        public int GenreId { get; set; }
        public Genre? Genre{ get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
