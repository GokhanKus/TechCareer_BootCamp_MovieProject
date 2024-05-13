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
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieDbContext context) : base(context)
        {
        }

        public void CreateOneDirector(Director director)
        {
            Create(director);
        }

        public void DeleteOneDirector(Director director)
        {
            Delete(director);
        }
        public void UpdateOneDirector(Director director)
        {
            Update(director);
        }

        public IQueryable<Director> GetAllDirectors(bool trackChanges)
        {
            return GetAll(trackChanges);
        }

        public Director? GetOneDirector(int? id, bool trackChanges)
        {
            return GetByCondition(d => d.Id == id, trackChanges);
        }

    }
}
