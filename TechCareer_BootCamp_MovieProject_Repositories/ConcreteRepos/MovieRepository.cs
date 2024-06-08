using Microsoft.EntityFrameworkCore;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.RequestParameters;
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
		public IQueryable<Movie> GetAllMoviesWithDetails(MovieRequestParameters p)
		{
			if (p.GenreId is null) //user eger bir genre belirtmemisse (orn dram turundeki filmleri listelemediyse) butun filmler genreleriyle beraber gelsin
			{
				return _context.Movies
					   .Include(m => m.GenreMovies)
					   .ThenInclude(gm => gm.Genre);
			}
			else //eger bir turdeki filmleri istediyse o türe ait filmlerin listesi gelsin
			{
				return _context.Movies
						.Include(m => m.GenreMovies)
						.ThenInclude(gm => gm.Genre)
						.Where(m => m.GenreMovies.Any(mg => mg.GenreId == p.GenreId));
			}
		}

		public async Task<Movie> GetOneMovieWithDetails(int id, bool trackChanges)
		{
			var movieViewDetails = await _context.Movies.Where(m => m.Id == id)
				.Include(m => m.ActorMovies).ThenInclude(am => am.Actor)
				.Include(m => m.GenreMovies).ThenInclude(gm => gm.Genre)
				.Include(m => m.Director)
				.FirstOrDefaultAsync();
			return movieViewDetails;
		}
	}
}
