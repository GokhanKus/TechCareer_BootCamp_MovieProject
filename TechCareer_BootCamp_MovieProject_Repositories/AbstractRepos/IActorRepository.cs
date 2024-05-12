using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;

namespace TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos
{
    public interface IActorRepository: IBaseRepository<Actor>
    {
        IQueryable<Actor> GetAllActors(bool trackChanges);
        Actor GetOneActorWithMovies(int id, bool trackChanges);
        Actor? GetOneActor(int id, bool trackChanges);
        void CreateOneActor(Actor actor);
        void DeleteOneActor(Actor actor);
        void UpdateOneActor(Actor actor);
    }
}
