<<<<<<< Updated upstream
﻿using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using QuenchYourThirst.Models;
using System;
>>>>>>> Stashed changes

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

        public DbSet<ProductCategory> ProductCategorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSizeFlavor>()
                .HasOne(psf => psf.Product)
                .WithMany(p => p.ProductSizeFlavor)
                .HasForeignKey(psf => psf.product_id);

            modelBuilder.Entity<ProductSizeFlavor>()
                .HasOne(psf => psf.Size)
                .WithMany()
                .HasForeignKey(psf => psf.size_id);

            modelBuilder.Entity<ProductSizeFlavor>()
                .HasOne(psf => psf.Flavor)
                .WithMany()
                .HasForeignKey(psf => psf.flavor_id);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImage)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.product_id);

            modelBuilder.Entity<Product>()
                .HasOne(sp => sp.StatusProduct)
                .WithMany(p => p.Product)
                .HasForeignKey(p => p.status_product_id);
            modelBuilder.Entity<Product>()
                .HasOne(pc => pc.ProductCategory)
                .WithMany(p => p.Product)
                .HasForeignKey(pci => pci.product_category_id);
        }
        public DbSet<Bangtenweb> Bangtenwebs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Postss> Postss { get; set; }
      
>>>>>>> Stashed changes
    }
}
