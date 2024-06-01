
namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels
{
	public record ActorViewModelForUpdate : ActorViewModel
	{
		public DateTime DoB { get; init; } //Date of Birth
		public string? PlaceOfBirth { get; init; }
		public string? Biography { get; init; }
	}
}
