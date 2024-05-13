using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.Enums;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.SelectDropDownMenuModels;

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
		public IEnumerable<Genre> Genres { get; set; } = Enumerable.Empty<Genre>();
        //public IEnumerable<ActorByIdAndName>? ActorsByIdAndNames{ get; set; } = Enumerable.Empty<ActorByIdAndName>();
		public int[] ActorIds{ get; set; } = Array.Empty<int>();
        //public IEnumerable<Movie> Movies{ get; set; } = Enumerable.Empty<Movie>();
    }
}
