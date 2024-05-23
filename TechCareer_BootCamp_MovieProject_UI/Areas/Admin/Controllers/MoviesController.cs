using Microsoft.AspNetCore.Mvc;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulundugunu belirtiriz
				   //ayrica ayni isimdeki controller cakismalarini da onler ve farklı route'u tanimlar (Admin/Movies/Index..)
	public class MoviesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
