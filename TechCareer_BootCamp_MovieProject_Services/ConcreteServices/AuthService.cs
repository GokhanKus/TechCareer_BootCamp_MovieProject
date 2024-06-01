using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
		public IEnumerable<IdentityUser> GetAllUsers()
		{
			return _userManager.Users.ToList();
		}
		public async Task<IdentityResult> CreateUserAsync(UserViewModelForInsertion userModel)
		{
			var user = _mapper.Map<IdentityUser>(userModel);
			var result = await _userManager.CreateAsync(user, userModel.Password);
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
	}
}
