using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_BootCamp_MovieProject_Repositories.Context
{
    //scaffolding hatasi aliyordum; otomatik viewleri olustururken hata veriyordu, bu class o yuzden eklendi(ama migration alırken burasi hata veriyor)
    public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
            optionsBuilder.UseSqlServer("Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog = TechCareerMovieProjectDb; Integrated Security = true; MultipleActiveResultSets=true;");

            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}
