namespace MassMarket.Domain.Migrations {

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MassMarketContext> {

        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }
    }
}
