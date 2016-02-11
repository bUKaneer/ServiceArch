using System.Data.Entity.Migrations;

namespace ServiceArch.DataProviders.EntityFramework
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ServiceArch.Services.Data.Providers.EntityFramework.DataContext";

        }

        protected override void Seed(DataContext context)
        { }
    }
}
