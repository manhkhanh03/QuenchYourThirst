using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Areas.Admin.Models;
using QuenchYourThirst.Models;
﻿﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

using System;

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
        public DbSet<AdminMenu> AdminMenus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.created_at)
                    .HasDefaultValueSql("GETDATE()");
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


        public DbSet<Bangtenweb> Bangtenwebs { get; set; }
        //Đổi lại ten ni cho t cấy này, không có tiếng việt trong code bangtenweb ????
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Postss> Postss { get; set; }
      
    }
}
