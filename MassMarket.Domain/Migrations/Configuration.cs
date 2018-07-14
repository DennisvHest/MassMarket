using MassMarket.Domain.Entities;

namespace MassMarket.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MassMarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MassMarketContext context)
        {
            Category category1 = new Category { Name = "Game Consoles" };
            Category category2 = new Category { Name = "Gaming" };

            category1.ParentCategory = category2;

            context.Categories.Add(category1);
            context.Categories.Add(category2);

            Product product1 = new Product {
                Name = "Nintendo Switch",
                Description = "Gaming at home or on the go!",
                Category = category1
            };

            context.Products.Add(product1);

            context.SaveChanges();
        }
    }
}
