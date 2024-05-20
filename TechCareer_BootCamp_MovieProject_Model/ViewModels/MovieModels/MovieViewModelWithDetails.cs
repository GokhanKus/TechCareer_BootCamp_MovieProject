using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.Enums;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels
{
	public record MovieViewModelWithDetails : MovieCardModel
	{
		//public IEnumerable<Movie> Movies{ get; set; } = Enumerable.Empty<Movie>();
		public Language OriginalLanguage { get; init; }
		public TimeSpan Duration { get; set; }
		public Director? Director { get; init; } //navigation property
		public int? DirectorId { get; init; } //navigation property
		public string? Title { get; init; } //navigation property
		public IEnumerable<Actor> Actors { get; set; } = Enumerable.Empty<Actor>(); // list string actor name
		public List<int> SelectedActorIds { get; set; } = new List<int>();
		public IEnumerable<FictionalCharacter> FictionalCharacters { get; set; } = Enumerable.Empty<FictionalCharacter>();
		//public int[] ActorIds { get; init; } = Array.Empty<int>();
	}
}
