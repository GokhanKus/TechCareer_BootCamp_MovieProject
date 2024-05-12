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
        private readonly IGenreRepository _genreRepo;
        public GenreService(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public void CreateOneGenre(Genre genre)
        {
            _genreRepo.Create(genre);
        }

        public IEnumerable<Genre> GetAllGenres(bool trackChanges)
        {
            return _genreRepo.GetAll(trackChanges);
        }
    }
}
