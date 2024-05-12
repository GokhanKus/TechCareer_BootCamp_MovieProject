using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.Entities;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels
{
    public record ActorViewModel
    {
        public int Id { get; init; }
        public string? FullName { get; init; }
        public string? ImagePath{ get; init; }
        public IEnumerable<Movie> Movies{ get; init; } = Enumerable.Empty<Movie>();
    }
}
