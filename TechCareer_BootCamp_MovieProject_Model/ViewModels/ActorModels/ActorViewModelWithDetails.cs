using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels
{
	public class ActorViewModelWithDetails
	{
		public int Id { get; set; }
		public string? FullName { get; set; }
		public string? ImagePath { get; set; }
		public IEnumerable<Movie> Movies { get; set; } = Enumerable.Empty<Movie>();
		public DateTime DoB { get; set; } //Date of Birth
		public string? PlaceOfBirth { get; set; }
		public string? Biography { get; set; }
	}
}
