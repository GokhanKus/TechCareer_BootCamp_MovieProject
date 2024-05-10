using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.Enums;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels
{
	public record MovieViewModel
	{
		public int Id { get; init; }
		public string? OriginalTitle { get; init; }
		public string? PosterPath { get; set; }
		public int? ReleaseDate { get; init; }
		public double Score { get; init; }
		public string? Plot { get; init; }
		public IEnumerable<Genre> Genres { get; init; } = Enumerable.Empty<Genre>();
		//public IEnumerable<Movie> Movies{ get; set; } = Enumerable.Empty<Movie>();
	}
}
