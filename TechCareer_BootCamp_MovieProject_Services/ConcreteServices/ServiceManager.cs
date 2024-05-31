using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class ServiceManager : IServiceManager
	{
		private readonly IActorService _actorService;
		private readonly IDirectorService _directorService;
		private readonly IFictionalCharacterService _fictionalCharacterService;
		private readonly IGenreService _genreService;
		private readonly IMovieService _movieService;
		private readonly IAuthService _authService;

		public ServiceManager(IActorService actorService, IDirectorService directorService, IFictionalCharacterService fictionalCharacterService, IGenreService genreService, IMovieService movieService, IAuthService authService)
		{
			_actorService = actorService;
			_directorService = directorService;
			_fictionalCharacterService = fictionalCharacterService;
			_genreService = genreService;
			_movieService = movieService;
			_authService = authService;
		}

		public IActorService ActorService => _actorService;
		public IDirectorService DirectorService => _directorService;
		public IFictionalCharacterService FictionalCharacter => _fictionalCharacterService;
		public IGenreService GenreService => _genreService;
		public IMovieService MovieService => _movieService;
		public IAuthService AuthService => _authService;
	}
}

