using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechCareer_BootCamp_MovieProject_Model.Enums;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IServiceManager _manager;

		public MoviesController(IServiceManager manager)
		{
			_manager = manager;
		}

		public async Task<IActionResult> Index()
		{
			var movies = await _manager.MovieService.GetAllMoviesWithGenres();
			return View(movies);
		}
		public async Task<IActionResult> Details(int id)
		{
			var movieWithDetails = await _manager.MovieService.GetOneMovieWithDetails(id, false);
			return View(movieWithDetails);
		}
	}
}
