using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.ViewComponents
{
    public class GenreMenu : ViewComponent
    {
        private readonly IServiceManager _manager;

        public GenreMenu(IServiceManager manager)
        {
            _manager = manager;
        }
        //geriye bir view nesnesi dönmesini istedigim icin IViewComponentResult kullandim, illa geriye view donmek zorunda degil string bile donebilir
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _manager.GenreService.GetAllGenres(false);
            return View(genres);
        }
    }
}
