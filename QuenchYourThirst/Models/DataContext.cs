using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Areas.Admin.Models;
using QuenchYourThirst.Models;
﻿﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSizeFlavor> ProductSizeFlavors { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<TypeFlavor> TypeFlavors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<StatusProduct> StatusProducts { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<Cart> Carts { get; set; }
		public DbSet<AdminMenu> AdminMenus { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<AdminUser> AdminUsers { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<Deal_of_the_day> Deal_of_the_days { get; set; }
		public DbSet<Poster> Posters { get; set; }
		public DbSet<Services> Services { get; set; }
		public DbSet<Testimony> Testimonys { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<OrderCart> OrderCarts { get; set; }
		public DbSet<StatusOrder> StatusOrders { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.created_at)
                    .HasDefaultValueSql("dbo.GetTodayDateTime()");
            });

            modelBuilder.Entity<AdminUser>(entity =>
			{
                //entity.Property(e => e.created_at)
                //    .ValueGeneratedOnAdd(() => { return await Functions.getCurrentDate(); });
                entity.Property(e => e.role_id)
                    .HasDefaultValue(1);
            });

            //modelBuilder.Entity<ProductSizeFlavor>()
            //    .HasMany(psf => psf.Product)
            //    .WithOne(p => p.ProductSizeFlavor)
            //    .HasForeignKey(psf => psf.product_id);
            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.ProductSizeFlavor)
            //    .WithOne(psf => psf.Product)
            //    .HasForeignKey(psf => psf.product_id);


            //modelBuilder.Entity<Size>()
            //    .HasMany(s => s.ProductSizeFlavor)
            //    .WithOne(s => s.Size)
            //    .HasForeignKey(psf => psf.size_id);

            //modelBuilder.Entity<Flavor>()
            //    .HasMany(psf => psf.ProductSizeFlavor)
            //    .WithOne(f => f.Flavor)
            //    .HasForeignKey(psf => psf.flavor_id);

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.ProductImage)
            //    .WithOne(pi => pi.Product)
            //    .HasForeignKey(pi => pi.product_id);

            //modelBuilder.Entity<Product>()
            //    .HasOne(sp => sp.StatusProduct)
            //    .WithMany(p => p.Product)
            //    .HasForeignKey(p => p.status_product_id);

            //modelBuilder.Entity<Product>()
            //    .HasOne(pc => pc.ProductCategory)
            //    .WithMany(p => p.Product)
            //    .HasForeignKey(pci => pci.product_category_id);
        }
        public DbSet<Menu> Menus { get; set; }
      
    }
}
