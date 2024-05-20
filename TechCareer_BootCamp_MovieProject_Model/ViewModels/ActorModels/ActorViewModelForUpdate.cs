
namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels
{
	public record ActorViewModelForUpdate : ActorViewModel
	{
		public DateTime DoB { get; set; } //Date of Birth
		public string? PlaceOfBirth { get; set; }
		public string? Biography { get; set; }
	}
}
