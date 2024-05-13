using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.ActorModels;
using TechCareer_BootCamp_MovieProject_Repositories.Context;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class ActorsController : Controller
	{
		private readonly IServiceManager _manager;

		public ActorsController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var actors = _manager.ActorService.GetAllActors(false);
			return View(actors);
		}

		public IActionResult Details(int id)
		{
			var actor = _manager.ActorService.GetOneActorWithMovies(id, false);
			if (actor == null)
			{
				return NotFound();
			}
			return View(actor);
		}

		public IActionResult Create()
		{
			return View();
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
