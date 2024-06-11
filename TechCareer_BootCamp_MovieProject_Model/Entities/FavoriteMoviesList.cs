using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.Entities
{
	public class FavoriteMoviesList
	{
		public List<FavoriteMovie> FavoriteMovies { get; set; }
		public FavoriteMoviesList()
		{
			FavoriteMovies = new List<FavoriteMovie>();
		}
		public virtual void AddItem(Movie movie)//metot imzası ilerde virtual olabilir, cunku bu metodu ezebiliriz.
		{
			//FavoriteMovie? favMovie = FavoriteMovies.Where(fm => fm.Movie.Id == movie.Id).FirstOrDefault();
			//if (favMovie is null) //bu kontrolün amaci, ayni itemi tekrar eklemeyi onlemek amaciyla yapilmasidir
			//{
			//	FavoriteMovies.Add(new FavoriteMovie
			//	{
			//		Movie = movie,
			//	});
			//}

			// Var olan favori filmler arasında aynı ID'ye sahip bir film var mı?
			bool exists = FavoriteMovies.Any(fm => fm.Movie.Id == movie.Id);
			if (!exists)
			{
				FavoriteMovies.Add(new FavoriteMovie
				{
					Movie = movie,
				});
			}
		}
		public virtual void RemoveItem(Movie movie) =>
			FavoriteMovies.RemoveAll(fm => fm.Movie.Id == movie.Id);

		public virtual void Clear() =>
			FavoriteMovies.Clear();
	}
}
