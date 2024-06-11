using TechCareer_BootCamp_MovieProject_Model.Entities;
using TechCareer_BootCamp_MovieProject_Services.Mapper;
using TechCareer_BootCamp_MovieProject_UI.ExtensionMethods;
using TechCareer_BootCamp_MovieProject_UI.Models;

namespace TechCareer_BootCamp_MovieProject_UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

			builder.Services.AddRazorPages();

			builder.Services.ConfigureSqlServer(builder.Configuration);
			builder.Services.ConfigureRepositoryInjections();
			builder.Services.ConfigureServiceInjections();
			builder.Services.ConfigureIdentityDbContext();
			builder.Services.ConfigureApplicationCookie();
			builder.Services.ConfigureRouting();

			builder.Services.AddScoped<FavoriteMoviesList>(fm => SessionFavMovie.GetFavMovie(fm));
			//urettigin class sessiondan gelecek? GetFavMovie()metodu icinde islettigim logic dahilinde bana FavoriteMoviesList.cs ver?
			//bana verecegin FavoriteMoviesList.cs'i SessionFavMovie.cs'teki GetFavMovie() metodunun urettigi FavoriteMoviesList.cs'i ver.
			//request basina newleme yapiliyor ve onceki nesne kayboluyor. onlemek icin;
			//FavoriteMoviesList.cshtml.cs OnGet() metodunda ilgili yapiyi kurduk.
			//bu alttaki ileride extension metot icine yazilabilir
			builder.Services.AddDistributedMemoryCache();//onbellek ekler, session icin user bilgilerini ram'de saklamak ve paylasmak icin tercih edilebilir
														 //builder.Services.AddSession();//Oturum yönetimi, kullanicilarin app icindeki etkilesimleri sirasinda, belirli bilgileri tutma ve paylasma mekanizmasi.
			builder.Services.AddSession(options =>
			{
				options.Cookie.Name = "StoreApp.Session";
				options.IdleTimeout = TimeSpan.FromMinutes(10);//userdan 10 dk icerisinden fresh bir request gelmezse oturumu sonlandir.
			});
			//builder.Services.AddHttpContextAccessor();
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			#region HttpContextAccessor
			/*
			 * HttpContext nesnesine erisim saglar, bu nesne bir http requestin icerisinde barindirabilecegi cesitli bilgileri ve durumu temsil eder; 
			 * userin browserdan gonderdigi veriler, oturum bilgileri, url talebi vs
			 * HttpContextAccessor bu httpcontext nesnesine erisim saglar
			 */
			#endregion

			builder.Services.AddAutoMapper(typeof(MappingProfile));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseSession(); //sessionu aktif hale getirdik

			app.UseRouting();

			app.UseAuthentication(); //UseAuthentication() önce UseAuthorization() sonra yazılır
			app.UseAuthorization(); //bu iki middleware Routing() ile EndPoints() arasýnda olmali

			app.MapAreaControllerRoute(
				name: "Admin",
				areaName: "Admin",
				pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
			);
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"
			);

			app.MapRazorPages(); //routing mekanizmasýnda bir problem yasamamamak icin ve endpointlerin uyusmasi icin bu satiri yazdýk.

			app.ConfigureDefaultAdminUser();

			app.Run();
		}
	}
}