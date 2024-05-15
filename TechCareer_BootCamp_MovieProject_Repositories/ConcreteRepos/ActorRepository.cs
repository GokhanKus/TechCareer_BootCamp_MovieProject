using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieDbContext context) : base(context)
        {
        }

        public void CreateOneActor(Actor actor)
        {
            Create(actor);
        }

        public void DeleteOneActor(Actor actor)
        {
            Delete(actor);
        }

        public async Task<IEnumerable<Actor>> GetAllActors(bool trackChanges)
        {
            return await GetAll(trackChanges).ToListAsync();
        }

        public async Task<Actor> GetOneActorWithMovies(int id, bool trackChanges)
        {
            var actorWithMovies =await _context.Actors.Include(a => a.ActorMovies).ThenInclude(am => am.Movie).FirstOrDefaultAsync(a => a.Id == id);
            return actorWithMovies;
        }

        public Actor? GetOneActor(int id, bool trackChanges)
        {
            return GetByCondition(a=>a.Id == id,trackChanges);
        }

        public void UpdateOneActor(Actor actor)
        {
            Update(actor);
        }
    }
}
