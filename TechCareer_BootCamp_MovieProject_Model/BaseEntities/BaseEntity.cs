namespace TechCareer_BootCamp_MovieProject_Model.BaseEntities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
