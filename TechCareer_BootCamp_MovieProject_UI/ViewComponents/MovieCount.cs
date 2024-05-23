using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
	public class MovieCount:ViewComponent
	{
		private readonly IServiceManager _manager;
		public MovieCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.MovieService.GetAllMovies(false).Count().ToString();
		}
	}
}
