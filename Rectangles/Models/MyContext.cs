using Microsoft.EntityFrameworkCore;

namespace Rectangles.Models
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var dbConnectionString = config["ConnectionString:WebApiDatabase"];

            optionsBuilder.UseSqlServer(dbConnectionString);
        }


        //entities
        public DbSet<Rectangle> Rectangle { get; set; }
        public DbSet<Point> Point { get; set; }
    }
}
