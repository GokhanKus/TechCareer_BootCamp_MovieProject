using Microsoft.AspNetCore.Mvc;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulundugunu belirtiriz
				   //Aynı controller isminden oldugu icin Area attribute'sini eklemek zorundayız.
	public class GenresController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
