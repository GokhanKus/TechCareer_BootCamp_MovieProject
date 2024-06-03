using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Model.ViewModels.IdentityModels;

namespace TechCareer_BootCamp_MovieProject_UI.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
		{
			return View(new LoginViewModel
			{
				ReturnUrl = ReturnUrl,
			});
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromForm]LoginViewModel loginViewModel)
		{
			//bu metot cok kalabaliklasti service katmanında yazilabilir
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
				if (user is not null)
				{
					await _signInManager.SignOutAsync();
					//user'in bilgileri hatirlansin ve belli sayida fail yaparsa kilitlensin
					var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, true);
					if (signInResult.Succeeded)
					{
						await _userManager.ResetAccessFailedCountAsync(user);
						await _userManager.SetLockoutEndDateAsync(user, null);
						return Redirect(loginViewModel.ReturnUrl); // bizi "/"'ye yonlendirsin (homepage)
					}
					else if (signInResult.IsLockedOut)
					{
						var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
						var timeLeft = lockoutDate.Value - DateTime.UtcNow;
						ModelState.AddModelError("", $"Your account has been locked out, please try again {timeLeft.Minutes + 1} minute later.");
					}
					else
					{
						ModelState.AddModelError("Error", "Invalid username or password");
					}
				}
				else
				{
					ModelState.AddModelError("Error", "Invalid username or password");
				}
			}
			return View();
		}
		public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
		{
			await _signInManager.SignOutAsync();
			return Redirect(ReturnUrl);
		}

		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([FromForm] RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser
				{
					UserName = registerViewModel.UserName,
					Email = registerViewModel.Email
				};

				var result = await _userManager.CreateAsync(user, registerViewModel.Password);

				if (result.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(user, "User");
					if (roleResult.Succeeded)
						return RedirectToAction("Login");
				}
				else
				{
					foreach (IdentityError err in result.Errors) //ilgili hata mesajlarını yazdıralım eğer valid değilse
					{
						ModelState.AddModelError("", err.Description);
					}
				}
			}
			return View();
		}
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
