﻿using AutoMapper;
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
			var movie = _manager.Movie.GetOneMovie(id, false);
			if (movie is not null)
			{
				_manager.Movie.DeleteOneMovie(movie);
				_manager.Save();
			}
		}

		public void UpdateOneProduct(MovieCardModel productDto)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<MovieCardModel>> GetAllMoviesWithGenres()
		{
			var movies = await _manager.Movie.GetAllMoviesWithGenres();

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
			var movie = _manager.Movie.GetOneMovie(id, trackChanges);

			if (movie is null)
				throw new NullReferenceException("movie couldn't find");

			return movie;
		}

		public IEnumerable<Movie> GetAllMovies(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public async Task<MovieViewModelForUpdate>? GetOneMovieWithDetails(int id, bool trackChanges)
		{
			var movieWithDetails = await _manager.Movie.GetOneMovieWithDetails(id, trackChanges);
			//var movieDto = new MovieViewModelWithDetails
			//{
			//	Id = movieWithDetails.Id,
			//	Duration = movieWithDetails.Duration,
			//	OriginalLanguage = movieWithDetails.OriginalLanguage,
			//	Plot = movieWithDetails.Plot,
			//	PosterPath = movieWithDetails.PosterPath,
			//	OriginalTitle = movieWithDetails.OriginalTitle,
			//	Title = movieWithDetails.Title,
			//	ReleaseDate = movieWithDetails.ReleaseDate,
			//	Score = movieWithDetails.Score,
			//	DirectorId = movieWithDetails.DirectorId,
			//	Director = movieWithDetails.Director,
			//	Genres = movieWithDetails.GenreMovies.Select(gm => gm.Genre).ToList(),
			//	Actors = movieWithDetails.ActorMovies.Select(am => am.Actor).ToList(),
			//};
			var movieViewModel = _mapper.Map<MovieViewModelForUpdate>(movieWithDetails);
			movieViewModel.Actors = movieWithDetails.ActorMovies.Select(am=>am.Actor).ToList();
			movieViewModel.Genres = movieWithDetails.GenreMovies.Select(gm=>gm.Genre).ToList();
			//actors, genres, director 
			return movieViewModel;
		}

		//public async Task<IEnumerable<ActorByIdAndName>> GetActorsByIdAndName(bool trackChanges)
		//{
		//	var actors = await _manager.Actor.GetAllActors(trackChanges).ToListAsync();
		//	return actors.Select(a => new ActorByIdAndName
		//	{
		//		Id = a.Id,
		//		FullName = a.FullName,
		//	});
		//}
	}
}
