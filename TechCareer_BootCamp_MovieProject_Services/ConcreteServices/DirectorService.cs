using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.DirectorModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class DirectorService : IDirectorService
	{
		private readonly IRepositoryManager _manager;

		public DirectorService(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public void CreateOneDirector(DirectorViewModelForInsertion directorViewModel)
		{
			var director = new Director
			{
				FullName = directorViewModel.FullName,
				Biography = directorViewModel.Biography,
				DoB = directorViewModel.DoB,
				ImagePath = directorViewModel.ImagePath,
				PlaceOfBirth = directorViewModel.PlaceOfBirth,
			};
			_manager.Director.CreateOneDirector(director);
			_manager.Save();
		}

		public void DeleteOneDiretor(int? id)
		{
			var director = _manager.Director.GetOneDirector(id, false);
			if (director is not null)
			{
				_manager.Director.DeleteOneDirector(director);
				_manager.Save();
			}
		}

		public IEnumerable<Director> GetAllDirectors(bool trackChanges)
		{
			return _manager.Director.GetAllDirectors(trackChanges);
		}

		public Director? GetOneDirector(int? id, bool trackChanges)
		{
			return _manager.Director.GetOneDirector(id, trackChanges);
		}

		public DirectorViewModelForUpdate GetOneDirectorForUpdate(int id, bool trackChanges)
		{
			var director = _manager.Director.GetOneDirector(id, trackChanges);
			var directorViewModel = new DirectorViewModelForUpdate
			{
				Id = director.Id,
				FullName = director.FullName,
				Biography = director.Biography,
				DoB = director.DoB,
				ImagePath = director.ImagePath,
				PlaceOfBirth = director.PlaceOfBirth,
			};
			return directorViewModel;
		}

		public void UpdateOneDirector(DirectorViewModelForUpdate directorViewModel)
		{
			var directorToUpdate = _manager.Director.GetOneDirector(directorViewModel.Id, true);
			if (directorToUpdate != null)
			{   //Auto mapper eklenecek
				directorToUpdate.Id = directorViewModel.Id;
				directorToUpdate.ImagePath = directorViewModel.ImagePath;
				directorToUpdate.Biography = directorViewModel.Biography;
				directorToUpdate.DoB = directorViewModel.DoB;
				directorToUpdate.FullName = directorViewModel.FullName;
				directorToUpdate.PlaceOfBirth = directorViewModel.PlaceOfBirth;
				_manager.Director.UpdateOneDirector(directorToUpdate);
				_manager.Save();
			}
		}
	}
}
