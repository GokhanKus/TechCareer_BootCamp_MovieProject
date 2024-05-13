using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;

namespace TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos
{
    public interface IGenreRepository:IBaseRepository<Genre>
    {
		IQueryable<Genre> GetAllGenres(bool trackChanges);
		Genre? GetOneGenre(int? id, bool trackChanges);
		void CreateOneGenre(Genre genre);
		void DeleteOneGenre(Genre genre);
		void UpdateOneGenre(Genre genre);
	}
}
