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
		public List<Genre> Genres { get; set; } = new(); //list string genre name
		//public IEnumerable<ActorByIdAndName>? ActorsByIdAndNames{ get; set; } = Enumerable.Empty<ActorByIdAndName>();
	}
}
