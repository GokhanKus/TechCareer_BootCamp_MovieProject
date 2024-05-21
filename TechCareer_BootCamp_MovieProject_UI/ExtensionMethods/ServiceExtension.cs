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
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				//cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. hatasi ustteki no tracking ile duzeldi?
			});
			//migration Assembly yazmamızın sebebi: migration klasorunu UI'da olusturamıyorduk Repositories de olusturabiliyorduk.. artik UI'da Migration Klasoru olusuyor
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
		}
	}
}
