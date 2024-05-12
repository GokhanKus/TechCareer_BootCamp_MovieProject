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
        private readonly IFictionalCharacterRepository _fictionalCharacterRepo;

        public FictionalCharacterService(IFictionalCharacterRepository fictionalCharacterRepository)
        {
            _fictionalCharacterRepo = fictionalCharacterRepository;
        }

        public void CreateOneFictionalCharacter(FictionalCharacter fictionalCharacter)
        {
            _fictionalCharacterRepo.Create(fictionalCharacter);
        }

        public void UpdateOneFictionalCharacter(FictionalCharacter fictionalCharacter)
        {
            _fictionalCharacterRepo.Update(fictionalCharacter);
        }
    }
}
