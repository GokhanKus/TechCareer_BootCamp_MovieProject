using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;

namespace TechCareer_BootCamp_MovieProject_UI.Pages
{
	public class FavoriteMoviesListModel : PageModel
	{
		private readonly IServiceManager _manager;

		public FavoriteMoviesListModel(IServiceManager manager)
		{
			_manager = manager;
		}
		public FavoriteMoviesList FavoriteMoviesList { get; set; } = new();
		public string ReturnUrl { get; set; } = "/";

		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl ?? "/"; //parametre olarak gelen url bos ise bizi "/" dizinine (kök) gotursun
		}
		public IActionResult OnPost(int id, string returnUrl) //anasayfada favorite butonuna basinca buraya girer
		{
			Movie? movie = _manager.MovieService.GetOneMovie(id, false);//update yapmadigimiz icin trackchanges false olabilir.
			if (movie is not null)
			{
				FavoriteMoviesList.AddItem(movie);
			}
			return Page();
		}
		public IActionResult OnPostRemove(int id, string returnUrl)
		{
			//Movie? movie = FavoriteMoviesList.FavoriteMovies.First(i => i.Movie.Id.Equals(id)).Movie;
			//FavoriteMoviesList.RemoveItem(movie);
			//return Page(); //islem bitince sayfayi yenileyelim

			//metot iyilestirmesi
			Movie? movie = FavoriteMoviesList.FavoriteMovies
				.FirstOrDefault(i => i.Movie.Id.Equals(id))?.Movie;
			if (movie != null)
			{
				FavoriteMoviesList.RemoveItem(movie);
			}
			return RedirectToPage(returnUrl ?? "/");
		}
	}
}
