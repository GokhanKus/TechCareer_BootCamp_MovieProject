using Microsoft.AspNetCore.Mvc;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashBoardController : Controller
	{
		public IActionResult Index()
		{
			TempData["info"] = $"Welcome back, {DateTime.Now.ToShortTimeString()}";
			return View();
		}
	}
}
