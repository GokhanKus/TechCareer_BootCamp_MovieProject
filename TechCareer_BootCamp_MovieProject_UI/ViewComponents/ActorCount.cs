using Microsoft.AspNetCore.Mvc;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
	public class ActorCount : ViewComponent
	{
		private readonly IServiceManager _manager;
		public ActorCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public async Task<string> InvokeAsync()
		{
			var actors = await _manager.ActorService.GetAllActors(false);
			var actorCounts = actors.Count();
			return actorCounts.ToString();
		}
	}
}
