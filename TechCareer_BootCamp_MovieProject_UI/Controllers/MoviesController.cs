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
		public async Task<IActionResult> MovieList()
		{
			var movies = await _manager.MovieService.GetAllMoviesWithGenres();
			return View(movies);
		}
		public async Task<IActionResult> Details(int id)
		{
			var movieWithDetails = await _manager.MovieService.GetOneMovieWithDetails(id, false);
			return View(movieWithDetails);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var movieViewDetails = await _manager.MovieService.GetOneMovieWithDetails(id, false);

			movieViewDetails.SelectedActorIds = movieViewDetails.Actors.Select(a => a.Id).ToList();

			ViewBag.Languages = new SelectList(Enum.GetValues(typeof(Language)).Cast<Language>());

			ViewBag.Genres = _manager.GenreService.GetAllGenres(false);

			var directors = await _manager.DirectorService.GetAllDirectors(false);
			ViewData["DirectorId"] = new SelectList(directors, "Id", "FullName");

			return View(movieViewDetails);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([FromForm] MovieViewModelForUpdate movieViewModel, int[] genreIds, IFormFile? file)
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
				//else
				//{
				//	movieViewModel.PosterPath = "DefaultMovie.jpg";
				//}
				_manager.MovieService.UpdateOneMovie(movieViewModel, genreIds);
				return RedirectToAction(nameof(MovieList));
			}
			return View(movieViewModel);
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
		public async Task<IActionResult> Create()
		{
			#region MultipleSelect 1. yontem for Actors
			//var actors = await _manager.MovieService.GetActorsByIdAndName(false);
			//var selectedActorIds = new List<int>();
			//ViewBag.Actors = new MultiSelectList(actors, "Id", "FullName", selectedActorIds);
			#endregion

			ViewBag.Genres = _manager.GenreService.GetAllGenres(false); //viewbag ile film turleri liste olarak sayfaya tasiyacagim
			var viewModel = new MovieViewModelForInsertion //classtaki prop'u (List<Actor'u>) sayfaya model olarak gonderelim 
			{
				Actors = await _manager.ActorService.GetAllActors(false)
			};

			var directors = await _manager.DirectorService.GetAllDirectors(false);
			ViewData["DirectorId"] = new SelectList(directors, "Id", "FullName");

			return View(viewModel);
		}

		public IActionResult Delete(int id)
		{
			var movie = _manager.MovieService.GetOneMovie(id, false);
			if (movie == null)
			{
				return NotFound();
			}
			return View(movie);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var movie = _manager.MovieService.GetOneMovie(id, false);
			if (movie != null)
			{
				_manager.MovieService.DeleteOneMovie(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
