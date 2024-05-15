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
		public RepositoryManager(MovieDbContext context, IActorRepository actorRepo, IDirectorRepository directorRepo, IFictionalCharacterRepository fictionalCharacterRepo, IGenreRepository genreRepo, IMovieRepository movieRepo)
		{
			_context = context;
			_actorRepo = actorRepo;
			_directorRepo = directorRepo;
			_fictionalCharacterRepo = fictionalCharacterRepo;
			_genreRepo = genreRepo;
			_movieRepo = movieRepo;
		}

		public IActorRepository Actor => _actorRepo;
		public IDirectorRepository Director => _directorRepo;
		public IFictionalCharacterRepository FictionalCharacter => _fictionalCharacterRepo;
		public IGenreRepository Genre => _genreRepo;
		public IMovieRepository Movie => _movieRepo;
		public void SaveAsync()
		{
			_context.SaveChangesAsync();
		}
	}
}
