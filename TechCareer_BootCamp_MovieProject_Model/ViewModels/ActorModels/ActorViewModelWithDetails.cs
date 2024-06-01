using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels
{
	public record ActorViewModelWithDetails : ActorViewModelForUpdate
	{
		public IEnumerable<Movie> Movies { get; set; } = Enumerable.Empty<Movie>();
	}
}
