using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;

namespace TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        IQueryable<Director> GetAllDirectors(bool trackChanges);
        Director? GetOneDirector(int? id, bool trackChanges);
        void CreateOneDirector(Director director);
        void DeleteOneDirector(Director director);
        void UpdateOneDirector(Director director);
    }
}
