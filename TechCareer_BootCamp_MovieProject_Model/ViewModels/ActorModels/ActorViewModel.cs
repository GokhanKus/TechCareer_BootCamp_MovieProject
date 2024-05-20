
namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels
{
    public record ActorViewModel
    {
        public int Id { get; init; }
        public string? FullName { get; init; }
        public string? ImagePath{ get; set; }
    }
}
