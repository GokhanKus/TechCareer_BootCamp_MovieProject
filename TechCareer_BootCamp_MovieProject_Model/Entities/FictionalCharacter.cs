using TechCareer_BootCamp_MovieProject_Model.BaseEntities;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class FictionalCharacter:BaseEntity
    {
        public string? CharacterName { get; set; }
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
