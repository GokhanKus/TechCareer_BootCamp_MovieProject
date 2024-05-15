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
			_manager.SaveAsync();
		}

		public void DeleteOneFictionalCharacter(int id)
		{
			var fictChar = _manager.FictionalCharacter.GetByCondition(f => f.Id == id, false);
			if (fictChar is not null)
			{
				_manager.FictionalCharacter.Delete(fictChar);
				_manager.SaveAsync();
			}
		}

		public IEnumerable<FictionalCharacter> GetAllFictionalCharacters(bool trackChanges)
		{
			return _manager.FictionalCharacter.GetAll(trackChanges);
		}

		public async Task<IEnumerable<FictionalCharacter>> GetAllFictionalCharsWithActors(bool trackChanges)
		{
			var fictCharsWithActors = await _manager.FictionalCharacter.GetAllFictionalCharsWithActors(false);
			return fictCharsWithActors;
		}

		public FictionalCharacter? GetOneFictionalCharacter(int? id, bool trackChanges)
		{
			return _manager.FictionalCharacter.GetByCondition(f => f.Id == id, false);
		}

		public async Task<FictionalCharacter>? GetOneFictionalCharWithActor(int? id)
		{
			return await _manager.FictionalCharacter.GetOneFictionalCharWithActor(id);
		}

		public void UpdateOneFictionalCharacter(FictionalCharacter fictionalCharacter)
		{
			_manager.FictionalCharacter.Update(fictionalCharacter);
			_manager.SaveAsync();
		}
	}
}
