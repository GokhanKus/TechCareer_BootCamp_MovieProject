using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin,Editor")]
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
/*
user eger login olmadan admin panele erismek isterse login sayfasınıa yonlendirilir
login olmus ama yetkisi yoksa(authorization(admin editor rollerinde degilse vs..)) account/accessdenied sayfasına yonlendirilir
 */