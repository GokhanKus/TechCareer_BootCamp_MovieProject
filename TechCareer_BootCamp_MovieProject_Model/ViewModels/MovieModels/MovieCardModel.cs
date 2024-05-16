using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels
{
    public record MovieCardModel
	{
		public int Id { get; init; }
		public string? OriginalTitle { get; init; }
		public string? PosterPath { get; set; }
		public int? ReleaseDate { get; init; }
		public double Score { get; init; }
		public string? Plot { get; init; }
		public IEnumerable<Genre> Genres { get; set; } = Enumerable.Empty<Genre>();
		//public IEnumerable<ActorByIdAndName>? ActorsByIdAndNames{ get; set; } = Enumerable.Empty<ActorByIdAndName>();
	}
}
