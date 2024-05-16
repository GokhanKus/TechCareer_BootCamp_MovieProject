using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.DirectorModels;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>> GetAllDirectors(bool trackChanges);
        Director? GetOneDirector(int? id, bool trackChanges);
        void CreateOneDirector(DirectorViewModelForInsertion directorViewModel);
        void UpdateOneDirector(DirectorViewModelForUpdate directorViewModel);
        DirectorViewModelForUpdate GetOneDirectorForUpdate(int id, bool trackChanges);
        void DeleteOneDiretor(int? id);
    }
}
