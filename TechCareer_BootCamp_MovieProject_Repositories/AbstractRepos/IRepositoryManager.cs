using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos
{
	public interface IRepositoryManager
	{
		IActorRepository Actor { get; }
		IDirectorRepository Director { get; }
		IFictionalCharacterRepository FictionalCharacter { get; }
		IGenreRepository Genre { get; }
		IMovieRepository Movie { get; }
		public void Save();
	}
}
