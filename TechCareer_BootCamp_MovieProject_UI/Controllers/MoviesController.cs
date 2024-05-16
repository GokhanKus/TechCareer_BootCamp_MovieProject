using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
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
		private readonly IServiceManager _manager;

		public MoviesController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var movies = _manager.MovieService.GetAllMoviesWithGenres();
			return View(movies);
		}
		public async Task<IActionResult> Details(int id)
		{
			return View();
		}
		public async Task<IActionResult> Create()
		{
			//var actors = await _manager.MovieService.GetActorsByIdAndName(false);
			//var selectedActorIds = new List<int>();
			//ViewBag.Actors = new MultiSelectList(actors, "Id", "FullName", selectedActorIds);


			ViewBag.Genres = _manager.GenreService.GetAllGenres(false).ToList(); //viewbag ile film turleri liste olarak sayfaya tasiyacagim
			var viewModel = new MovieViewModelForInsertion //classtaki prop'u (List<Actor'u>) sayfaya model olarak gonderelim 
			{
				AvailableActors = await _manager.ActorService.GetAllActors(false)
			};

			var directors = await _manager.DirectorService.GetAllDirectors(false);
			ViewData["DirectorId"] = new SelectList(directors, "Id", "FullName");

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] MovieViewModelForInsertion movieViewModel, int[] genreIds, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				if (file is not null)
				{
					string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MoviePosters", file.FileName);
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
					movieViewModel.PosterPath = file.FileName;
				}
				else
				{
					movieViewModel.PosterPath = "DefaultMovie.jpg";
				}
				_manager.MovieService.CreateOneMovie(movieViewModel, genreIds);
				return RedirectToAction(nameof(Index));
			}

			return View(movieViewModel);
		}
	}
}
