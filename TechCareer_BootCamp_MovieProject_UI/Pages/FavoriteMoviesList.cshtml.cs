using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;
using TechCareer_BootCamp_MovieProject_UI.ExtensionMethods;

namespace TechCareer_BootCamp_MovieProject_UI.Pages
{
	public class FavoriteMoviesListModel : PageModel
	{
		private readonly IServiceManager _manager;
		public FavoriteMoviesList FavoriteMoviesList { get; set; }
        public FavoriteMoviesListModel(IServiceManager manager, FavoriteMoviesList favMovieListService)//kod tekrarindan kurtulduk (sessionFavMovie in UI/Models)
		{
			_manager = manager;
			FavoriteMoviesList = favMovieListService;
		}
		public string ReturnUrl { get; set; } = "/";
		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl ?? "/"; //parametre olarak gelen url bos ise bizi "/" dizinine (kök) gotursun
			//FavoriteMoviesList = HttpContext.Session.GetJson<FavoriteMoviesList>("FavoriteMoviesList") ?? new FavoriteMoviesList(); bu satira gerek kalmadi
			//inject islemi olarak bu sekilde yapiyoruz artik scoped tanimlamamiza ragmen(IoC) veriler kaybolmayacak.
			//cunku sessiondan nesne alýp okuyup tekrar sessiona ilgili veriyi gonderecek sekilde bir yapý kurduk.
		}
		public IActionResult OnPost(int id, string returnUrl) //anasayfada favorite butonuna basinca buraya girer
		{
			Movie? movie = _manager.MovieService.GetOneMovie(id, false);//update yapmadigimiz icin trackchanges false olabilir.
			if (movie is not null)
			{
				//FavoriteMoviesList.AddItem(movie);
				//FavoriteMoviesList nesnesini sessiondan okuyoruz eger yoksa olusturuyoruz ve GetJson() nesneyi deserialize etti ve bize bir class verdi
				//FavoriteMoviesList = HttpContext.Session.GetJson<FavoriteMoviesList>("FavoriteMoviesList") ?? new FavoriteMoviesList(); bu satira gerek kalmadi
				FavoriteMoviesList.AddItem(movie); //ve o class uzerinden yeni nesneyi ekliyoruz. ve artik FavoriteMoviesList nesnemiz degisti. sessionda farklý classta farklý bilgiler var
				//HttpContext.Session.SetJson<FavoriteMoviesList>("FavoriteMoviesList", FavoriteMoviesList);
				//veriyi session'a yazmýs oluyoruz. boylelikle yeni item eklerken onceki kaybolmayacak
				//HttpContext.Session.SetJson("FavoriteMoviesList", FavoriteMoviesList);
			}
			return Page();
		}
		public IActionResult OnPostRemove(int id, string returnUrl)
		{
			//FavoriteMoviesList = HttpContext.Session.GetJson<FavoriteMoviesList>("FavoriteMoviesList") ?? new FavoriteMoviesList();
			//Movie? movie = FavoriteMoviesList.FavoriteMovies.First(i => i.Movie.Id.Equals(id)).Movie;
			//FavoriteMoviesList.RemoveItem(movie);
			//return Page(); //islem bitince sayfayi yenileyelim

			//metot iyilestirmesi
			//FavoriteMoviesList = HttpContext.Session.GetJson<FavoriteMoviesList>("FavoriteMoviesList") ?? new FavoriteMoviesList();
			Movie? movie = FavoriteMoviesList.FavoriteMovies
				.FirstOrDefault(i => i.Movie.Id.Equals(id))?.Movie;
			if (movie != null)
			{
				FavoriteMoviesList.RemoveItem(movie);
			}
			//HttpContext.Session.SetJson<FavoriteMoviesList>("FavoriteMoviesList", FavoriteMoviesList);
			return RedirectToPage(returnUrl ?? "/");
		}
	}
}
