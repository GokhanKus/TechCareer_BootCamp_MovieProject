using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class ActorsController : Controller
	{
		private readonly IServiceManager _manager;
		public ActorsController(IServiceManager manager)
		{
			_manager = manager;
		}
		public async Task<IActionResult> Details(int id)
		{
			var actor = await _manager.ActorService.GetOneActorWithMovies(id, false);
			if (actor == null)
			{
				return NotFound();
			}
			return View(actor);
		}
	}
}
