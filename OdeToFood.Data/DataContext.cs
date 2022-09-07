using Microsoft.EntityFrameworkCore;
using OdeToFood.Entities;

namespace OdeToFood.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=HODHOD-PC\\SQLEXPRESS;User=sa;Password=abdelhady;Initial Catalog=OdeToFood;");
            }
        }
    }
}
