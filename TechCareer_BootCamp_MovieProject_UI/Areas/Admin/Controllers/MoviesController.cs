using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechCareer_BootCamp_MovieProject_Model.Enums;
using TechCareer_BootCamp_MovieProject_Model.RequestParameters;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.MovieModels;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin,Editor")]
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulundugunu belirtiriz
				   //ayrica ayni isimdeki controller cakismalarini da onler ve farklı route'u tanimlar (Admin/Movies/Index..)
	public class MoviesController : Controller
	{
		private readonly IServiceManager _manager;

		public MoviesController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index([FromQuery] MovieRequestParameters p)
		{
			var movies = _manager.MovieService.GetAllMoviesWithDetails(p);
			return View(movies);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var movieViewDetails = await _manager.MovieService.GetOneMovieForUpdate(id, false);

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
				_manager.MovieService.UpdateOneMovie(movieViewModel, genreIds);
				TempData["info"] = $"{movieViewModel.OriginalTitle} has been modified.";
				return RedirectToAction(nameof(Index));
			}

			ViewBag.Genres = _manager.GenreService.GetAllGenres(false);
			return View(movieViewModel);
		}
		public async Task<IActionResult> Create()
		{
			#region MultipleSelect 1. yontem for Actors
			//var actors = await _manager.MovieService.GetActorsByIdAndName(false);
			//var selectedActorIds = new List<int>();
			//ViewBag.Actors = new MultiSelectList(actors, "Id", "FullName", selectedActorIds);
			#endregion

			var viewModel = new MovieViewModelForInsertion //classtaki prop'u (List<Actor'u>) sayfaya model olarak gonderelim 
			{
				Actors = await _manager.ActorService.GetAllActors(false),
			};

			var directors = await _manager.DirectorService.GetAllDirectors(false);
			ViewData["DirectorId"] = new SelectList(directors, "Id", "FullName");

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] MovieViewModelForInsertion movieViewModel, IFormFile? file)
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
				_manager.MovieService.CreateOneMovie(movieViewModel);
				TempData["success"] = $"{movieViewModel.OriginalTitle} has been created.";
				return RedirectToAction(nameof(Index));
			}

			// Eğer ModelState geçerli değilse, director ve actor verilerini tekrar yükleyin
			movieViewModel.Actors = await _manager.ActorService.GetAllActors(false); // Actor verilerini tekrar yükleyin
			var directors = await _manager.DirectorService.GetAllDirectors(false);
			ViewData["DirectorId"] = new SelectList(directors, "Id", "FullName");
			return View(movieViewModel);
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
			TempData["danger"] = $"The product has been removed";
			return RedirectToAction(nameof(Index));
		}
	}
}
