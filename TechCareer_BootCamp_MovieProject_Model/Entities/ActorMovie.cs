namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class ActorMovie
    {
        //manuel olusturdugumuz ara tablo
        public int ActorId { get; set; }
        public Actor? Actor{ get; set; }
        public int MovieId { get; set; }
        public Movie? Movie{ get; set; }
    }
}
