using TechCareer_BootCamp_MovieProject_Model.BaseEntities;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
    public class Person : BaseEntity
    {
        public string? FullName { get; set; }
        public DateTime DoB { get; set; } //Date of Birth
        public string? PlaceOfBirth { get; set; }
        public string? Biography { get; set; }
        public string? ImagePath { get; set; }
    }
}
