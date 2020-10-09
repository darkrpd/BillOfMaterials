using BillOfMaterials.Core.Models;
using BillOfMaterials.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterials.DataAccess
{
    public class BillOfMaterialsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } 

        public BillOfMaterialsDbContext(DbContextOptions<BillOfMaterialsDbContext> options)
            : base(options)
        {  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // lazy load activation
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // adds sub configurations
            builder
                .ApplyConfiguration(new CategoryConfiguration());

            builder
                .ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
