using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
	public class UserCount : ViewComponent
	{
		private readonly IServiceManager _manager;

		public UserCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.AuthService.GetAllUsers().Count().ToString();
		}
	}
}
