using TechCareer_BootCamp_MovieProject_Services.Mapper;
using TechCareer_BootCamp_MovieProject_UI.ExtensionMethods;

namespace TechCareer_BootCamp_MovieProject_UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

			builder.Services.ConfigureSqlServer(builder.Configuration);
			builder.Services.ConfigureRepositoryInjections();
			builder.Services.ConfigureServiceInjections();

			builder.Services.AddAutoMapper(typeof(MappingProfile));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
