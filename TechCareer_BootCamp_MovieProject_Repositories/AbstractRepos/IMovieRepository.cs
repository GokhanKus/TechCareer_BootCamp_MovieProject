using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;

namespace TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos
{
	public interface IMovieRepository : IBaseRepository<Movie>
	{
		IQueryable<Movie> GetAllMovies(bool trackChanges);
		Task<IEnumerable<Movie>> GetAllMoviesWithGenres();
		Movie? GetOneMovie(int id, bool trackChanges);
		Task<Movie> GetOneMovieWithDetails(int id, bool trackChanges);
		void CreateOneMovie(Movie movie);
		void DeleteOneMovie(Movie movie);
		void UpdateOneMovie(Movie movie);
	}
}
