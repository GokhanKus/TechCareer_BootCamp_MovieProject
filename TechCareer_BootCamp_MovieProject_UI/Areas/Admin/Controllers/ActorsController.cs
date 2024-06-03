using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	//sadece [Authorize] yazarsak login olmus any user girebilir demek
	[Authorize(Roles = "Admin,Editor")] // Varsayılan olarak Admin ve Editor rollerine yetki verildi (action bazında da authorize islemi yapilabilir)
	[Area("Admin")]
	public class ActorsController : Controller
	{
		private readonly IServiceManager _manager;
		public ActorsController(IServiceManager manager)
		{
			_manager = manager;
		}
		public IActionResult Create()
		{
			return View();
		}
		//[AllowAnonymous]//giris yapmis veya yapmamis any user erisebilir bu actiona
		public async Task<IActionResult> Index()
		{
			var actors = await _manager.ActorService.GetAllActors(false);
			return View(actors);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ActorViewModelForInsertion actorViewModel, IFormFile? file)
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
					actorViewModel.ImagePath = file.FileName;
				}
				else
				{
					actorViewModel.ImagePath = "DefaultActor.jpg";
				}
				_manager.ActorService.CreateOneActor(actorViewModel);
				return RedirectToAction(nameof(Index));
			}
			return View(actorViewModel);
		}
		public IActionResult Edit(int id)
		{
			var actor = _manager.ActorService.GetOneActorForUpdate(id, false);
			if (actor == null)
			{
				return NotFound();
			}
			return View(actor);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ActorViewModelForUpdate actorViewModel, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				if (file is not null)
				{
					string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MovieActors", file.FileName);
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
					actorViewModel.ImagePath = file.FileName;
				}
				_manager.ActorService.UpdateOneActor(actorViewModel);
				return RedirectToAction(nameof(Index));
			}
			return View(actorViewModel);
		}
		public IActionResult Delete(int id)
		{
			var actor = _manager.ActorService.GetOneActor(id, false);
			if (actor == null)
			{
				return NotFound();
			}

			return View(actor);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var actor = _manager.ActorService.GetOneActor(id, false);
			if (actor != null)
			{
				_manager.ActorService.DeleteOneActor(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
