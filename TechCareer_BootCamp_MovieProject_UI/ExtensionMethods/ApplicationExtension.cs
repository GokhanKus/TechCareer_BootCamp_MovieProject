using Microsoft.AspNetCore.Identity;

namespace TechCareer_BootCamp_MovieProject_UI.ExtensionMethods
{
	public static class ApplicationExtension
	{
        //bu class'a degisikliklerin db'ye yansitilmasini saglayan update-database komutunu oto olarak gerceklestirecek
        //ConfigureAndCheckMigration() metodu yazilabilir
       
		public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app,IConfiguration configuration)
		{
			 string adminUser = "Admin";
			 string adminPassword = "Admin.123456";

			UserManager<IdentityUser> userManager = app
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();

			RoleManager<IdentityRole> roleManager = app
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole>>();

			IdentityUser? user = await userManager.FindByNameAsync(adminUser); //"Admin" adinda bir user var mi yoksa olusturalim
			if (user == null)
			{
				user = new IdentityUser
				{
					UserName = adminUser,
					Email = "gokhankus98@gmail.com",
					PhoneNumber = "+90123456789"
				};

				IdentityResult? userResult = await userManager.CreateAsync(user, adminPassword);
				if (userResult.Succeeded == false)
					throw new Exception("Admin user could not created");//useri olustururken islem basarisiz ise hata firlatalim


				var roles = roleManager.Roles.Select(r => r.Name).ToList();
				IdentityResult? roleResult = await userManager.AddToRolesAsync(user, roles);

				if (roleResult.Succeeded == false)
					throw new Exception("an error occured while assigning the role for admin");
			}
		}
	}
}
