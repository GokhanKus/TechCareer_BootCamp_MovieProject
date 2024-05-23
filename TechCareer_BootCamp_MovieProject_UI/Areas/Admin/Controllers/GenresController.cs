using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulundugunu belirtiriz
				   //Aynı controller isminden oldugu icin Area attribute'sini eklemek zorundayız.
	public class GenresController : Controller
	{
		//private readonly MovieDbContext _context;
		private readonly IServiceManager _manager;
		public GenresController(/*MovieDbContext context, */IServiceManager manager)
		{
			//_context = context;
			_manager = manager;
		}
		public IActionResult Index()
		{
			var genres = _manager.GenreService.GetAllGenres(false);
			return View(genres);
		}
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var genre = _manager.GenreService.GetOneGenre(id, false);
			if (genre == null)
			{
				return NotFound();
			}
			return View(genre);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Genre genre)
		{
			if (ModelState.IsValid)
			{
				_manager.GenreService.CreateOneGenre(genre);
				return RedirectToAction(nameof(Index));
			}
			return View(genre);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var genre = _manager.GenreService.GetOneGenre(id, false);
			if (genre == null)
			{
				return NotFound();
			}
			return View(genre);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("Name,Id,CreatedTime")] Genre genre)
		{
			if (id != genre.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_manager.GenreService.UpdateOneGenre(genre);
				return RedirectToAction(nameof(Index));
			}
			return View(genre);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var genre = _manager.GenreService.GetOneGenre(id, false);
			if (genre == null)
			{
				return NotFound();
			}

			return View(genre);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var genre = _manager.GenreService.GetOneGenre(id, false);
			if (genre != null)
			{
				_manager.GenreService.DeleteOneGenre(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
