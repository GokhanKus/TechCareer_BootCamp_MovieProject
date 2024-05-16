using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
using TechCareer_BootCamp_MovieProject_Repositories.Context;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class MovieService : IMovieService
	{
		private readonly IRepositoryManager _manager;
		private readonly MovieDbContext _context;
		private readonly IMapper _mapper;
		public MovieService(IRepositoryManager manager, MovieDbContext context, IMapper mapper)
		{
			_manager = manager;
			_context = context;
			_mapper = mapper;
		}
		public void CreateOneMovie(MovieViewModelForInsertion movieViewModel, int[] genreIds)
		{
			#region AutoMapper Oncesi
			//var movieToCreate = new Movie
			//{
			//	Id = movieViewModel.Id,
			//	OriginalTitle = movieViewModel.OriginalTitle,
			//	Plot = movieViewModel.Plot,
			//	Score = movieViewModel.Score,
			//	ReleaseDate = movieViewModel.ReleaseDate,
			//	PosterPath = movieViewModel.PosterPath,
			//	DirectorId = movieViewModel.DirectorId,
			//};
			#endregion
			var movieToCreate = _mapper.Map<Movie>(movieViewModel);
			_manager.Movie.CreateOneMovie(movieToCreate);
			_manager.Save();

			AddToLinkTable(movieViewModel.SelectedActorIds, genreIds, movieToCreate.Id); //many to many olan ara tablolara(genremovie, actormovie)eklemeyi yapalım
		}
		private void AddToLinkTable(List<int> movieViewModel, int[] genreIds, int movieToCreateId)
		{
			foreach (var actorId in movieViewModel)
			{
				var actorMovie = new ActorMovie
				{
					MovieId = movieToCreateId,
					ActorId = actorId
				};
				_context.ActorMovie.Add(actorMovie);
			}
			foreach (var genreId in genreIds)
			{
				var genreMovie = new GenreMovie
				{
					MovieId = movieToCreateId,
					GenreId = genreId
				};
				_context.GenreMovie.Add(genreMovie);
			}
			_manager.Save();
		}
		public void DeleteOneMovie(int id)
		{
			throw new NotImplementedException();
		}

		public void UpdateOneProduct(MovieCardModel productDto)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<MovieCardModel> GetAllMoviesWithGenres()
		{
			var movies = _manager.Movie.GetAllMoviesWithGenres();

			// Mapping logic from Movie entity to MovieViewModel

			return movies.Select(m => new MovieCardModel
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

		public async Task<IEnumerable<ActorByIdAndName>> GetActorsByIdAndName(bool trackChanges)
		{
			var actors = await _manager.Actor.GetAllActors(trackChanges).ToListAsync();
			return actors.Select(a => new ActorByIdAndName
			{
				Id = a.Id,
				FullName = a.FullName,
			});
		}
	}
}
