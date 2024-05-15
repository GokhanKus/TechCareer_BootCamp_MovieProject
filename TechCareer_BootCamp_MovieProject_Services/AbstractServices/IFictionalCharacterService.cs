using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
    public interface IFictionalCharacterService
    {
        void CreateOneFictionalCharacter(FictionalCharacter fictionalCharacter);
        void UpdateOneFictionalCharacter(FictionalCharacter fictionalCharacter);
        FictionalCharacter? GetOneFictionalCharacter(int? id, bool trackChanges);
        IEnumerable<FictionalCharacter> GetAllFictionalCharacters(bool trackChanges);
        Task<IEnumerable<FictionalCharacter>> GetAllFictionalCharsWithActors(bool trackChanges);
        Task<FictionalCharacter>? GetOneFictionalCharWithActor(int? id);
        void DeleteOneFictionalCharacter(int id);   
	}
}
