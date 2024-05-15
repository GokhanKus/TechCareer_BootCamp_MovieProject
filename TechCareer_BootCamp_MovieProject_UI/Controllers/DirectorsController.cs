using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.DirectorModels;
using TechCareer_BootCamp_MovieProject_Repositories.Context;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class DirectorsController : Controller
	{
		//private readonly MovieDbContext _context;
		private readonly IServiceManager _manager;
		public DirectorsController(IServiceManager manager)
		{
			_manager = manager;
		}

		// GET: Directors
		public async Task<IActionResult> Index()
		{
			var directors = await _manager.DirectorService.GetAllDirectors(false);
			return View(directors);
		}

		// GET: Directors/Details/5
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
