using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels
{
	public record UserViewModelForInsertion : UserViewModel
	{
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }

		[Required]
		[DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; init; }
    }
}
