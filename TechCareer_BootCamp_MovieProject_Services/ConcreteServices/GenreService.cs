using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class GenreService : IGenreService
	{
		private readonly IRepositoryManager _manager;
		public GenreService(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public void CreateOneGenre(Genre genre)
		{
			_manager.Genre.Create(genre);
			_manager.Save();
		}

		public void DeleteOneGenre(int id)
		{
			Genre? genre = _manager.Genre.GetOneGenre(id, trackChanges: false);
			if (genre is not null)
			{
				_manager.Genre.DeleteOneGenre(genre);
				_manager.Save();
			}
		}

		public IEnumerable<Genre> GetAllGenres(bool trackChanges)
		{
			return _manager.Genre.GetAll(trackChanges);
		}

		public Genre? GetOneGenre(int? id, bool trackChanges)
		{
			var genre = _manager.Genre.GetOneGenre(id, trackChanges);
			return genre;
		}

		public void UpdateOneGenre(Genre genre)
		{
			var genreToUpdate = _manager.Genre.GetOneGenre(genre.Id, trackChanges: true);
			if (genreToUpdate is not null)
			{
				genreToUpdate.Name = genre.Name;
				_manager.Genre.UpdateOneGenre(genreToUpdate);
				_manager.Save();
			}
		}
	}
}
