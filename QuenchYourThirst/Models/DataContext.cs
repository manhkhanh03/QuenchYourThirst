﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using QuenchYourThirst.Models;
using System;

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

        public DbSet<Bangtenweb> Bangtenwebs { get; set; }
        //Đổi lại ten ni cho t cấy này, không có tiếng việt trong code bangtenweb ????
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Postss> Postss { get; set; }
      
    }
}
