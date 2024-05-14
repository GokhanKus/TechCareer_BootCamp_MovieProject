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
	public class FictionalCharacterService : IFictionalCharacterService
	{
		private readonly IRepositoryManager _manager;

		public FictionalCharacterService(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public void CreateOneFictionalCharacter(FictionalCharacter fictionalCharacter)
		{
			_manager.FictionalCharacter.Create(fictionalCharacter);
			_manager.Save();
		}

		public void DeleteOneFictionalCharacter(int id)
		{
			var fictChar = _manager.FictionalCharacter.GetByCondition(f => f.Id == id, false);
			if (fictChar is not null)
			{
				_manager.FictionalCharacter.Delete(fictChar);
				_manager.Save();
			}
		}

		public IEnumerable<FictionalCharacter> GetAllFictionalCharacters(bool trackChanges)
		{
			return _manager.FictionalCharacter.GetAll(trackChanges);
		}

		public IEnumerable<FictionalCharacter> GetAllFictionalCharsWithActors(bool trackChanges)
		{
			var fictCharsWithActors = _manager.FictionalCharacter.GetAllFictionalCharsWithActors(false);
			return fictCharsWithActors;
		}

		public FictionalCharacter? GetOneFictionalCharacter(int? id, bool trackChanges)
		{
			return _manager.FictionalCharacter.GetByCondition(f => f.Id == id, false);
		}

		public FictionalCharacter? GetOneFictionalCharWithActor(int? id)
		{
			return _manager.FictionalCharacter.GetOneFictionalCharWithActor(id);
		}

		public void UpdateOneFictionalCharacter(FictionalCharacter fictionalCharacter)
		{
			_manager.FictionalCharacter.Update(fictionalCharacter);
			_manager.Save();
		}
	}
}
