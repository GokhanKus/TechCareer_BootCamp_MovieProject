using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepo;

        public ActorService(IActorRepository actorRepo)
        {
            _actorRepo = actorRepo;
        }

        public void CreateOneActor(ActorViewModel actorViewModel)
        {
            CreateOneActor(actorViewModel);
        }

        public void DeleteOneActor(int id)
        {
            DeleteOneActor(id);
        }

        public IEnumerable<Actor> GetAllActors(bool trackChanges)
        {
            return GetAllActors(trackChanges);
        }

        public ActorViewModel GetOneActorWithMovies(int id, bool trackChanges)
        {
            var actor = _actorRepo.GetOneActorWithMovies(id, trackChanges);
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

        public Movie GetOneActor(int id, bool trackChanges)
        {
            return GetOneActor(id, trackChanges);
        }

        public void UpdateOneActor(ActorViewModel actorViewModel)
        {
            UpdateOneActor(actorViewModel);
        }
    }
}
