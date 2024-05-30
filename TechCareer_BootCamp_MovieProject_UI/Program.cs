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
			builder.Services.ConfigureIdentityDbContext();

			builder.Services.AddAutoMapper(typeof(MappingProfile));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization(); //bu iki middleware Routing() ile EndPoints() arasýnda olmali
			app.UseAuthentication();

			app.MapAreaControllerRoute(
				name: "Admin",
				areaName: "Admin",
				pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
			);
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"
			);
			
			app.ConfigureDefaultAdminUser();
			//app.MapControllerRoute(
			//	name: "default",
			//	pattern: "{controller=Home}/{action=Index}/{id?}");
			app.Run();
		}
	}
}
