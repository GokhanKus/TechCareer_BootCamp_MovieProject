using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class ActorService : IActorService
	{
		private readonly IRepositoryManager _manager;
		public ActorService(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public void CreateOneActor(ActorViewModelForInsertion actorViewModel)
		{
			var actorToCreate = new Actor
			{
				FullName = actorViewModel.FullName,
				ImagePath = actorViewModel.ImagePath,
			};
			_manager.Actor.CreateOneActor(actorToCreate);
			_manager.Save();
		}

		public void DeleteOneActor(int id)
		{
			var actor = _manager.Actor.GetOneActor(id, false);
			if (actor is not null)
			{
				_manager.Actor.DeleteOneActor(actor);
				_manager.Save();
			}
		}

		public IEnumerable<Actor> GetAllActors(bool trackChanges)
		{
			return _manager.Actor.GetAllActors(trackChanges);
		}

		public ActorViewModel GetOneActorWithMovies(int id, bool trackChanges)
		{
			var actor = _manager.Actor.GetOneActorWithMovies(id, trackChanges);
			var actorViewModel = new ActorViewModel
			{
				Id = actor.Id,
				FullName = actor.FullName,
				ImagePath = actor.ImagePath,
				Movies = actor.ActorMovies.Select(am => new Movie //new MovieViewModel
				{
					Id = am.Movie.Id,
					OriginalTitle = am.Movie.OriginalTitle,
					PosterPath = am.Movie.PosterPath,
				}).ToList()
			};

			return actorViewModel;
		}

		public Actor? GetOneActor(int id, bool trackChanges)
		{
			return _manager.Actor.GetOneActor(id, trackChanges);
		}

		public void UpdateOneActor(ActorViewModelForUpdate actorViewModel)
		{
			var actorToUpdate = _manager.Actor.GetOneActor(actorViewModel.Id, true);
			if (actorToUpdate != null)
			{
				actorToUpdate.FullName = actorViewModel.FullName;
				actorToUpdate.ImagePath = actorViewModel.ImagePath;
				actorToUpdate.DoB = actorViewModel.DoB;
				actorToUpdate.Biography = actorViewModel.Biography;
				actorToUpdate.PlaceOfBirth = actorViewModel.PlaceOfBirth;

				_manager.Actor.UpdateOneActor(actorToUpdate);
				_manager.Save();
			}
		}

		public ActorViewModelForUpdate GetOneActorForUpdate(int id, bool trackChanges)
		{
			var actor = _manager.Actor.GetOneActor(id, false);
			var actorViewModel = new ActorViewModelForUpdate
			{
				Id = actor.Id,
				FullName = actor.FullName,
				Biography = actor.Biography,
				DoB = actor.DoB,
				PlaceOfBirth = actor.PlaceOfBirth,
				ImagePath = actor.ImagePath,
			};
			return actorViewModel;
		}
	}
}
