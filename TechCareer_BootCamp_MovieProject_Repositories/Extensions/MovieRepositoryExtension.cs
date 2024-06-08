using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Repositories.Extensions
{
	public static class MovieRepositoryExtension
	{
		public static IQueryable<Movie> FilteredByCategoryId(this IQueryable<Movie> movies, int? genreId) //Movie'i genisletelim
		{
			if (genreId == null)
				return movies;
			else
				return movies.Where(m => m.GenreMovies.Any(mg => mg.GenreId.Equals(genreId)));
		}
	}
}
