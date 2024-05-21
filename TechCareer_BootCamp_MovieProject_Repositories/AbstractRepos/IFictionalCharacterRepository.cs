using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.BaseRepos;

namespace TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos
{
	public interface IFictionalCharacterRepository : IBaseRepository<FictionalCharacter>
	{
		Task<IEnumerable<FictionalCharacter>> GetAllFictionalCharsWithActors(bool trackChanges);
		FictionalCharacter? GetOneFictionalCharWithActor(int? id);
		void CreateOneFictionalCharacter(FictionalCharacter fictionalChar);
		void DeleteOneFictionalCharacter(FictionalCharacter fictionalChar);
		void UpdateOneFictionalCharacter(FictionalCharacter fictionalChar);
	}
}
