using Microsoft.AspNetCore.Mvc;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DirectorsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
