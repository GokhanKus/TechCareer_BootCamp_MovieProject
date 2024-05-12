using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context)
        {
            
        }
        public void CreateOneMovie(Movie movie)
        {
            Create(movie);
        }
        public void DeleteOneMovie(Movie movie)
        {
            Delete(movie);
        }
        public void UpdateOneMovie(Movie movie)
        {
            Update(movie);
        }
        public IQueryable<Movie> GetAllMovies(bool trackChanges)
        {
            return GetAll(trackChanges);
        }
        public Movie? GetOneMovie(int id, bool trackChanges)
        {
            //return FindByCondition(p => p.Id == id, trackChanges);
            return GetByCondition(i => i.Id.Equals(id), trackChanges);
        }
        public IEnumerable<Movie> GetAllMoviesWithGenres()
        {
            return _context.Movies
            .Include(m => m.GenreMovies)
            .ThenInclude(gm => gm.Genre)
            .ToList();
        }
    }
}
