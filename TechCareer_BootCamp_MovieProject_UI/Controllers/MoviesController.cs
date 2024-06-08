using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Model.RequestParameters;
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
		public IActionResult Index(MovieRequestParameters p)
		{
			var movies = _manager.MovieService.GetAllMoviesWithDetails(p);
			return View(movies);
		}
		public async Task<IActionResult> Details(int id)
		{
			var movieWithDetails = await _manager.MovieService.GetOneMovieWithDetails(id, false);
			return View(movieWithDetails);
		}
	}
}
