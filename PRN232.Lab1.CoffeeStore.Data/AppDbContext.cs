using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Data.Entities;

namespace PRN232.Lab1.CoffeeStore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductInMenu> ProductInMenus { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductInMenu>()
               .HasOne(pim => pim.Product)
               .WithMany(p => p.ProductInMenus)
               .HasForeignKey(pim => pim.ProductId);

            modelBuilder.Entity<ProductInMenu>()
                .HasOne(pim => pim.Menu)
                .WithMany(m => m.ProductInMenus)
                .HasForeignKey(pim => pim.MenuId);

            modelBuilder.Entity<Product>()
                           .HasOne(p => p.Category)
                           .WithMany(c => c.Products)
                           .HasForeignKey(p => p.CategoryId);
        }
    }

}
