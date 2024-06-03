using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
	public interface IAuthService
	{
		//TODO: Rollerle ilgili temel crud islemlerini yap.
		IEnumerable<IdentityRole> GetAllRoles();
		HashSet<string> GetAllRolesWithHashSetStringType();
		IEnumerable<IdentityUser> GetAllUsers();
		//Task<IdentityUser> GetOneUserAsync(string userName);
		Task<UserViewModelForUpdate> GetOneUserForUpdateAsync(string userName);
		Task UpdateUserAsync(UserViewModelForUpdate user);
		Task<IdentityResult> CreateUserAsync(UserViewModelForInsertion userModel);
		Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel resetPasswordModel);
		Task<IdentityResult> DeleteUser(string userName);
	}
}
