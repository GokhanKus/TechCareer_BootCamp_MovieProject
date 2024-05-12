using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.SelectDropDownMenuModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IActorRepository _actorRepo;
        public MovieService(IMovieRepository movieRepo, IActorRepository actorRepository)
        {
            _movieRepo = movieRepo;
            _actorRepo = actorRepository;
        }
        public void CreateOneMovie(MovieViewModel movieViewModel)
        {
            throw new NotImplementedException();
        }
        public void DeleteOneMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOneProduct(MovieViewModel productDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieViewModel> GetAllMoviesWithGenres()
        {
            var movies = _movieRepo.GetAllMoviesWithGenres();

            // Mapping logic from Movie entity to MovieViewModel

            return movies.Select(m => new MovieViewModel
            {
                Id = m.Id,
                OriginalTitle = m.OriginalTitle,
                PosterPath = m.PosterPath,
                ReleaseDate = m.ReleaseDate,
                Plot = m.Plot,
                Score = m.Score,
                Genres = m.GenreMovies.Select(gm => gm.Genre).ToList()
            }).ToList();
        }

        public Movie GetOneMovie(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActorByIdAndName> GetActorsByIdAndName(bool trackChanges)
        {
            var actors = _actorRepo.GetAllActors(trackChanges);
            return actors.Select(a => new ActorByIdAndName
            {
                Id = a.Id,
                FullName = a.FullName,
            });
        }
    }
}
