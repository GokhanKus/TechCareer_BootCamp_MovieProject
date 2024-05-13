using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
	public interface IActorService
	{
		IEnumerable<Actor> GetAllActors(bool trackChanges);
		Actor? GetOneActor(int id, bool trackChanges);
		ActorViewModel GetOneActorWithMovies(int id, bool trackChanges);
		void DeleteOneActor(int id);
		void CreateOneActor(ActorViewModelForInsertion actorViewModel);
		void UpdateOneActor(ActorViewModelForUpdate actorViewModel);
		ActorViewModelForUpdate GetOneActorForUpdate(int id, bool trackChanges);
	}
}
