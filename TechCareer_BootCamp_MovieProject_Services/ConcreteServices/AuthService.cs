using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_Services.ConcreteServices
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IMapper _mapper;
		public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_mapper = mapper;
		}
		public IEnumerable<IdentityRole> GetAllRoles()
		{
			return _roleManager.Roles.ToList();
		}
		public HashSet<string> GetAllRolesWithHashSetStringType()
		{
			return _roleManager.Roles.Select(r => r.Name!).ToList().ToHashSet();
		}
		public IEnumerable<IdentityUser> GetAllUsers()
		{
			return _userManager.Users.OrderBy(user => user.UserName).ToList();
			//sıralama işlemi, veritabanı seviyesinde yapılır ve ardından sıralanmış sonuçlar belleğe alınarak bir liste oluşturulur.
			//sıralama işlemini ToList metodundan sonra yapilirsa, tüm veriler belleğe alinir sonra sıralama yapılır, bu da performans kaybına neden olabilir.
		}
		public async Task<IdentityResult> CreateUserAsync(UserViewModelForInsertion userModel)
		{
			var user = _mapper.Map<IdentityUser>(userModel);
			var result = await _userManager.CreateAsync(user, userModel.Password!);
			if (result.Succeeded)
			{
				if (userModel.Roles.Count > 0)
				{
					var roleResult = await _userManager.AddToRolesAsync(user, userModel.Roles);
					if (!roleResult.Succeeded)
						return result;//throw new Exception("system have problems with roles");
				}
				return result;
			}
			return result;
		}



		public async Task<UserViewModelForUpdate> GetOneUserForUpdateAsync(string userName)
		{
			var user = await GetOneUserAsync(userName);
			var userViewModel = _mapper.Map<UserViewModelForUpdate>(user);
			userViewModel.Roles = GetAllRolesWithHashSetStringType(); //butun roller alindi
			userViewModel.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user)); //usera ait roller alindi

			return userViewModel;
		}

		public async Task UpdateUserAsync(UserViewModelForUpdate userModel)
		{
			var user = await GetOneUserAsync(userModel.UserName!);
			var userDto = _mapper.Map(userModel, user);
			var result = await _userManager.UpdateAsync(userDto);
			if (userModel.Roles.Count > 0)
			{
				var userRoles = await _userManager.GetRolesAsync(userDto);//updateden once userin ne kadar rolu varsa alalım
				var r1 = await _userManager.RemoveFromRolesAsync(userDto, userRoles);//burada da o rollerin hepsini kaldiralim
				var r2 = await _userManager.AddToRolesAsync(userDto, userModel.Roles); //rol tanimi, rol atamasi yapmadan mevcut rolleri kaldırıp oyle rol ekleme islemi yapiliyor
			}
			return;
		}

		public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel resetPasswordModel)
		{
			var user = await GetOneUserAsync(resetPasswordModel.UserName!);
			if (user is not null)
			{
				await _userManager.RemovePasswordAsync(user);
				var result = await _userManager.AddPasswordAsync(user, resetPasswordModel.Password!);

				//if (!result.Succeeded)
				//	throw new Exception("an error occured");

				return result;
			}
			throw new Exception("user could not be found");
		}

		public async Task<IdentityResult> DeleteUser(string userName)
		{
			var user = await GetOneUserAsync(userName);
			return await _userManager.DeleteAsync(user);
		}
		private async Task<IdentityUser> GetOneUserAsync(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				throw new Exception("User not found");
			return user;
		}
	}
}
