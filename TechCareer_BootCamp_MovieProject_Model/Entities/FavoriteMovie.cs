using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
	public class FavoriteMovie
	{
		public int Id { get; set; }
		public Movie Movie { get; set; } = new();
	}
}
