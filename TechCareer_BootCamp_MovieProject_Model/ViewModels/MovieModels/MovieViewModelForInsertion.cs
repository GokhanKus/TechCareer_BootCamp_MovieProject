using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels
{
	public record MovieViewModelForInsertion : MovieCardModel
	{
		//public int[] ActorIds { get; init; } = Array.Empty<int>();
		public IEnumerable<Actor> Actors { get; set; } = new List<Actor>();
		public List<int> SelectedActorIds { get; set; } = new List<int>();
		public Director? Director{ get; set; }
		public int DirectorId{ get; set; }
	}
}
