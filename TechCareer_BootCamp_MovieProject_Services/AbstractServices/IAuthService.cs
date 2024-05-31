using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Services.AbstractServices
{
	public interface IAuthService
	{
		//TODO: Rollerle ilgili temel crud islemlerini yap.
		IEnumerable<IdentityRole> GetAllRoles();
		IEnumerable<IdentityUser> GetAllUsers();
	}
}
