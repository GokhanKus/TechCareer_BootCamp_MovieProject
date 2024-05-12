using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
    public interface IMovieService
    {
        Movie GetOneMovie(int id, bool trackChanges);
        IEnumerable<MovieViewModel> GetAllMoviesWithGenres();
        IEnumerable<Movie> GetAllMovies(bool trackChanges);
        void DeleteOneMovie(int id);
        void CreateOneMovie(MovieViewModel movieViewModel);
        void UpdateOneProduct(MovieViewModel productDto);
        IEnumerable<ActorViewModelByIdAndName> GetActorsByIdAndName(bool trackChanges);
    }
}
