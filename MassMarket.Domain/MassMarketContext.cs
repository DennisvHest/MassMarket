﻿using System.Data.Entity;
using MassMarket.Domain.Entities;

namespace MassMarket.Domain {

    public class MassMarketContext : DbContext {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MassMarketContext() : base("MassMarketContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Product>()
                .HasOptional(p => p.Category)
                .WithMany(c => c.Products);

            modelBuilder.Entity<Category>()
                .HasOptional(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories);
        }
    }
}
