using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Pages
{
	public class RolesModel : PageModel
	{
		private readonly IServiceManager _manager;

		public RolesModel(IServiceManager manager)
		{
			_manager = manager;
		}
		public IEnumerable<IdentityRole> Roles { get; set; }
		public void OnGet()
		{
			Roles = _manager.AuthService.GetAllRoles();
		}
	}
}
