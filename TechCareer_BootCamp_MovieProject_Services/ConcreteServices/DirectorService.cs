using AutoMapper;
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
		private readonly IMapper _mapper;
		public DirectorService(IRepositoryManager manager, IMapper mapper)
		{
			_manager = manager;
			_mapper = mapper;
		}

		public void CreateOneDirector(DirectorViewModelForInsertion directorViewModel)
		{
			#region AutoMapperOncesi
			//var director = new Director
			//{
			//	FullName = directorViewModel.FullName,
			//	Biography = directorViewModel.Biography,
			//	DoB = directorViewModel.DoB,
			//	ImagePath = directorViewModel.ImagePath,
			//	PlaceOfBirth = directorViewModel.PlaceOfBirth,
			//};
			//auto mapper ile yukaridaki koda gerek kalmadi
			#endregion

			var director = _mapper.Map<Director>(directorViewModel); //modele gelen veriler, Director ile otomatik eslesecek 
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
			#region AutoMapperOncesi
			//var director = _manager.Director.GetOneDirector(id, trackChanges);
			//var directorViewModel = new DirectorViewModelForUpdate
			//{
			//	Id = director.Id,
			//	FullName = director.FullName,
			//	Biography = director.Biography,
			//	DoB = director.DoB,
			//	ImagePath = director.ImagePath,
			//	PlaceOfBirth = director.PlaceOfBirth,
			//};
			#endregion

			var director = _manager.Director.GetOneDirector(id, trackChanges);
			var directorViewModel = _mapper.Map<DirectorViewModelForUpdate>(director);
			return directorViewModel;
		}

		public void UpdateOneDirector(DirectorViewModelForUpdate directorViewModel)
		{
			#region AutoMapperOncesi
			//var directorToUpdate = _manager.Director.GetOneDirector(directorViewModel.Id, true);
			//if (directorToUpdate != null)
			//{
			//	directorToUpdate.Id = directorViewModel.Id;
			//	directorToUpdate.ImagePath = directorViewModel.ImagePath;
			//	directorToUpdate.Biography = directorViewModel.Biography;
			//	directorToUpdate.DoB = directorViewModel.DoB;
			//	directorToUpdate.FullName = directorViewModel.FullName;
			//	directorToUpdate.PlaceOfBirth = directorViewModel.PlaceOfBirth;
			//	_manager.Director.UpdateOneDirector(directorToUpdate);
			//	_manager.Save();
			//}
			#endregion
			//var directorToUpdate = _manager.Director.GetOneDirector(directorViewModel.Id, true);
			var director = _mapper.Map<Director>(directorViewModel);
			_manager.Director.UpdateOneDirector(director);
			_manager.Save();
		}
	}
}
