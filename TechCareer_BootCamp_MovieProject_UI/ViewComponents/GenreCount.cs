using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
	public class GenreCount:ViewComponent
	{
		private readonly IServiceManager _manager;
		public GenreCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.GenreService.GetAllGenres(false).Count().ToString();
		}
	}
}
