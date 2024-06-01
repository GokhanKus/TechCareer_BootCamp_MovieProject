using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UsersController : Controller
	{
		private readonly IServiceManager _manager;

		public UsersController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var users = _manager.AuthService.GetAllUsers();
			return View(users);
		}
		public IActionResult Create()
		{
			var userModel = new UserViewModelForInsertion
			{
				Roles = _manager.AuthService.GetAllRolesWithHashSetStringType()
			};
			return View(userModel);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create([FromForm] UserViewModelForInsertion userModel)
		{
			//TODO: AuthService'de throw new Exception yerine daha farklı yaklasim izlenebilir hata yonetimi icin (asagidaki modelstate errorlara girmeden hata alıyoruzt)
			userModel.Roles = _manager.AuthService.GetAllRolesWithHashSetStringType();
				var result = await _manager.AuthService.CreateUserAsync(userModel);
				if (!result.Succeeded)
				{
					foreach (IdentityError err in result.Errors)
					{
						ModelState.AddModelError("", err.Description);
					}
					return View(userModel);
				}
				return RedirectToAction("Index");
			
			//userModel.Roles = _manager.AuthService.GetAllRolesWithHashSetStringType();
			//if (ModelState.IsValid)
			//{
			//	var result = await _manager.AuthService.CreateUserAsync(userModel);

			//	if (!result.Succeeded)
			//	{
			//		foreach (IdentityError err in result.Errors)
			//		{
			//			ModelState.AddModelError("", err.Description);
			//		}
			//		return View(userModel);
			//	}
			//	return RedirectToAction("Index");
			//}
			//else
			//{
			//	return View(userModel);
			//}
		}

		public async Task<IActionResult> Update(string username)//[FromRoute(Name = "username")] bunu yazınca hata veriyor ya da bunu yazarsak: [FromRoute(Name = "id")] string id seklinde yazmalıyız 
		{
			var user = await _manager.AuthService.GetOneUserForUpdate(username);
			return View(user);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm] UserViewModelForUpdate userModel)
		{
			if (ModelState.IsValid)
			{
				await _manager.AuthService.UpdateUserAsync(userModel);
				return RedirectToAction("Index");
			}
			//eger valid degilse girilen hatali bilgileri kaybolmasin sayfada tutalim
			return View(userModel);
		}
	}
}