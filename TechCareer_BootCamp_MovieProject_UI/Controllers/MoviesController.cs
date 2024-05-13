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
		private readonly IGenreRepository _genreService;
		public MoviesController(IMovieService movieService, IGenreRepository genreService)
		{
			_movieService = movieService;
			_genreService = genreService;
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

			var selectedActorIds = new List<int>();
			ViewBag.Actors = new MultiSelectList(actors, "Id", "FullName", selectedActorIds);
			ViewBag.Genres = _genreService.GetAll(false).ToList();
			
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] MovieViewModel movieViewModel, int[] genreIds/*IFormFile*/)
		{
			var entityToCreate = new Movie
			{
				Id = movieViewModel.Id,
				OriginalTitle = movieViewModel.OriginalTitle,
				Plot = movieViewModel.Plot,
				Score = movieViewModel.Score,
				ReleaseDate = movieViewModel.ReleaseDate,
				
			};
			foreach (var actorId in movieViewModel.ActorIds)
			{
				var actorMovie = new ActorMovie
				{
					MovieId = entityToCreate.Id,
					ActorId = actorId
				};
			}
			foreach (var genreId in genreIds)
			{
				var genreMovie = new GenreMovie
				{
					MovieId = entityToCreate.Id,
					GenreId = genreId
				};
			}
			return View();
		}
	}
}
