using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class DirectorsController : Controller
	{
		private readonly IServiceManager _manager;
		public DirectorsController(IServiceManager manager)
		{
			_manager = manager;
		}
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var director = _manager.DirectorService.GetOneDirector(id, false);
			if (director == null)
			{
				return NotFound();
			}
			return View(director);
		}
	}
}
