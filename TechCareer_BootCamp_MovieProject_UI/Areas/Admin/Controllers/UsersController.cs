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
				Roles = GetRolesLikeHashSetStringType()
			};
			return View(userModel);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create([FromForm] UserViewModelForInsertion userModel)
		{
			//TODO: AuthService'de throw new Exception yerine daha farklı yaklasim izlenebilir hata yonetimi icin (asagidaki modelstate errorlara girmeden hata alıyoruzt)
			userModel.Roles = GetRolesLikeHashSetStringType();
			if (ModelState.IsValid)
			{
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
			}
			else
			{
				return View(userModel);
			}
		}
		private HashSet<string> GetRolesLikeHashSetStringType()
		{
			return _manager.AuthService.GetAllRoles().Select(r => r.Name!).ToList().ToHashSet();
		}
	}
}
