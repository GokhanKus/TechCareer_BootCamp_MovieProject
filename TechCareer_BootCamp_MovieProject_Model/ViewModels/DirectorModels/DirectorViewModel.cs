using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.DirectorModels
{
    public record DirectorViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; init; }
        public DateTime DoB { get; init; } //Date of Birth
        public string? PlaceOfBirth { get; init; }
        public string? Biography { get; init; }
        public string? ImagePath { get; set; }
    }
}
