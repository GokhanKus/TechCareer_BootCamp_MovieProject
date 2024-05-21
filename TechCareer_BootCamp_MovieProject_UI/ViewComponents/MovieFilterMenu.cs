using Microsoft.AspNetCore.Mvc;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
    public class MovieFilterMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
