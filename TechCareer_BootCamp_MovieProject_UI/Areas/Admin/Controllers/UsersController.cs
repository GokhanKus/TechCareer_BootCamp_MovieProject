using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UsersController : Controller
	{
		private readonly IServiceManager _manager;

		public UsersController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var users = _manager.AuthService.GetAllUsers();
			return View(users);
		}
	}
}
