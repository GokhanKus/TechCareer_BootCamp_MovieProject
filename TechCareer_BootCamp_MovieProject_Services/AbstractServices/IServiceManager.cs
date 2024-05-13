using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
	public interface IServiceManager
	{
		IActorService ActorService { get; }
		IDirectorService DirectorService { get; }
		IFictionalCharacterService FictionalCharacter { get; }
		IGenreService GenreService { get; }
		IMovieService MovieService { get; }
	}
}
