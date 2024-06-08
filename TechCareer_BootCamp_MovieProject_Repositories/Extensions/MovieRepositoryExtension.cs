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
		public static IQueryable<Movie> FilteredBySearchingTerm(this IQueryable<Movie> movies, string searchingTerm)
		{
			if (string.IsNullOrEmpty(searchingTerm))
				return movies;

			else
				return movies.Where(m => m.OriginalTitle.ToLower().Contains(searchingTerm.ToLower()) //film orijinal adi veya local adina gore arama yapilabilsin
					  || m.Title.ToLower().Contains(searchingTerm.ToLower()));
		}
	}
}
