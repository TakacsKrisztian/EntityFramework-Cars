using Microsoft.EntityFrameworkCore;

namespace CarsApi.Models
{
    public class CarContext : DbContext
    {
        public CarContext() { }
        public CarContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=192.168.50.12; database=CarDb; user=root; password=Fakeasd123", ServerVersion.AutoDetect("server=192.168.50.12; database=CarDb; user=root; password=Fakeasd123"));
            }
        }

        public DbSet<Car> Cars { get; set; } = null!;
    }
}