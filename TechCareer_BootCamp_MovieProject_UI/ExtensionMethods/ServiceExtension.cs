using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechCareer_BootCamp_MovieProject_Repositories.AbstractRepos;
using TechCareer_BootCamp_MovieProject_Repositories.ConcreteRepos;
using TechCareer_BootCamp_MovieProject_Repositories.Context;
using TechCareer_BootCamp_MovieProject_Services.AbstractServices;
using TechCareer_BootCamp_MovieProject_Services.ConcreteServices;

namespace TechCareer_BootCamp_MovieProject_UI.ExtensionMethods
{
	public static class ServiceExtension
	{
		public static void ConfigureSqlServer(this IServiceCollection service, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("sqlConnectionString");
			service.AddDbContext<MovieDbContext>(options =>
			{
				options.UseSqlServer(connectionString, migr => migr.MigrationsAssembly(nameof(TechCareer_BootCamp_MovieProject_UI)));
				options.EnableSensitiveDataLogging(true);
				//app gelistirme asamasinda username password gibi hassas bilgileri loglara yansitmaya ihtiyac duyabiliriz. simdilik true yapalim
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				//cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. hatasi ustteki no tracking ile duzeldi?
			});
			//migration Assembly yazmamızın sebebi: migration klasorunu UI'da olusturamıyorduk Repositories de olusturabiliyorduk.. artik UI'da Migration Klasoru olusuyor
		}
		public static void ConfigureIdentityDbContext(this IServiceCollection service)
		{
			service.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false; //ileride maile acvitation kodu gonderilirse burayı true yapariz smtp mail server
				options.User.RequireUniqueEmail = true; //mailler unique olsun her userin maili kendine ait olsun vs.
				options.Password.RequireUppercase = true;   //buyuk harf zorunlu
				options.Password.RequireLowercase = true;   //kucuk	  "		"
				options.Password.RequireNonAlphanumeric = false;//. , & % + gibi karakterler zorunlu degil
				options.Password.RequireDigit = true;

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
				options.Lockout.MaxFailedAccessAttempts = 5;   //eger user giris icin 5 kere hatali girisimde bulunursa hesabi 2 dk boyunca kitlensin.
				options.Password.RequiredLength = 8;        //min 8 karakter zorunlu
			})
				.AddEntityFrameworkStores<MovieDbContext>();// Identity veritabanı işlemleri için MovieDbContext kullanılır
		}
		public static void ConfigureRepositoryInjections(this IServiceCollection service)
		{
			service.AddScoped<IRepositoryManager, RepositoryManager>();
			service.AddScoped<IActorRepository, ActorRepository>();
			service.AddScoped<IDirectorRepository, DirectorRepository>();
			service.AddScoped<IFictionalCharacterRepository, FictionalCharacterRepository>();
			service.AddScoped<IGenreRepository, GenreRepository>();
			service.AddScoped<IMovieRepository, MovieRepository>();
		}
		public static void ConfigureServiceInjections(this IServiceCollection service)
		{
			service.AddScoped<IServiceManager, ServiceManager>();
			service.AddScoped<IActorService, ActorService>();
			service.AddScoped<IDirectorService, DirectorService>();
			service.AddScoped<IFictionalCharacterService, FictionalCharacterService>();
			service.AddScoped<IGenreService, GenreService>();
			service.AddScoped<IMovieService, MovieService>();
			service.AddScoped<IAuthService, AuthService>();
		}
		public static void ConfigureApplicationCookie(this IServiceCollection service)
		{
			service.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = new PathString("/Account/Login");
				options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
				options.ExpireTimeSpan = TimeSpan.FromDays(10);//remember me ozelligi sadece 10 gunlugune aktif; default 14gundur yani oturum 10 gun sonra otomatik olarak sonlanacak
				options.AccessDeniedPath = new PathString("/Account/AccessDenied");
			});
		}
	}
}
