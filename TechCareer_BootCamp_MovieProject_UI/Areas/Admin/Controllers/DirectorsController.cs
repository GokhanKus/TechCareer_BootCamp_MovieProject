using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.DirectorModels;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DirectorsController : Controller
	{
		private readonly IServiceManager _manager;
		public DirectorsController(IServiceManager manager)
		{
			_manager = manager;
		}
		public async Task<IActionResult> Index()
		{
			var directors = await _manager.DirectorService.GetAllDirectors(false);
			return View(directors);
		}
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var director = _manager.DirectorService.GetOneDirector(id, false);
			if (director == null)
			{
				return NotFound();
			}
			return View(director);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DirectorViewModelForInsertion director, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MovieActors", file.FileName);
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
					director.ImagePath = file.FileName;
				}
				else
				{
					director.ImagePath = "DefaultActor.jpg";
				}
				_manager.DirectorService.CreateOneDirector(director);
				return RedirectToAction(nameof(Index));
			}
			return View(director);
		}
		public IActionResult Edit(int id)
		{
			var director = _manager.DirectorService.GetOneDirectorForUpdate(id, false);
			if (director == null)
			{
				return NotFound();
			}
			return View(director);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(DirectorViewModelForUpdate directorViewModel, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MovieActors", file.FileName);
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
					directorViewModel.ImagePath = file.FileName;
				}
				_manager.DirectorService.UpdateOneDirector(directorViewModel);

				return RedirectToAction(nameof(Index));
			}
			return View(directorViewModel);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var director = _manager.DirectorService.GetOneDirector(id, false);
			if (director == null)
			{
				return NotFound();
			}
			return View(director);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var director = _manager.DirectorService.GetOneDirector(id, false);
			if (director != null)
			{
				_manager.DirectorService.DeleteOneDiretor(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
