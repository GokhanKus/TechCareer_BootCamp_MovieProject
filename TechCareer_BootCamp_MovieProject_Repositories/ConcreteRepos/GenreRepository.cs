using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos
{
    public class GenreRepository : BaseRepository<Genre>,IGenreRepository
    {
        public GenreRepository(MovieDbContext context) : base(context)
        {
            
        }
		public void CreateOneGenre(Genre genre)
		{
			Create(genre);
		}
		public void DeleteOneGenre(Genre genre)
		{
			Delete(genre);
		}
		public void UpdateOneGenre(Genre genre)
		{
			Update(genre);
		}
		public IQueryable<Genre> GetAllGenres(bool trackChanges)
		{
			return GetAll(trackChanges);
		}
		public Genre? GetOneGenre(int? id, bool trackChanges)
		{
			return GetByCondition(g=>g.Id == id, trackChanges);
		}
	}
}
