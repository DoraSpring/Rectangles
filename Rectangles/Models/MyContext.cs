

namespace Rectangles.Models
{
    using Microsoft.EntityFrameworkCore;
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\TEST;Initial Catalog=test;User Id=sa;Password=test;TrustServerCertificate=true");
        }


        //entities
        public DbSet<Rectangle> Rectangle { get; set; }
        public DbSet<Point> Point { get; set; }
    }
}
