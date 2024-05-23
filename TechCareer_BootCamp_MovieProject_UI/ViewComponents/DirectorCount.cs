using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
	public class DirectorCount : ViewComponent
	{
		private readonly IServiceManager _manager;
		public DirectorCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public async Task<string> InvokeAsync()
		{
			var director = await _manager.DirectorService.GetAllDirectors(false);
			var directorCounts = director.Count();
			return directorCounts.ToString();
		}
	}
}
