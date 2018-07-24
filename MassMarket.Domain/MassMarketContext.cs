using System.Data.Entity;
using MassMarket.Domain.Entities;

namespace MassMarket.Domain {

    public class MassMarketContext : DbContext {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MetaField> MetaFields { get; set; }
        public DbSet<MetaFieldOption> MetaFieldOptions { get; set; }

        public MassMarketContext() : base("MassMarketContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOptional(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductMetaField>()
                .HasRequired(pm => pm.Product)
                .WithMany(p => p.MetaFields)
                .HasForeignKey(pm => pm.ProductId);

            modelBuilder.Entity<ProductMetaField>()
                .HasRequired(pm => pm.MetaField)
                .WithMany(m => m.Products)
                .HasForeignKey(pm => pm.MetaFieldId);

            modelBuilder.Entity<ProductMetaField>()
                .HasRequired(pm => pm.Option)
                .WithMany(o => o.Products)
                .HasForeignKey(pm => pm.OptionId);

            modelBuilder.Entity<Image>()
                .HasOptional(p => p.Product)
                .WithMany(c => c.Images)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Category>()
                .HasOptional(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId);
        }
    }
}
