using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly MovieDbContext _context;
		private readonly IActorRepository _actorRepo;
		private readonly IDirectorRepository _directorRepo;
		private readonly IFictionalCharacterRepository _fictionalCharacterRepo;
		private readonly IGenreRepository _genreRepo;
		private readonly IMovieRepository _movieRepo;
		private readonly IMovieRepository _actorMovieRepo;
		private readonly IMovieRepository _genreMovieRepo;
		public RepositoryManager(MovieDbContext context, IActorRepository actorRepo, IDirectorRepository directorRepo, IFictionalCharacterRepository fictionalCharacterRepo, IGenreRepository genreRepo, IMovieRepository movieRepo, IMovieRepository genreMovieRepo, IMovieRepository actorMovieRepo)
		{
			_context = context;
			_actorRepo = actorRepo;
			_directorRepo = directorRepo;
			_fictionalCharacterRepo = fictionalCharacterRepo;
			_genreRepo = genreRepo;
			_movieRepo = movieRepo;
			_genreMovieRepo = genreMovieRepo;
			_actorMovieRepo = actorMovieRepo;
		}

		public IActorRepository Actor => _actorRepo;
		public IDirectorRepository Director => _directorRepo;
		public IFictionalCharacterRepository FictionalCharacter => _fictionalCharacterRepo;
		public IGenreRepository Genre => _genreRepo;
		public IMovieRepository Movie => _movieRepo;

		public IMovieRepository ActorMovie => _actorMovieRepo;

		public IMovieRepository GenreMovie => _genreMovieRepo;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
