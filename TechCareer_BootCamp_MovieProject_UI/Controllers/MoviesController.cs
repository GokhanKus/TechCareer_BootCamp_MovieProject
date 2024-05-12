using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IMovieService _movieService;
		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}
		public IActionResult Index()
		{
			var movies = _movieService.GetAllMoviesWithGenres();
			return View(movies);
		}
		public async Task<IActionResult> Details(int id)
		{
			return View();
		}
		public IActionResult Create()
		{
			var actors = _movieService.GetActorsByIdAndName(false).ToList(); 
			
			var selectedActorIds = new List<int>(); // Örnek olarak boş liste verdik
													//var movie = new MovieViewModel();
													//movie.ActorsByIdAndNames = _movieService.GetActorsByIdAndName(false).ToList();
			ViewBag.Actors = new MultiSelectList(actors, "Id", "FullName", selectedActorIds);
			//var actorIds = movie.ActorIds;
			////var actorsSelectList = GetActorsByIdAndName(movie.ActorsByIdAndNames, actorIds);
			//var actorsSelectList = new SelectList(movie.ActorsByIdAndNames, "Id", "FullName", actorIds);
			//ViewBag.Actors = actorsSelectList;
			//return View(movie);
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] MovieViewModel movieViewModel/*IFormFile*/)
		{
			return View();
		}
	}
}
