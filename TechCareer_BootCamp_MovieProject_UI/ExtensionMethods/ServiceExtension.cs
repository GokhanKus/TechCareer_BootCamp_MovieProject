using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechCareer_BootCamp_MovieProject_Repositories.Context;

namespace TechCareer_BootCamp_MovieProject_UI.ExtensionMethods
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlServer(this IServiceCollection service ,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnectionString");
            service.AddDbContext<MovieDbContext>(options => 
            options.UseSqlServer(connectionString,migr=>migr.MigrationsAssembly(nameof(TechCareer_BootCamp_MovieProject_UI))));
            //migration Assembly yazmamızın sebebi: migration klasorunu UI'da olusturamıyorduk Repositories de olusturabiliyorduk.. artik UI'da Migration Klasoru olusuyor
        }
    }
}
