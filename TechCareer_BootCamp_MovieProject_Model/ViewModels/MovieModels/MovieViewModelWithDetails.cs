﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.Enums;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels
{
	public record MovieViewModelWithDetails:MovieCardModel
	{
		public int[] ActorIds { get; init; } = Array.Empty<int>();
		//public IEnumerable<Movie> Movies{ get; set; } = Enumerable.Empty<Movie>();
		public Language OriginalLanguage { get; init; }
		public TimeSpan Duration { get; set; }
		public Director? Director { get; init; } //navigation property
		public string? Title { get; init; } //navigation property
	}
}
