using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres(bool trackChanges);
        void CreateOneGenre(Genre genre);
        Genre? GetOneGenre(int? id, bool trackChanges);
        void UpdateOneGenre(Genre genre);
        void DeleteOneGenre(int id);
    }
}
