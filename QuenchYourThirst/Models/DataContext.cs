using Microsoft.EntityFrameworkCore;

namespace QuenchYourThirst.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSizeFlavor> ProductSizeFlavors { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<StatusProduct> StatusProducts { get; set; }
         public DbSet<Menu> Menus { get; set; } 
    }
}
