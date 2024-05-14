﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Repositories.Context;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class FictionalCharactersController : Controller
	{
		private readonly IServiceManager _manager;
		public FictionalCharactersController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var fictCharsWithActors = _manager.FictionalCharacter.GetAllFictionalCharsWithActors(false);
			return View(fictCharsWithActors);
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var fictionalCharacter = _manager.FictionalCharacter.GetOneFictionalCharWithActor(id);

			if (fictionalCharacter == null)
			{
				return NotFound();
			}

			return View(fictionalCharacter);
		}
		public IActionResult Create()
		{
			var actors = _manager.ActorService.GetAllActors(false);
			ViewData["ActorId"] = new SelectList(actors, "Id", "FullName");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("CharacterName,ActorId,Id,CreatedTime")] FictionalCharacter fictionalCharacter)
		{
			if (ModelState.IsValid)
			{
				_manager.FictionalCharacter.CreateOneFictionalCharacter(fictionalCharacter);
				return RedirectToAction(nameof(Index));
			}
			var actors = _manager.ActorService.GetAllActors(false);
			ViewData["ActorId"] = new SelectList(actors, "Id", "FullName", fictionalCharacter.ActorId);
			return View(fictionalCharacter);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var fictionalCharacter = _manager.FictionalCharacter.GetOneFictionalCharWithActor(id);
			if (fictionalCharacter == null)
			{
				return NotFound();
			}
			var actors = _manager.ActorService.GetAllActors(false);

			ViewData["ActorId"] = new SelectList(actors, "Id", "FullName", fictionalCharacter.ActorId);
			return View(fictionalCharacter);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("CharacterName,ActorId,Id,CreatedTime")] FictionalCharacter fictionalCharacter)
		{
			if (id != fictionalCharacter.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_manager.FictionalCharacter.UpdateOneFictionalCharacter(fictionalCharacter);
				return RedirectToAction(nameof(Index));
			}
			var actors = _manager.ActorService.GetAllActors(false);
			ViewData["ActorId"] = new SelectList(actors, "Id", "FullName", fictionalCharacter.ActorId);
			return View(fictionalCharacter);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var fictionalCharacter = _manager.FictionalCharacter.GetOneFictionalCharWithActor(id);

			if (fictionalCharacter == null)
			{
				return NotFound();
			}

			return View(fictionalCharacter);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var fictionalCharacter = _manager.FictionalCharacter.GetOneFictionalCharWithActor(id);
			if (fictionalCharacter != null)
			{
				_manager.FictionalCharacter.DeleteOneFictionalCharacter(id);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
