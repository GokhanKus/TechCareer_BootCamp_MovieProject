using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.SelectDropDownMenuModels;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
	public interface IMovieService
	{
		Movie GetOneMovie(int id, bool trackChanges);
		Task<MovieViewModelForUpdate>? GetOneMovieWithDetails(int id, bool trackChanges);
		Task<IEnumerable<MovieCardModel>> GetAllMoviesWithGenres();
		IEnumerable<Movie> GetAllMovies(bool trackChanges);
		void DeleteOneMovie(int id);
		void CreateOneMovie(MovieViewModelForInsertion movieViewModel, int[] genreIds);
		void UpdateOneMovie(MovieViewModelForUpdate movieViewModel, int[] genreIds);
		//Task<IEnumerable<ActorByIdAndName>> GetActorsByIdAndName(bool trackChanges);
	}
}
