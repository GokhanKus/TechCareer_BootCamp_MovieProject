using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class ActorService : IActorService
	{
		private readonly IRepositoryManager _manager;
		private readonly IMapper _mapper;
		public ActorService(IRepositoryManager manager, IMapper mapper)
		{
			_manager = manager;
			_mapper = mapper;
		}

		public void CreateOneActor(ActorViewModelForInsertion actorViewModel)
		{
			#region AutoMapper oncesi
			//var actorToCreate = new Actor
			//{
			//	FullName = actorViewModel.FullName,
			//	ImagePath = actorViewModel.ImagePath,
			//};
			#endregion
			var actorToCreate = _mapper.Map<Actor>(actorViewModel);
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

		public async Task<IEnumerable<Actor>> GetAllActors(bool trackChanges)
		{
			return await _manager.Actor.GetAllActors(trackChanges).ToListAsync();
		}

		public ActorViewModelWithDetails GetOneActorWithMovies(int id, bool trackChanges)
		{
			//var actor = _manager.Actor.GetOneActorWithMovies(id, trackChanges);
			//var actorViewModel = new ActorViewModelWithDetails
			//{
			//	Id = actor.Id,
			//	FullName = actor.FullName,
			//	ImagePath = actor.ImagePath,
			//	Biography = actor.Biography,
			//	PlaceOfBirth = actor.PlaceOfBirth,
			//	DoB = actor.DoB,
			//	Movies = actor.ActorMovies.Select(am => new Movie //new MovieViewModel
			//	{
			//		Id = am.Movie.Id,
			//		OriginalTitle = am.Movie.OriginalTitle,
			//		PosterPath = am.Movie.PosterPath,
			//	}).ToList()
			//};
			var actor1 = _manager.Actor.GetOneActorWithMovies(id, trackChanges);

			var actorModel = _mapper.Map<ActorViewModelWithDetails>(actor1);
			actorModel.Movies = actor1.ActorMovies.Select(am => new Movie
			{
				Id = am.Movie.Id,
				OriginalTitle = am.Movie.OriginalTitle,
				PosterPath = am.Movie.PosterPath,
			}).ToList();

			return actorModel;
		}

		public Actor? GetOneActor(int id, bool trackChanges)
		{
			return _manager.Actor.GetOneActor(id, trackChanges);
		}

		public ActorViewModelForUpdate GetOneActorForUpdate(int id, bool trackChanges)
		{
			#region AutoMapper Oncesi
			//var actor = _manager.Actor.GetOneActor(id, false);
			//var actorViewModel = new ActorViewModelForUpdate
			//{
			//	Id = actor.Id,
			//	FullName = actor.FullName,
			//	Biography = actor.Biography,
			//	DoB = actor.DoB,
			//	PlaceOfBirth = actor.PlaceOfBirth,
			//	ImagePath = actor.ImagePath,
			//};
			#endregion
			var actor = _manager.Actor.GetOneActor(id, false);
			var actorViewModel = _mapper.Map<ActorViewModelForUpdate>(actor);
			return actorViewModel;
		}
		public void UpdateOneActor(ActorViewModelForUpdate actorViewModel)
		{
			#region AutoMapper Oncesi
			//var actorToUpdate = _manager.Actor.GetOneActor(actorViewModel.Id, true);
			//if (actorToUpdate != null)
			//{
			//	actorToUpdate.FullName = actorViewModel.FullName;
			//	actorToUpdate.ImagePath = actorViewModel.ImagePath;
			//	actorToUpdate.DoB = actorViewModel.DoB;
			//	actorToUpdate.Biography = actorViewModel.Biography;
			//	actorToUpdate.PlaceOfBirth = actorViewModel.PlaceOfBirth;

			//	_manager.Actor.UpdateOneActor(actorToUpdate);
			//	_manager.Save();
			//}
			#endregion
			var actorToUpdate = _mapper.Map<Actor>(actorViewModel);
			_manager.Actor.UpdateOneActor(actorToUpdate);
			_manager.Save();
		}
	}
}
