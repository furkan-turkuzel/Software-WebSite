namespace AnalitikBilisimSite.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnalitikBilisimSite.DAL.Concrete.DBContext.AnalitikDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AnalitikBilisimSite.DAL.Concrete.DBContext.AnalitikDBContext";
        }

        protected override void Seed(AnalitikBilisimSite.DAL.Concrete.DBContext.AnalitikDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
